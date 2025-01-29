using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static SrcChess2.PgnParser;

namespace SrcChess2 {
    /// <summary>
    /// Interaction logic for frmLoadPGNGames.xaml
    /// </summary>
    public partial class frmLoadPGNGames : Window {
        /// <summary>Processed file name</summary>
        private readonly string m_fileName;
        /// <summary>Task used to process the file</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "Must not be GC")]
        private Task<bool>?     m_task;
        /// <summary>Actual phase</summary>
        private ParsingPhase    m_phase;
        /// <summary>PGN parsing result</summary>
        private bool            m_result;
        /// <summary>Private delegate</summary>
        private delegate void   delProgressCallBack(ParsingPhase phase, int fileIndex, int fileCount, string? fileName, int gameDone, int gameCount);

        /// <summary>
        /// Ctor
        /// </summary>
        public frmLoadPGNGames() {
            InitializeComponent();
            m_fileName = "";
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="fileName"> File name to be loaded</param>
        public frmLoadPGNGames(string fileName) : this() {
            InitializeComponent();
            m_fileName   = fileName;
            Loaded      += PGNParsing_Loaded;
            Unloaded    += PGNParsing_Unloaded;
        }

        /// <summary>
        /// Called when the windows is loaded
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        private void PGNParsing_Loaded(object sender, RoutedEventArgs e) {
            ProgressBar.Start();
            StartProcessing();
        }

        /// <summary>
        /// Called when the windows is closing
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        private void PGNParsing_Unloaded(object sender, RoutedEventArgs e) {
            ProgressBar.Stop();
        }

        /// <summary>
        /// List of PGN games read from the file
        /// </summary>
        public List<PgnGame>? PGNGames { get; private set; }

        /// <summary>
        /// PGN Parser
        /// </summary>
        public PgnParser? PGNParser { get; private set; }

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
                    ctlStep.Content                 = $"0 / {gameCount} mb";
                    break;
                case ParsingPhase.Finished:
                    ctlPhase.Content                = "Done";
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
                ctlStep.Content = $"{gameDone} / {gameCount} mb";
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
            frmLoadPGNGames     frm;
            delProgressCallBack del;

            frm = (frmLoadPGNGames)cookie!;
            del = frm.WndCallBack;
            frm.Dispatcher.Invoke(del, System.Windows.Threading.DispatcherPriority.Normal, new object[] { phase, fileIndex, fileCount, fileName! /*can be null, compiler complain*/, gameProcessed, gameCount });
        }

        /// <summary>
        /// Load the PGN games from the specified file
        /// </summary>
        /// <returns></returns>
        private bool LoadPGN() {
            bool    retVal;
            int     totalSkipped = 0;

            try {
                TotalTruncated  = 0;
                Error           = null;
                m_phase         = ParsingPhase.None;
                PGNParser       = new PgnParser(isDiagnoseOn: false);
                retVal          = PGNParser.InitFromFile(m_fileName);
                if (retVal) {
                    PGNGames = PGNParser.GetAllRawPGN(getAttrList: true,
                                                      getMoveList: false,
                                                      out totalSkipped,
                                                      (cookie, phase, fileIndex, fileCount, fileName, gameProcessed, gameCount) => { ProgressCallBack(cookie, phase, fileIndex, fileCount, fileName, gameProcessed, gameCount); },
                                                      this);
                    retVal    = PGNGames != null;
                }
                TotalSkipped = totalSkipped;
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
                retVal = false;
            }
            m_result  = retVal;
            ProgressCallBack(this, ParsingPhase.Finished, fileIndex: 0, fileCount: 0, fileName: null, gameProcessed: 0, gameCount: 0);
            return(retVal);
        }

        /// <summary>
        /// Start the job
        /// </summary>
        private void StartProcessing() => m_task = Task<bool>.Factory.StartNew(() => { return(LoadPGN()); });
    }
}
