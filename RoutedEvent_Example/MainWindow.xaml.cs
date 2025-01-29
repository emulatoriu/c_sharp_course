using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoutedEvent_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt1.Text = "Button wurde geklickt";
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            txt2.Text = "Das Klick Event wurde zum Stack Panel weitergereicht (bubbled to StackPanel)";
            //e.Handled = true; // Event geht nicht mehr an das Window
        }
        private void Window_Click(object sender, RoutedEventArgs e)
        {
            txt3.Text = "Das Klick Event wurde zum Window weitergereicht";
        }

        private void WindowMouseDown(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mouse Pressed");
        }
        
    }
}
