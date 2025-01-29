using System.Windows;

namespace SrcChess2 {
    /// <summary>
    /// Pickup Game Parameter from the player
    /// </summary>
    public partial class frmGameParameter : Window {
        /// <summary>Parent Window</summary>
        private readonly MainWindow?    m_parentWindow;
        /// <summary>Search mode</summary>
        private SettingSearchMode?      m_settingSearchMode;


        /// <summary>
        /// Class Ctor
        /// </summary>
        public frmGameParameter() => InitializeComponent();

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="parent">               Parent Window</param>
        /// <param name="settingSearchMode">    Search mode</param>
        private frmGameParameter(MainWindow parent, SettingSearchMode settingSearchMode) : this() {
            m_parentWindow      = parent;
            m_settingSearchMode = settingSearchMode;
            switch(m_parentWindow.PlayingMode) {
            case MainWindow.MainPlayingMode.DesignMode:
                throw new System.ApplicationException("Must not be called in design mode.");
            case MainWindow.MainPlayingMode.ComputerPlayWhite:
            case MainWindow.MainPlayingMode.ComputerPlayBlack:
                radioButtonPlayerAgainstComputer.IsChecked = true;
                radioButtonPlayerAgainstComputer.Focus();
                break;
            case MainWindow.MainPlayingMode.PlayerAgainstPlayer:
                radioButtonPlayerAgainstPlayer.IsChecked = true;
                radioButtonPlayerAgainstPlayer.Focus();
                break;
            case MainWindow.MainPlayingMode.ComputerPlayBoth:
                radioButtonComputerAgainstComputer.IsChecked = true;
                radioButtonComputerAgainstComputer.Focus();
                break;
            }
            if (m_parentWindow.PlayingMode == MainWindow.MainPlayingMode.ComputerPlayBlack) { 
                radioButtonComputerPlayBlack.IsChecked = true;
            } else {
                radioButtonComputerPlayWhite.IsChecked = true;
            }
            switch (m_settingSearchMode.DifficultyLevel) {
            case SettingSearchMode.SettingDifficultyLevel.Manual:
                radioButtonLevelManual.IsChecked = true;
                break;
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
                radioButtonLevel1.IsChecked = true;
                break;
            }
            CheckState();
            radioButtonLevel1.ToolTip       = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.VeryEasy);
            radioButtonLevel2.ToolTip       = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.Easy);
            radioButtonLevel3.ToolTip       = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.Intermediate);
            radioButtonLevel4.ToolTip       = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.Hard);
            radioButtonLevel5.ToolTip       = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.VeryHard);
            radioButtonLevelManual.ToolTip  = SettingSearchMode.ModeTooltip(SettingSearchMode.SettingDifficultyLevel.Manual);
        }

        /// <summary>
        /// Check the state of the group box
        /// </summary>
        private void CheckState() => groupBoxComputerPlay.IsEnabled = radioButtonPlayerAgainstComputer.IsChecked!.Value;

        /// <summary>
        /// Called to accept the form
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        private void butOk_Click(object sender, RoutedEventArgs e) {
            if (radioButtonPlayerAgainstComputer.IsChecked == true) {
                m_parentWindow!.PlayingMode = (radioButtonComputerPlayBlack.IsChecked == true) ? MainWindow.MainPlayingMode.ComputerPlayBlack : MainWindow.MainPlayingMode.ComputerPlayWhite;
            } else if (radioButtonPlayerAgainstPlayer.IsChecked == true) {
                m_parentWindow!.PlayingMode = MainWindow.MainPlayingMode.PlayerAgainstPlayer;
            } else if (radioButtonComputerAgainstComputer.IsChecked == true) {
                m_parentWindow!.PlayingMode = MainWindow.MainPlayingMode.ComputerPlayBoth;
            }
            DialogResult = true;
            Close();
        }

        /// <summary>
        /// Called when the radio button value is changed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event arguments</param>
        private void radioButtonOpponent_CheckedChanged(object sender, RoutedEventArgs e) => CheckState();

        /// <summary>
        /// Ask for the game parameter
        /// </summary>
        /// <param name="parent">               Parent window</param>
        /// <param name="settingSearchMode">    Search mode</param>
        /// <returns>
        /// true if succeed
        /// </returns>
        public static bool AskGameParameter(MainWindow parent, SettingSearchMode settingSearchMode) {
            bool                retVal;
            frmGameParameter    frm;

            frm = new frmGameParameter(parent, settingSearchMode) {
                Owner = parent
            };
            retVal     = (frm.ShowDialog() == true);
            if (retVal) {
                if (frm.radioButtonLevel1.IsChecked == true) {
                    settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.VeryEasy;
                } else if (frm.radioButtonLevel2.IsChecked == true) {
                    settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.Easy;
                } else if (frm.radioButtonLevel3.IsChecked == true) {
                    settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.Intermediate;
                } else if (frm.radioButtonLevel4.IsChecked == true) {
                    settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.Hard;
                } else if (frm.radioButtonLevel5.IsChecked == true) {
                    settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.VeryHard;
                } else if (frm.radioButtonLevelManual.IsChecked == true) {
                    settingSearchMode.DifficultyLevel = SettingSearchMode.SettingDifficultyLevel.Manual;
                }
                frm.m_parentWindow!.m_chessCtl.SearchMode = settingSearchMode.GetSearchMode();
            }
            return(retVal);
        }
    } // Class frmGameParameter
} // Namespace
