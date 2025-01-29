using System;

namespace SrcChess2 {

    /// <summary>Type of transposition entry</summary>
    public enum TransEntryType {
        /// <summary>Exact move value</summary>
        Exact   = 0,
        /// <summary>Alpha cut off value</summary>
        Alpha   = 1,
        /// <summary>Beta cut off value</summary>
        Beta    = 2
    };

    /// <summary>
    /// Implements a transposition table. Transposition table is used to cache already computed board 
    /// </summary>
    public class TransTable {

        /// <summary>Entry in the transposition table</summary>
        private struct TransEntry {
            public long                         Key64;      // 64 bits key compute with Zobrist algorithm. Defined a probably unique board position.
            public int                          Generation; // Generation of the entry
            public ChessBoard.BoardStateMask    ExtraInfo;  // Board extra info. Defined board extra information
            public int                          Depth;      // Depth of the move (reverse)
            public TransEntryType               EntryType;  // Type of the entry
            public int                          Value;      // Value of the entry
        };
        
        /// <summary>Locking object</summary>
        private readonly object         m_lock = new();
        /// <summary>Hashlist of entries</summary>
        private readonly TransEntry[]   m_transEntries;
        /// <summary>Number of cache hit</summary>
        private long                    m_cacheHit;
        /// <summary>Current generation</summary>
        private int                     m_generation = 1;   // Start with generation one so empty entry are not considered valid

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="entryCount"> Maximum number of entry in the transposition table</param>
        public TransTable(int entryCount) {
            if (entryCount > 2147483647) {
                throw new ArgumentException("Translation Table to big", nameof(entryCount));
            }
            m_transEntries = new TransEntry[entryCount];
        }

        /// <summary>
        /// Size of the translation table
        /// </summary>
        public int EntryCount => m_transEntries.Length;

        /// <summary>
        /// Gets the entry position for the specified key
        /// </summary>
        /// <param name="zobristKey"></param>
        /// <returns></returns>
        private int GetEntryPos(long zobristKey) => (int)((ulong)zobristKey % (uint)m_transEntries.Length);

        /// <summary>
        /// Record a new entry in the table
        /// </summary>
        /// <param name="zobristKey">   Zobrist key. Probably unique for this board position.</param>
        /// <param name="extraInfo">    Extra information about the board not contains in the Zobrist key</param>
        /// <param name="depth">        Current depth (reverse)</param>
        /// <param name="value">        Board evaluation</param>
        /// <param name="type">         Type of the entry</param>
        public void RecordEntry(long zobristKey, ChessBoard.BoardStateMask extraInfo, int depth, int value, TransEntryType type) {
            TransEntry  entry;
            int         entryPos;

            zobristKey      ^= (int)extraInfo;
            entryPos         = GetEntryPos(zobristKey);
            entry            = new();
            entry.Key64      = zobristKey;
            entry.Generation = m_generation;
            entry.ExtraInfo  = extraInfo;
            entry.Depth      = depth;
            entry.Value      = value;
            entry.EntryType  = type;
            lock (m_lock) {
                m_transEntries[entryPos] = entry;
            }
        }

        /// <summary>
        /// Try to find if the current board has already been evaluated
        /// </summary>
        /// <param name="zobristKey">   Zobrist key. Probably unique for this board position.</param>
        /// <param name="extraInfo">    Extra information about the board not contains in the Zobrist key</param>
        /// <param name="depth">        Current depth (reverse)</param>
        /// <param name="alpha">        Alpha cut off</param>
        /// <param name="beta">         Beta cut off</param>
        /// <returns>
        /// Int32.MaxValue if no valid value found, else value of the board.
        /// </returns>
        public int ProbeEntry(long zobristKey, ChessBoard.BoardStateMask extraInfo, int depth, int alpha, int beta) {
            int         retVal = Int32.MaxValue;
            int         entryPos;
            TransEntry  entry;
            
            zobristKey ^= (int)extraInfo;
            entryPos    = GetEntryPos(zobristKey);
            lock (m_lock) {
                entry = m_transEntries[entryPos];
            }
            if (entry.Key64 == zobristKey && entry.Generation == m_generation && entry.ExtraInfo == extraInfo) {
                if (entry.Depth >= depth) {
                    switch(entry.EntryType) {
                    case TransEntryType.Exact:
                        retVal = entry.Value;
                        break;
                    case TransEntryType.Alpha:
                        if (entry.Value <= alpha) {
                            retVal = alpha;
                        }
                        break;
                    case TransEntryType.Beta:
                        if (entry.Value >= beta) {
                            retVal = beta;
                        }
                        break;
                    }
                    m_cacheHit++;
                }
            }
            return(retVal);
        }            

        /// <summary>
        /// Number of cache hit
        /// </summary>
        public long CacheHit => m_cacheHit;

        /// <summary>
        /// Reset the cache
        /// </summary>
        public void Reset() {
            m_cacheHit = 0;
            m_generation++;
        }
    } // Class TransTable
} // Namespace
