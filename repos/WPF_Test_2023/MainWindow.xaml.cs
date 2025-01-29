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

namespace WPF_Test_2023
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
            //MessageBox.Show("Servus");
            
            //MessageBox.Show(sender.ToString());
            if(e.OriginalSource is Button)
            {
                MessageBox.Show("Button");
                Name.Text = "yes";
            }
            else
            {
                MessageBox.Show("Nicht Button");
            }

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Rectangle)
            {
                MessageBox.Show("Rectangel");
            }
            else
            {
                MessageBox.Show("Nicht Rectangle");
            }

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if((bool)((CheckBox)sender).IsChecked)
            {
                Name.Text="check";
            }
            else
            {
                Name.Text = "unchecked";
            }
        }
    }
}
