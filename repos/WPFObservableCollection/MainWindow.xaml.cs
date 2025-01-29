using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace WPFObservableCollection
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    ///     

    public partial class MainWindow : Window
    {        

        public ObservableCollection<Employee> Employees { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Employees = new ObservableCollection<Employee>
            {
                new Employee { Name = "Obi-Wan", Age = 40 },
                new Employee { Name = "Anakin", Age = 25 },
                new Employee { Name = "Yoda", Age = 400 }
            };
            DataContext = this;
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employees.Add(new Employee { Name = "Mace", Age = 50 });            
        }

    }

}
