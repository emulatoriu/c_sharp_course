using System.Windows;

namespace SrcChess2 {
    /// <summary>Enter parameters for testing the board evaluation functions</summary>
    public partial class frmTestBoardEval : Window {
        /// <summary>Board evaluation utility</summary>
        BoardEvaluationUtil?    m_boardEvalUtil;
        /// <summary>Resulting search mode</summary>
        SearchMode?             m_searchMode;
        
        /// <summary>
        /// Class Ctor
        /// </summary>
        public frmTestBoardEval() => InitializeComponent();

        /// <summary>
        /// Class Ctor
        /// </summary>
        /// <param name="boardEvalUtil">        Board evaluation utility class</param>
        /// <param name="searchModeTemplate">   Search mode template</param>
        public frmTestBoardEval(BoardEvaluationUtil boardEvalUtil, SearchMode searchModeTemplate) : this() {
            m_searchMode        = new SearchMode(boardEvalUtil.BoardEvaluators[0],
                                                 boardEvalUtil.BoardEvaluators[0],
                                                 SearchMode.Option.UseAlphaBeta,
                                                 searchModeTemplate.m_threadingMode,
                                                 searchDepth: 4,
                                                 timeOutInSec: 0,
                                                 searchModeTemplate.m_randomMode,
                                                 playerBook: null,
                                                 computerBook: null,
                                                 transTableEntryCount: 0);
            foreach (IBoardEvaluation boardEval in boardEvalUtil.BoardEvaluators) {
                comboBoxWhiteBEval.Items.Add(boardEval.Name);
                comboBoxBlackBEval.Items.Add(boardEval.Name);
            }
            comboBoxWhiteBEval.SelectedIndex    = 0;
            comboBoxBlackBEval.SelectedIndex    = (comboBoxBlackBEval.Items.Count == 0) ? 0 : 1;
            m_boardEvalUtil                     = boardEvalUtil;
            plyCount2.Content                   = plyCount.Value.ToString();
            gameCount2.Content                  = gameCount.Value.ToString();
            plyCount.ValueChanged              += new RoutedPropertyChangedEventHandler<double>(plyCount_ValueChanged);
            gameCount.ValueChanged             += new RoutedPropertyChangedEventHandler<double>(gameCount_ValueChanged);
        }

        /// <summary>
        /// Called when game count changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        private void gameCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            => gameCount2.Content  = ((int)gameCount.Value).ToString();

        /// <summary>
        /// Called when ply count changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        private void plyCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            => plyCount2.Content   = plyCount.Value.ToString();

        /// <summary>
        /// Get the search mode
        /// </summary>
        public SearchMode SearchMode {
            get {
                IBoardEvaluation? boardEval;
                
                boardEval = m_boardEvalUtil!.FindBoardEvaluator(comboBoxWhiteBEval.SelectedItem.ToString());
                if (boardEval == null) {
                    boardEval = m_boardEvalUtil.BoardEvaluators[0];
                }
                m_searchMode!.m_whiteBoardEvaluation = boardEval;
                boardEval = m_boardEvalUtil.FindBoardEvaluator(comboBoxBlackBEval.SelectedItem.ToString());
                if (boardEval == null) {
                    boardEval = m_boardEvalUtil.BoardEvaluators[0];
                }
                m_searchMode.m_blackBoardEvaluation = boardEval;
                m_searchMode.m_searchDepth         = (int)plyCount.Value;
                return(m_searchMode);
            }
        }

        /// <summary>
        /// Get the number of games to test
        /// </summary>
        public int GameCount => (int)gameCount.Value;

        /// <summary>
        /// Called when the ok button is pressed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        private void butOk_Click(object sender, RoutedEventArgs e) {
            DialogResult    = true;
            Close();
        }
    }
}
