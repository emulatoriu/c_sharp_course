using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace WPFandDataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person person { get; set; } = new Person { Name = "Mr. Banana", Age = 26 };
        List<Person> listOfPers= new List<Person>();
        static SqlConnection connection;


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = person;
            //person.Age = 27;
            //TB_PersonName_OneWayToSource.Text = person.Name; // needed since this text box is configured with the mode one way to source and does not get initialized with the context
            //person.Age = 44;
            string connectionString = @"Data Source=EMU\SQLEXPRESS;Initial Catalog=Sport;Integrated Security=True; MultipleActiveResultSets=true";
            connection =
            new SqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            // Bind Data to listbox first way
            //SqlDataReader sqlDR = makeDBSelectNoWhere("*", "Teilnehmer");

            //List<string> alleTeilnehmer = new List<string>();
            //while(sqlDR.Read())
            //{
            //    alleTeilnehmer.Add(sqlDR["Vorname"].ToString() + " " + sqlDR["Nachname"].ToString());                
            //}
            //Meine_DBDaten.ItemsSource = alleTeilnehmer;
            //((Image)this.FindName("Profilepicture")).Source =


            // Bind Data to listbox second way
            DataSet ds = makeDBSelectNoWhereDataSet("*", "Spieler");
            Meine_DBDaten.ItemsSource = ds.Tables[0].AsDataView();

            //TB_PersonName_FromDB.Text = ds.Tables[0].Rows[0][1].ToString(); // Take first name value to try            
            //listOfPers.Add(person);
            //listOfPers.Add(person);
            //Meine_DBDaten.ItemsSource = listOfPers;
            //this.DataContext = listOfPers;

        }

        public static DataSet makeDBSelectNoWhereDataSet(string cols, string table)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(
            $"SELECT {cols} FROM {table}", connection);
            adapter.Fill(ds);

            return ds;
        }

        public static SqlDataReader makeDBSelectNoWhere(string cols, string table)
        {
            string queryString =
            $"SELECT {cols} FROM {table}";
            SqlCommand command = new SqlCommand(queryString, connection);
            return command.ExecuteReader();
        }

        private void ChangePers_Click(object sender, RoutedEventArgs e)
        {
            // Next line destroys the binding of the textbox!!!!
            //((TextBox)this.FindName("TB_PersonName")).Text = "Mrs. Strawberry";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);

                Profilepicture.Source = new BitmapImage(fileUri);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(nameof(person.Name) + "=" + person.Name);
            //person.Name = TB_PersonName_TwoWay.Text;            

            //BindingExpression bindingExpression = BindingOperations.GetBindingExpression(TB_PersonName_TwoWay, TextBox.TextProperty);
            //bindingExpression?.UpdateSource();
            //if(bindingExpression != null)
            //{
            //    bindingExpression.UpdateSource();
            //}
        }
    }

    public class Person : INotifyPropertyChanged
    {
        //public Person person;        
        private string nameValue;

        public string Name
        {
            get { return nameValue; }
            set { 
                nameValue = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private double ageValue;

        public double Age
        {
            get { return ageValue; }

            set
            {
                if (value != ageValue)
                {
                    ageValue = value;
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
