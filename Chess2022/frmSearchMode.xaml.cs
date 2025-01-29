using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace SrcChess2 {
    /// <summary>
    /// Ask user about search mode
    /// </summary>
    public partial class frmSearchMode : Window {
        /// <summary>Source search mode object</summary>
        private readonly SettingSearchMode?     m_settingSearchMode;
        /// <summary>Board evaluation utility class</summary>
        private readonly BoardEvaluationUtil?   m_boardEvalUtil;

        /// <summary>
        /// Class Ctor
        /// </summary>
        public frmSearchMode() => InitializeComponent();

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="settingSearchMode">Actual search mode</param>
        /// <param name="boardEvalUtil">    Board Evaluation list</param>
        public frmSearchMode(SettingSearchMode settingSearchMode, BoardEvaluationUtil boardEvalUtil) : this() {
            int     pos;
            
            m_settingSearchMode = settingSearchMode;
            m_boardEvalUtil     = boardEvalUtil;
            foreach (IBoardEvaluation boardEval in m_boardEvalUtil.BoardEvaluators) {
                pos = comboBoxWhiteBEval.Items.Add(boardEval.Name);
                if (settingSearchMode.WhiteBoardEvaluation == boardEval) {
                    comboBoxWhiteBEval.SelectedIndex = pos;
                }
                pos = comboBoxBlackBEval.Items.Add(boardEval.Name);
                if (settingSearchMode.BlackBoardEvaluation == boardEval) {
                    comboBoxBlackBEval.SelectedIndex = pos;
                }
            }
            checkBoxTransTable.IsChecked    = ((settingSearchMode.Option & SearchMode.Option.UseTransTable) != 0);
            if (settingSearchMode.ThreadingMode == SearchMode.ThreadingMode.OnePerProcessorForSearch) {
                radioButtonOnePerProc.IsChecked = true;
            } else if (settingSearchMode.ThreadingMode == SearchMode.ThreadingMode.DifferentThreadForSearch) {
                radioButtonOneForUI.IsChecked   = true;
            } else {
                radioButtonNoThread.IsChecked   = true;
            }
            if (settingSearchMode.BookMode == SettingSearchMode.SettingBookMode.NoBook) {
                radioButtonNoBook.IsChecked     = true;
            } else if (settingSearchMode.BookMode == SettingSearchMode.SettingBookMode.Unrated) {
                radioButtonUnrated.IsChecked    = true;
            } else {
                radioButtonELO2500.IsChecked    = true;
            }
            if ((settingSearchMode.Option & SearchMode.Option.UseAlphaBeta) != 0) {
                radioButtonAlphaBeta.IsChecked  = true;
            } else {
                radioButtonMinMax.IsChecked     = true;
                checkBoxTransTable.IsEnabled    = false;
            }
            if (settingSearchMode.SearchDepth == 0) {
                radioButtonAvgTime.IsChecked    = true;
                textBoxTimeInSec.Text           = settingSearchMode.TimeOutInSec.ToString();
                plyCount.Value                  = 6;
            } else {
                if ((settingSearchMode.Option & SearchMode.Option.UseIterativeDepthSearch) == SearchMode.Option.UseIterativeDepthSearch) {
                    radioButtonFixDepthIterative.IsChecked = true;
                } else {
                    radioButtonFixDepth.IsChecked = true;
                }
                plyCount.Value              = settingSearchMode.SearchDepth;
                textBoxTimeInSec.Text       = "15";
            }
            plyCount2.Content   = plyCount.Value.ToString();
            switch(settingSearchMode.RandomMode) {
            case SearchMode.RandomMode.Off:
                radioButtonRndOff.IsChecked     = true;
                break;
            case SearchMode.RandomMode.OnRepetitive:
                radioButtonRndOnRep.IsChecked   = true;
                break;
            default:
                radioButtonRndOn.IsChecked      = true;
                break;
            }
            textBoxTransSize.Text  = (settingSearchMode.TransTableEntryCount / 1000000 * 32).ToString(CultureInfo.InvariantCulture);    // Roughly 32 bytes / entry
            plyCount.ValueChanged += new RoutedPropertyChangedEventHandler<double>(plyCount_ValueChanged);
            switch (settingSearchMode.DifficultyLevel) {
            case SettingSearchMode.SettingDifficultyLevel.VeryEasy:
                radioButtonLevel1.IsChecked = true;
                break;
            case SettingSearchMode.SettingDifficultyLevel.Easy:
                radioButtonLevel2.IsChecked = true;
                break;
            case SettingSearchMode.SettingDifficultyLevel.Intermediate:
                radioButtonLevel3.IsChecked = true;
                break;
            case SettingSearchMode.SettingDifficultyLevel.Hard:
                radioButtonLevel4.IsChecked = true;
                break;
            case SettingSearchMode.SettingDifficultyLevel.VeryHard:
                radioButtonLevel5.IsChecked = true;
                break;
            default:
                radioButtonLevelManual.IsChecked = true;
                break;
            }
            radioButtonLevel1.ToolTip       = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.VeryEasy);
            radioButtonLevel2.ToolTip       = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.Easy);
            radioButtonLevel3.ToolTip       = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.Intermediate);
            radioButtonLevel4.ToolTip       = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.Hard);
            radioButtonLevel5.ToolTip       = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.VeryHard);
            radioButtonLevelManual.ToolTip  = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.Manual);
        }

        /// <summary>
        /// Called when the ply count is changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        private void plyCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => plyCount2.Content = plyCount.Value.ToString();

        /// <summary>
        /// Called when one of the radioButtonLevel radio button has been changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        private void radioButtonLevel_CheckedChanged(object sender, RoutedEventArgs e) => gridManualSetting.IsEnabled = (radioButtonLevelManual.IsChecked == true);

        /// <summary>
        /// Called when radioButtonAlphaBeta checked state has been changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        private void radioButtonAlphaBeta_CheckedChanged(object sender, RoutedEventArgs e) => checkBoxTransTable.IsEnabled = radioButtonAlphaBeta.IsChecked!.Value;

        /// <summary>
        /// Set the plyCount/avgTime control state
        /// </summary>
        private void SetPlyAvgTimeState() {
            if (radioButtonAvgTime.IsChecked == true) {
                plyCount.IsEnabled         = false;
                labelNumberOfPly.IsEnabled = false;
                textBoxTimeInSec.IsEnabled = true;
                labelAvgTime.IsEnabled     = true;
            } else {
                plyCount.IsEnabled         = true;
                labelNumberOfPly.IsEnabled = true;
                textBoxTimeInSec.IsEnabled = false;
                labelAvgTime.IsEnabled     = false;
            }
        }

        /// <summary>
        /// Called when radioButtonFixDepth checked state has been changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        private void radioButtonSearchType_CheckedChanged(object sender, RoutedEventArgs e) => SetPlyAvgTimeState();

        /// <summary>
        /// Called when the time in second textbox changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        private void textBoxTimeInSec_TextChanged(object sender, TextChangedEventArgs e)
            => butOk.IsEnabled = (Int32.TryParse(textBoxTimeInSec.Text, out int val) && val > 0 && val < 999);

        /// <summary>
        /// Called when the transposition table size is changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        private void textBoxTransSize_TextChanged(object sender, TextChangedEventArgs e)
            => butOk.IsEnabled = (Int32.TryParse(textBoxTransSize.Text, out int val) && val > 4 && val < 1000);

        /// <summary>
        /// Update the SearchMode object
        /// </summary>
        public void UpdateSearchMode() {
            int                 transTableSize;
            IBoardEvaluation?   boardEval;

            m_settingSearchMode!.Option = (radioButtonAlphaBeta.IsChecked == true) ? SearchMode.Option.UseAlphaBeta : SearchMode.Option.UseMinMax;
            if (radioButtonLevel1.IsChecked == true) {
                m_settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.VeryEasy;
            } else if (radioButtonLevel2.IsChecked == true) {
                m_settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.Easy;
            } else if (radioButtonLevel3.IsChecked == true) {
                m_settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.Intermediate;
            } else if (radioButtonLevel4.IsChecked == true) {
                m_settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.Hard;
            } else if (radioButtonLevel5.IsChecked == true) {
                m_settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.VeryHard;
            } else {
                m_settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.Manual;
            }
            if (radioButtonNoBook.IsChecked == true) {
                m_settingSearchMode.BookMode = SettingSearchMode.SettingBookMode.NoBook;
            } else if (radioButtonUnrated.IsChecked == true) {
                m_settingSearchMode.BookMode = SettingSearchMode.SettingBookMode.Unrated;
            } else {
                m_settingSearchMode.BookMode = SettingSearchMode.SettingBookMode.ELOGT2500;
            }
            if (checkBoxTransTable.IsChecked == true) {
                m_settingSearchMode.Option |= SearchMode.Option.UseTransTable;
            }
            if (radioButtonOnePerProc.IsChecked == true) {
                m_settingSearchMode.ThreadingMode = SearchMode.ThreadingMode.OnePerProcessorForSearch;
            } else if (radioButtonOneForUI.IsChecked == true) {
                m_settingSearchMode.ThreadingMode = SearchMode.ThreadingMode.DifferentThreadForSearch;
            } else {
                m_settingSearchMode.ThreadingMode = SearchMode.ThreadingMode.Off;
            }
            if (radioButtonAvgTime.IsChecked == true) {
                m_settingSearchMode.SearchDepth  = 0;
                m_settingSearchMode.TimeOutInSec = Int32.Parse(textBoxTimeInSec.Text);
            } else {
                m_settingSearchMode.SearchDepth  = (int)plyCount.Value;
                m_settingSearchMode.TimeOutInSec = 0;
                if (radioButtonFixDepthIterative.IsChecked == true) {
                    m_settingSearchMode.Option |= SearchMode.Option.UseIterativeDepthSearch;
                }
            }
            if (radioButtonRndOff.IsChecked == true) {
                m_settingSearchMode.RandomMode = SearchMode.RandomMode.Off;
            } else if (radioButtonRndOnRep.IsChecked == true) {
                m_settingSearchMode.RandomMode = SearchMode.RandomMode.OnRepetitive;
            } else {
                m_settingSearchMode.RandomMode = SearchMode.RandomMode.On;
            }
            transTableSize                           = Int32.Parse(textBoxTransSize.Text);
            m_settingSearchMode.TransTableEntryCount = transTableSize / 32 * 1000000;
            boardEval                                = m_boardEvalUtil!.FindBoardEvaluator(comboBoxWhiteBEval.SelectedItem.ToString());
            if (boardEval == null) {
                boardEval = m_boardEvalUtil.BoardEvaluators[0];
            }
            m_settingSearchMode.WhiteBoardEvaluation    = boardEval;
            boardEval                                   = m_boardEvalUtil.FindBoardEvaluator(comboBoxBlackBEval.SelectedItem.ToString());
            if (boardEval == null) {
                boardEval = m_boardEvalUtil.BoardEvaluators[0];
            }
            m_settingSearchMode.BlackBoardEvaluation    = boardEval;
        }

        /// <summary>
        /// Called when the Ok button is clicked
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event parameter</param>
        private void butOk_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
            Close();
        }
    } // Class frmSearchMode
} // Namespace
