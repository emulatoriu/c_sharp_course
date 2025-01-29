using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using static SrcChess2.PgnParser;

namespace SrcChess2 {
    /// <summary>
    /// Interaction logic for wndPGNParsing.xaml
    /// </summary>
    public partial class frmCreatingBookFromPGN : Window {
        /// <summary>Task</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "Must not be GC")]
        private Task?               m_task;
        /// <summary>Array of file names</summary>
        private readonly string[]?  m_fileNames;
        /// <summary>Actual phase</summary>
        private ParsingPhase        m_phase;
        /// <summary>Book creation result</summary>
        private bool                m_result;
        /// <summary>Private delegate</summary>
        private delegate void       delProgressCallBack(ParsingPhase phase, int fileIndex, int fileCount, string? fileName, int gameDone, int gameCount);

        /// <summary>
        /// Ctor
        /// </summary>
        public frmCreatingBookFromPGN() {
            InitializeComponent();
            Loaded      += WndPGNParsing_Loaded;
            Unloaded    += WndPGNParsing_Unloaded;
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public frmCreatingBookFromPGN(string[] arrFileNames) : this() {
            m_fileNames  = arrFileNames;
        }

        /// <summary>
        /// Called when the windows is loaded
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        private void WndPGNParsing_Loaded(object sender, RoutedEventArgs e) {
            ProgressBar.Start();
            StartProcessing();
        }

        /// <summary>
        /// Called when the windows is closing
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        private void WndPGNParsing_Unloaded(object sender, RoutedEventArgs e) {
            ProgressBar.Stop();
        }

        /// <summary>
        /// Total number of games skipped
        /// </summary>
        public int TotalSkipped { get; private set; }

        /// <summary>
        /// Total number of games truncated
        /// </summary>
        public int TotalTruncated { get; private set; }

        /// <summary>
        /// Error if any
        /// </summary>
        public string? Error { get; private set; }

        /// <summary>
        /// Created openning book
        /// </summary>
        public Book? Book { get; private set; }

        /// <summary>
        /// Number of entries in the book
        /// </summary>
        public int BookEntryCount { get; private set; }

        /// <summary>
        /// List of moves of all games
        /// </summary>
        public List<short[]>? MoveList { get; private set; }

        /// <summary>
        /// Cancel the parsing job
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        private void butCancel_Click(object sender, RoutedEventArgs e) {
            butCancel.IsEnabled = false;
            PgnParser.CancelParsingJob();
        }

        /// <summary>
        /// Progress bar
        /// </summary>
        /// <param name="phase">        Phase</param>
        /// <param name="fileIndex">    File index</param>
        /// <param name="fileCount">    File count</param>
        /// <param name="fileName">     File name</param>
        /// <param name="gameDone">     Games processed since the last call</param>
        /// <param name="gameCount">    Game count</param>
        private void WndCallBack(ParsingPhase phase, int fileIndex, int fileCount, string? fileName, int gameDone, int gameCount) {
            if (m_phase != phase) {
                switch (phase) {
                case ParsingPhase.OpeningFile:
                    ctlPhase.Content                = "Openning the file";
                    ctlFileBeingProcessed.Content   = System.IO.Path.GetFileName(fileName ?? throw new ArgumentNullException(nameof(fileName)));
                    ctlStep.Content                 = "";
                    break;
                case ParsingPhase.ReadingFile:
                    ctlPhase.Content                = "Reading the file content into memory";
                    ctlStep.Content                 = "";
                    break;
                case ParsingPhase.RawParsing:
                    ctlPhase.Content                = "Parsing the PGN";
                    ctlStep.Content                 = "0 / " + gameCount.ToString() + "mb";
                    break;
                case ParsingPhase.Finished:
                    ctlPhase.Content                = "Done";
                    break;
                case ParsingPhase.CreatingBook:
                    ctlPhase.Content                = "Creating the book entries";
                    ctlFileBeingProcessed.Content   = "***";
                    break;
                default:
                    break;
                }
                m_phase = phase;
            }
            switch (phase) {
            case ParsingPhase.OpeningFile:
                break;
            case ParsingPhase.ReadingFile:
                ctlPhase.Content    = "Reading the file content into memory";
                break;
            case ParsingPhase.RawParsing:
                ctlStep.Content = gameDone.ToString() + " / " + gameCount.ToString() + " mb";
                break;
            case ParsingPhase.CreatingBook:
                ctlStep.Content = gameDone.ToString() + " / " + gameCount.ToString();
                break;
            case ParsingPhase.Finished:
                if (PgnParser.IsJobCancelled) {
                    DialogResult = false;
                } else {
                    DialogResult = m_result;
                }
                break;
            default:
                break;
            }
        }

        /// <summary>
        /// Progress bar
        /// </summary>
        /// <param name="cookie">           Cookie</param>
        /// <param name="phase">            Phase</param>
        /// <param name="fileIndex">        File index</param>
        /// <param name="fileCount">        File count</param>
        /// <param name="fileName">         File name</param>
        /// <param name="gameProcessed">    Games processed since the last call</param>
        /// <param name="gameCount">        Game count</param>
        static void ProgressCallBack(object? cookie, ParsingPhase phase, int fileIndex, int fileCount, string? fileName, int gameProcessed, int gameCount) {
            frmCreatingBookFromPGN  wnd;
            delProgressCallBack     del;

            wnd = (frmCreatingBookFromPGN)cookie!;
            del = wnd.WndCallBack;
            wnd.Dispatcher.Invoke(del, System.Windows.Threading.DispatcherPriority.Normal, new object[] { phase, fileIndex, fileCount, fileName ?? "", gameProcessed, gameCount });
        }

        /// <summary>
        /// Create a book from a list of PGN games
        /// </summary>
        /// <returns></returns>
        private bool CreateBook() {
            bool    retVal;

            try {
                m_phase         = ParsingPhase.None;
                retVal          = PgnParser.ExtractMoveListFromMultipleFiles(m_fileNames ?? throw new InvalidOperationException("List of filenames not set"),
                                                                             (cookie, phase, fileIndex, fileCount, fileName, gameProcessed, gameCount) => { ProgressCallBack(cookie, phase, fileIndex, fileCount, fileName, gameProcessed, gameCount); },
                                                                             this,
                                                                             out List<short[]> moveList,
                                                                             out int totalSkipped,
                                                                             out int totalTruncated,
                                                                             out string? errTxt);
                MoveList        = moveList;
                TotalSkipped    = totalSkipped;
                TotalTruncated  = totalTruncated;
                Error           = errTxt;
                if (retVal) {
                    Book            = new Book();
                    BookEntryCount  = Book.CreateBookList(MoveList,
                                                          30 /*iMinMoveCount*/,
                                                          10 /*iMaxDepth*/,
                                                          (cookie, ePhase, iFileIndex, iFileCount, strFileName, iGameProcessed, iGameCount) => { ProgressCallBack(cookie, ePhase, iFileIndex, iFileCount, strFileName, iGameProcessed, iGameCount); },
                                                          this);
                }
            } catch(System.Exception ex) {
                MessageBox.Show(ex.Message);
                retVal = false;
            }
            m_result = retVal;
            ProgressCallBack(this, ParsingPhase.Finished, fileIndex: 0, fileCount: 0, fileName: null, gameProcessed: 0, gameCount: 0);
            return(retVal);
        }

        /// <summary>
        /// Start processing
        /// </summary>
        private void StartProcessing() {
            m_task = Task<bool>.Factory.StartNew(() => { return(CreateBook()); });
        }
    }
}
