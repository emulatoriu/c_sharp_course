using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SrcChess2.FICSInterface {
    /// <summary>
    /// Interaction logic for frmConnectToFICS.xaml
    /// </summary>
    public partial class frmConnectToFICS : Window {
        /// <summary>Main chess control</summary>
        private readonly ChessBoardControl? m_mainCtl;
        /// <summary>Connection to the chess server</summary>
        private FICSConnection?             m_conn;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="connectionSetting">    Connection setting</param>
        /// <param name="mainCtl">              Main chessboard control</param>
        public frmConnectToFICS(ChessBoardControl? mainCtl, FICSConnectionSetting connectionSetting) {
            InitializeComponent();
            m_mainCtl           = mainCtl;
            ConnectionSetting   = connectionSetting;
            HostName            = connectionSetting.HostName;
            PortNumber          = connectionSetting.HostPort;
            UserName            = connectionSetting.UserName;
            Password            = "";
            IsAnonymous         = string.Compare(connectionSetting.UserName, "guest", true) == 0;
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public frmConnectToFICS() : this(mainCtl: null, new FICSConnectionSetting("", -1, "")) {}

        /// <summary>
        /// Setting for connecting to the FICS server
        /// </summary>
        public FICSConnectionSetting ConnectionSetting { get; private set; }

        /// <summary>
        /// Server Host Name
        /// </summary>
        public string HostName {
            get => textBoxServerName.Text.Trim();
            set => textBoxServerName.Text = value;
        }

        /// <summary>
        /// Host port number
        /// </summary>
        public int PortNumber {
            get {

                if (!Int32.TryParse(textBoxServerPort.Text.Trim(), out int retVal)) {
                    retVal = -1;
                }
                return (retVal);
            }
            set => textBoxServerPort.Text = value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Enable/disable the login info
        /// </summary>
        /// <param name="isEnable"> true to enable, false to disable</param>
        private void EnableLoginInfo(bool isEnable) {
            textBoxUserName.IsEnabled   = isEnable;
            textBoxPassword.IsEnabled   = isEnable;
        }

        /// <summary>
        /// Return if the connection use an anonymous login
        /// </summary>
        public bool IsAnonymous {
            get => radioAnonymous.IsChecked == true;
            set {
                if (value) {
                    radioAnonymous.IsChecked = true;
                    EnableLoginInfo(isEnable: false);
                } else {
                    radioRated.IsChecked = true;
                    EnableLoginInfo(isEnable: true);
                }
            }
        }

        /// <summary>
        /// Gets the user name
        /// </summary>
        public string UserName {
            get => IsAnonymous ? "Guest" : textBoxUserName.Text.Trim();
            set => textBoxUserName.Text = value;
        }

        /// <summary>
        /// User password
        /// </summary>
        public string Password {
            private get => IsAnonymous ? "" : textBoxPassword.Password.Trim();
            set => textBoxPassword.Password = value;
        }

        /// <summary>
        /// Connection to the FICS Chess Server
        /// </summary>
        public FICSConnection? Connection => m_conn;

        /// <summary>
        /// Update the state of the OK button
        /// </summary>
        private void UpdateButtonState() {
            bool    isEnabled;

            isEnabled   = (!String.IsNullOrEmpty(HostName) && PortNumber >= 0) &&
                           (IsAnonymous || (!String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(Password)));
            butOk.IsEnabled = isEnabled;
        }

        /// <summary>
        /// Called when a textbox content change
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event argument</param>
        private void textBox_TextChanged(object sender, TextChangedEventArgs e) => UpdateButtonState();

        /// <summary>
        /// Called when a password content change
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event argument</param>
        private void textBoxPassword_PasswordChanged(object sender, RoutedEventArgs e) => UpdateButtonState();

        /// <summary>
        /// Called when Radio button is pressed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event argument</param>
        private void radio_Checked(object sender, RoutedEventArgs e) {
            EnableLoginInfo(radioRated.IsChecked == true);
            UpdateButtonState();
        }

        /// <summary>
        /// Called when connection has succeed or failed
        /// </summary>
        /// <param name="succeed">  true if succeed</param>
        /// <param name="conn">     Connection if any</param>
        /// <param name="errTxt">   Error if any</param>
        private void ConnectionDone(bool succeed, FICSConnection? conn, string? errTxt) {
            ProgressBar.Stop();
            ProgressBar.Visibility = Visibility.Hidden;
            if (succeed) {
                m_conn       = conn;
                MessageBox.Show("Connected to FICS Server");
                DialogResult = true;
            } else {
                MessageBox.Show(errTxt!);
                butOk.IsEnabled     = true;
                butCancel.IsEnabled = true;

            }
        }

        /// <summary>
        /// Try to connect to the server
        /// </summary>
        /// <param name="hostName">     Host name</param>
        /// <param name="portNumber">   Port number</param>
        /// <param name="userName">     User name</param>
        /// <param name="password">     Password</param>
        private void InitializeConnection(string hostName, int portNumber, string userName, string password) {
            FICSConnection  conn;

            ConnectionSetting.HostName = hostName;
            ConnectionSetting.HostPort  = portNumber;
            ConnectionSetting.Anonymous = String.Compare(userName, "guest", true) == 0;
            ConnectionSetting.UserName  = userName;
            conn                        = new FICSConnection(m_mainCtl!, ConnectionSetting);
            if (!conn.Login(password, 10, out string? errTxt)) {
                conn.Dispose();
                Dispatcher.Invoke((Action)(() => {ConnectionDone(succeed: false, conn: null, errTxt); }));
            } else {
                Dispatcher.Invoke((Action)(() => {ConnectionDone(succeed: true,  conn, errTxt: null); }));
            }
        }

        /// <summary>
        /// Called when a Ok button is pressed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event argument</param>
        private void butOk_Click(object sender, RoutedEventArgs e) {
            string  hostName;
            int     portNumber;
            string  userName;
            string  password;

            hostName                = HostName;
            portNumber              = PortNumber;
            userName                = UserName;
            password                = Password;
            ProgressBar.Visibility  = Visibility.Visible;
            ProgressBar.Start();
            butOk.IsEnabled         = false;
            butCancel.IsEnabled     = false;
            System.Threading.Tasks.Task.Factory.StartNew(() => {  InitializeConnection(hostName, portNumber, userName, password); });
        }

        /// <summary>
        /// Called when Cancel button is pressed
        /// </summary>
        /// <param name="sender">   Sender object</param>
        /// <param name="e">        Event argument</param>
        private void butCancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;

    }
}
