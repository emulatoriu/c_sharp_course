﻿using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace SrcChess2 {
    /// <summary>
    /// Maintains a move history to handle the fifty-move rule and the threefold repetition rule.
    /// 
    /// For the first rules, we just maintains one move count per series of move which doesn't eat a piece or move a pawn.
    /// For the second rules, we use two strategies, a fast but unreliable one and a second slower but exact.
    ///
    ///     A.  Use two 16KB table of counter address by table[Zobrist key of the board mod 16KB]. Collision can occurs so its
    ///         only a good indication that the board can be there more than 2 times.
    ///     B.  Keep a compressed representation of the board in an array to be able to count the number of identical boards.
    /// 
    /// </summary>
    public sealed class MoveHistory : IXmlSerializable {

        /// <summary>
        /// Each pawn can move a maximum of 6 times, there is 31 pieces which can be eaten. So no more than
        /// 127 times the AddCurrentMove can be called with bPawnMoveOrPieceEaten set without undo being done on it</summary>
        private const int Max50CounterDepth = 130;
        
        /// <summary>
        /// Packed representation of a board. Each long contains 16 pieces (2 per bytes)
        /// </summary>
        public struct PackedBoard {
            /// <summary>Pieces from square 0-15</summary>
            public long                         m_val1;
            /// <summary>Pieces from square 16-31</summary>
            public long                         m_val2;
            /// <summary>Pieces from square 32-47</summary>
            public long                         m_val3;
            /// <summary>Pieces from square 48-63</summary>
            public long                         m_val4;
            /// <summary>Additional board info</summary>
            public ChessBoard.BoardStateMask   m_info;
            /// <summary>
            /// Save the structure in a binary writer
            /// </summary>
            /// <param name="writer">   Binary writer</param>
            public void SaveToStream(BinaryWriter writer) {
                writer.Write(m_val1);
                writer.Write(m_val2);
                writer.Write(m_val3);
                writer.Write(m_val4);
                writer.Write((int)m_info);
            }
            /// <summary>
            /// Load the structure from a binary reader
            /// </summary>
            /// <param name="reader">   Binary reader</param>
            public void LoadFromStream(System.IO.BinaryReader reader) {
                m_val1 = reader.ReadInt64();
                m_val2 = reader.ReadInt64();
                m_val3 = reader.ReadInt64();
                m_val4 = reader.ReadInt64();
                m_info = (ChessBoard.BoardStateMask)reader.ReadInt32();
            }
        };
        
        /// <summary>Current packed board representation</summary>
        private PackedBoard     m_curPackedBoard;
        /// <summary>Number of moves in the history</summary>
        private int             m_moveCount;
        /// <summary>Size of the packed board array</summary>
        private int             m_packedBoardArraySize;
        /// <summary>Array of packed boards</summary>
        private PackedBoard[]   m_packedBoard;
        /// <summary>Array of byte containing the count of each board identified by a Zobrist key.</summary>
        private byte[]          m_hashesCount;
        /// <summary>Depth of current count move. Up to IMax50CounterDepth - 1</summary>
        private int             m_moveDepthCount;
        /// <summary>Array of count move</summary>
        private short[]         m_countMoves;

        /// <summary>
        /// Class constructor
        /// </summary>
        public MoveHistory() {
            m_moveCount             = 0;
            m_packedBoardArraySize  = 512;
            m_packedBoard           = new PackedBoard[m_packedBoardArraySize];
            m_hashesCount           = new byte[16384];
            m_moveDepthCount        = 0;
            m_countMoves            = new short[Max50CounterDepth];
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="moveHistory">  MoveHistory template</param>
        private MoveHistory(MoveHistory moveHistory) {
            m_moveCount             = moveHistory.m_moveCount;
            m_moveDepthCount        = moveHistory.m_moveDepthCount;
            m_packedBoardArraySize  = moveHistory.m_packedBoardArraySize;
            m_packedBoard           = (PackedBoard[])moveHistory.m_packedBoard.Clone();
            m_hashesCount           = (byte[])moveHistory.m_hashesCount.Clone();
            m_countMoves            = (short[])moveHistory.m_countMoves.Clone();
            m_curPackedBoard        = moveHistory.m_curPackedBoard;
        }

        /// <summary>
        /// Creates a clone of the MoveHistory
        /// </summary>
        /// <returns>
        /// A new clone of the MoveHistory
        /// </returns>
        public MoveHistory Clone() => new MoveHistory(this);

        /// <summary>
        /// Returns the XML schema if any
        /// </summary>
        /// <returns>
        /// null
        /// </returns>
        System.Xml.Schema.XmlSchema? IXmlSerializable.GetSchema() => null;

        /// <summary>
        /// Deserialize the object from a XML reader
        /// </summary>
        /// <param name="reader">   XML reader</param>
        void IXmlSerializable.ReadXml(XmlReader reader) {
            MemoryStream    memStream;
            BinaryReader    binReader;
            byte[]          bytes;
            int             count;

            if (reader.MoveToContent() != XmlNodeType.Element || reader.LocalName != "MoveHistory") {
                throw new SerializationException("Unknown format");
            } else {
                memStream   = new MemoryStream(32768);
                bytes       = new byte[32768];
                do {
                    count = reader.ReadElementContentAsBinHex(bytes, 0, bytes.Length);
                    if (count != 0) {
                        memStream.Write(bytes, 0, count);
                    }
                } while (count != 0);
                memStream.Seek(0, SeekOrigin.Begin);
                binReader   = new BinaryReader(memStream);
                using (binReader) { 
                    LoadFromStream(binReader);
                }
            }
        }

        /// <summary>
        /// Serialize the object to a XML writer
        /// </summary>
        /// <param name="writer">   XML writer</param>
        void IXmlSerializable.WriteXml(XmlWriter writer) {
            MemoryStream    memStream;
            BinaryWriter    binWriter;
            byte[]          bytes;

            memStream   = new MemoryStream(32768);
            binWriter   = new BinaryWriter(memStream);
            SaveToStream(binWriter);
            bytes       = memStream.GetBuffer();
            writer.WriteStartElement("MoveHistory");
            writer.WriteBinHex(bytes, 0, (int)memStream.Length);
            writer.WriteEndElement();
        }


        /// <summary>
        /// Load from stream
        /// </summary>
        /// <param name="reader">   Binary reader</param>
        public void LoadFromStream(BinaryReader reader) {
            int                     newSize;
            ChessBoard.PieceType[]  board;
            PackedBoard             packedBoard;
            long                    zobristKey;
            
            packedBoard.m_val1 = 0;
            packedBoard.m_val2 = 0;
            packedBoard.m_val3 = 0;
            packedBoard.m_val4 = 0;
            packedBoard.m_info = (ChessBoard.BoardStateMask)0;
            Array.Clear(m_hashesCount, 0, m_hashesCount.Length);
            m_curPackedBoard.LoadFromStream(reader);
            board           = new ChessBoard.PieceType[64];
            m_moveCount     = reader.ReadInt32();
            newSize         = m_packedBoardArraySize;
            while (m_moveCount > newSize) {
                newSize *= 2;
            }
            if (newSize != m_packedBoardArraySize) {
                m_packedBoard          = new PackedBoard[newSize];
                m_packedBoardArraySize = newSize;
            }
            for (int i = 0; i < m_moveCount; i++) {
                packedBoard.LoadFromStream(reader);
                m_packedBoard[i] = packedBoard;
                UnpackBoard(packedBoard, board);
                zobristKey = ZobristKey.ComputeBoardZobristKey(board) ^ (int)packedBoard.m_info;
                m_hashesCount[zobristKey & 16383]++;
            }
            m_moveDepthCount = reader.ReadInt32();
            for (int i = 0; i <= m_moveDepthCount; i++) {
                m_countMoves[i] = reader.ReadInt16();
            }
        }

        /// <summary>
        /// Save to stream
        /// </summary>
        /// <param name="writer">   Binary writer</param>
        public void SaveToStream(BinaryWriter writer) {
            m_curPackedBoard.SaveToStream(writer);
            writer.Write(m_moveCount);
            for (int i = 0; i < m_moveCount; i++) {
                m_packedBoard[i].SaveToStream(writer);
            }
            writer.Write(m_moveDepthCount);
            for (int i = 0; i <= m_moveDepthCount; i++) {
                writer.Write(m_countMoves[i]);
            }            
        }

        /// <summary>
        /// Determine if two boards are equal
        /// </summary>
        /// <param name="board1">   First board</param>
        /// <param name="board2">   Second board</param>
        /// <returns>
        /// true if equal, false if not
        /// </returns>
        private static bool IsTwoBoardEqual(PackedBoard board1, PackedBoard board2) {
            bool    retVal;
            
            if (((board1.m_info | board2.m_info) & ChessBoard.BoardStateMask.EnPassant) != 0) {
                retVal = false;
            } else {
                retVal = (board1.m_info == board2.m_info     &&
                          board1.m_val1 == board2.m_val1     &&
                          board1.m_val2 == board2.m_val2     &&
                          board1.m_val3 == board2.m_val3     &&
                          board1.m_val4 == board2.m_val4);
            }
            return(retVal);
        }

        /// <summary>
        /// Gets the number of time this board is in the history (for the same color)
        /// </summary>
        /// <param name="board">    Board</param>
        /// <returns>
        /// Count
        /// </returns>
        private int GetBoardCount(PackedBoard board) {
            int     retVal = 0;
            
            for (int i = m_moveCount - 2; i >= 0; i -= 2) {
                if (IsTwoBoardEqual(board, m_packedBoard[i])) {
                    retVal++;
                }
            }
            return(retVal);
        }

        /// <summary>
        /// Add the current packed board to the history
        /// </summary>
        /// <param name="zobristKey">               Zobrist key of the board</param>
        /// <param name="isPawnMoveOrPieceEaten">   true if a pawn has moved or a piece has been eaten</param>
        /// <returns>
        /// Result: NoRepeat, ThreeFoldRepeat or FiftyRuleRepeat
        /// </returns>
        public ChessBoard.RepeatResult AddCurrentPackedBoard(long zobristKey, bool isPawnMoveOrPieceEaten) {
            ChessBoard.RepeatResult retVal = ChessBoard.RepeatResult.NoRepeat;
            int                     hashIndex;
            int                     newArraySize;
            byte                    count;
            PackedBoard[]           newBoard;
            
            zobristKey ^= (int)m_curPackedBoard.m_info;
            if (m_moveCount >= m_packedBoardArraySize) {
                newArraySize = m_packedBoardArraySize * 2;
                newBoard     = new PackedBoard[newArraySize];
                Array.Copy(m_packedBoard, newBoard, m_packedBoardArraySize);
                m_packedBoardArraySize = newArraySize;
            }
            hashIndex                   = (int)(zobristKey & 16383);
            count                       = ++m_hashesCount[hashIndex];
            m_hashesCount[hashIndex]    = count;
            if (isPawnMoveOrPieceEaten) {
                m_moveDepthCount++;
                m_countMoves[m_moveDepthCount] = 0;
            } else {
                if (++m_countMoves[m_moveDepthCount] >= 50) {
                    retVal = ChessBoard.RepeatResult.FiftyRuleRepeat;
                } else {
                    // A count > 2 is only an indication that 3 or more identical board may exist
                    // because 2 non-identical board can share the same slot
                    if (count > 2 && GetBoardCount(m_curPackedBoard) >= 2) {
                        retVal = ChessBoard.RepeatResult.ThreeFoldRepeat;
                    }
                }
            }
            m_packedBoard[m_moveCount++] = m_curPackedBoard;
            return(retVal);
        }

        /// <summary>
        /// Add the current packed board to the history
        /// </summary>
        /// <param name="zobristKey">   Zobrist key of the board</param>
        /// <returns>
        /// Result: NoRepeat, ThreeFoldRepeat or FiftyRuleRepeat
        /// </returns>
        public ChessBoard.RepeatResult CurrentRepeatResult(long zobristKey) {
            ChessBoard.RepeatResult retVal = ChessBoard.RepeatResult.NoRepeat;
            int                     hashIndex;
            byte                    count;
            
            hashIndex = (int)(zobristKey & 16383);
            count     = m_hashesCount[hashIndex];
            if (m_countMoves[m_moveDepthCount] >= 50) {
                retVal = ChessBoard.RepeatResult.FiftyRuleRepeat;
            } else {
                // A count > 2 is only an indication that 3 or more identical board may exist
                // because 2 non-identical board can share the same slot
                if (count > 2 && GetBoardCount(m_curPackedBoard) >= 2) {
                    retVal = ChessBoard.RepeatResult.ThreeFoldRepeat;
                }
            }
            return(retVal);
        }

        /// <summary>
        /// Get the current packed board count
        /// </summary>
        /// <returns>
        /// <param name="zobristKey">   Zobrist key of the board</param>
        /// Count
        /// </returns>
        public int GetCurrentBoardCount(long zobristKey) {
            int     retVal;
            int     hashIndex;
            
            zobristKey ^= (int)m_curPackedBoard.m_info;
            hashIndex   = (int)(zobristKey & 16383);
            retVal      = m_hashesCount[hashIndex];
            if (retVal != 0) {
                retVal = GetBoardCount(m_curPackedBoard);
            }
            return(retVal);
        }

        /// <summary>
        /// Gets the current half move count (number of moves since a pawn has been moved or a piece eaten)
        /// </summary>
        public int GetCurrentHalfMoveCount => m_countMoves[m_moveDepthCount];
        
        /// <summary>
        /// Remove the last move from the history
        /// </summary>
        /// <param name="zobristKey">   Zobrist key of the board</param>
        public void RemoveLastMove(long zobristKey) {
            zobristKey ^= (int)m_curPackedBoard.m_info;
            m_hashesCount[zobristKey & 16383]--;
            m_moveCount--;
            if (m_countMoves[m_moveDepthCount] == 0) {
                m_moveDepthCount--;
            } else {
                m_countMoves[m_moveDepthCount]--;
            }
        }

        /// <summary>
        /// Compute a packed value of 16 pieces
        /// </summary>
        /// <param name="board">        Board array</param>
        /// <param name="startPos">     Pieces starting position</param>
        /// <returns>
        /// Packed value of the 16 pieces
        /// </returns>
        private static long ComputePackedValue(ChessBoard.PieceType[] board, int startPos) {
            long    retVal = 0;
            
            for (int i = 0; i < 16; i++) {
                retVal |= ((long)board[startPos + i] & 15) << (i << 2);
            }
            return(retVal);
        }

        /// <summary>
        /// Compute the packed representation of a board
        /// </summary>
        /// <param name="board">    Board array</param>
        /// <param name="info">     Board extra info</param>
        public static PackedBoard ComputePackedBoard(ChessBoard.PieceType[] board, ChessBoard.BoardStateMask info) {
            PackedBoard packedBoard;
            
            packedBoard.m_val1    = ComputePackedValue(board, 0);
            packedBoard.m_val2    = ComputePackedValue(board, 16);
            packedBoard.m_val3    = ComputePackedValue(board, 32);
            packedBoard.m_val4    = ComputePackedValue(board, 48);
            packedBoard.m_info    = info & ~ChessBoard.BoardStateMask.BlackToMove;
            return(packedBoard);
        }

        /// <summary>
        /// Compute the current packed representation of a board
        /// </summary>
        /// <param name="board">    Board array</param>
        /// <param name="info">     Board extra info</param>
        private void ComputeCurrentPackedBoard(ChessBoard.PieceType[] board, ChessBoard.BoardStateMask info) => m_curPackedBoard = ComputePackedBoard(board, info);

        /// <summary>
        /// Unpack a packed board value to a board
        /// </summary>
        /// <param name="val">          Packed board value</param>
        /// <param name="board">        Board array</param>
        /// <param name="startPos">     Offset in the board</param>
        private static void UnpackBoardValue(long val, ChessBoard.PieceType[] board, int startPos) {
            for (int i = 0; i < 16; i++) {
                board[startPos + i] = (ChessBoard.PieceType)((val >> (i << 2)) & 15);
            }
        }

        /// <summary>
        /// Unpack a packed board to a board
        /// </summary>
        /// <param name="packedBoard">  Packed board</param>
        /// <param name="board">        Board array</param>
        public static void UnpackBoard(PackedBoard packedBoard, ChessBoard.PieceType[] board) {
            UnpackBoardValue(packedBoard.m_val1, board, 0);
            UnpackBoardValue(packedBoard.m_val2, board, 16);
            UnpackBoardValue(packedBoard.m_val3, board, 32);
            UnpackBoardValue(packedBoard.m_val4, board, 48);
        }

        /// <summary>
        /// Reset the move history
        /// </summary>
        /// <param name="board">    Board array</param>
        /// <param name="info">     Board extra info</param>
        public void Reset(ChessBoard.PieceType[] board, ChessBoard.BoardStateMask info) {
            m_countMoves[0]     = 0;
            m_moveDepthCount    = 0;
            m_moveCount         = 0;
            Array.Clear(m_hashesCount, 0, m_hashesCount.Length);
            ComputeCurrentPackedBoard(board, info);
        }

        /// <summary>
        /// Update the current board packing
        /// </summary>
        /// <param name="pos">          Position of the new piece</param>
        /// <param name="newPieceType"> New piece type</param>
        public void UpdateCurrentPackedBoard(int pos, ChessBoard.PieceType newPieceType) {
            long    newPiece;
            long    mask;
            int     slotInValue;
            
            slotInValue = (pos & 15) << 2;
            newPiece    = ((long)newPieceType & 15) << slotInValue;
            mask        = (long)15 << slotInValue;
            if (pos < 16) {
                m_curPackedBoard.m_val1 = (m_curPackedBoard.m_val1 & ~mask) | newPiece;
            } else if (pos < 32) {
                m_curPackedBoard.m_val2 = (m_curPackedBoard.m_val2 & ~mask) | newPiece;
            } else if (pos < 48) {
                m_curPackedBoard.m_val3 = (m_curPackedBoard.m_val3 & ~mask) | newPiece;
            } else {
                m_curPackedBoard.m_val4 = (m_curPackedBoard.m_val4 & ~mask) | newPiece;
            }
        }

        /// <summary>
        /// Update the current board packing
        /// </summary>
        /// <param name="info">        Board extra info</param>
        public void UpdateCurrentPackedBoard(ChessBoard.BoardStateMask info) => m_curPackedBoard.m_info = info & ~ChessBoard.BoardStateMask.BlackToMove;

    } // Class MoveHistory
} // Class name
