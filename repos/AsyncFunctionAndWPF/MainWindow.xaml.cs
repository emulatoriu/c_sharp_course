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

namespace AsyncFunctionAndWPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StarWarsApiClient apiClient;

        public MainWindow()
        {
            InitializeComponent();
            apiClient = new StarWarsApiClient();
        }

        private async void planetInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id;
                bool isNumber = int.TryParse(plaetID.Text, out id);
                Planet planet = await apiClient.GetPlanetAsync(isNumber ? id : 1);
                //or because I get a task returned
                //Planet planet = null;                
                //Task<Planet> planetTask = apiClient.GetPlanetAsync(isNumber ? id : 1);
                //await planetTask.ContinueWith(task =>
                //{
                //    if (task.Exception != null)
                //    {
                //        // Handle the exception
                //    }
                //    else
                //    {
                //        planet = task.Result;                                                
                //    }
                //});
                //MessageBox.Show("Servus");
                planetInfoTextBlock.Text = $"Name: {planet.Name}\nClimate: {planet.Climate}\nTerrain: {planet.Terrain}";
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung
            }
        }
    }
}
