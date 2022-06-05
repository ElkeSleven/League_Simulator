
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

using LeagueLibrary.DataAccess;
using Microsoft.Win32;
using System.IO;
using Path = System.IO.Path;





namespace LeagueSimulator2._0
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

        private List<string> positionsList = new List<string>() { "sup", "mid", "bot", "jung", "top" };


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulComboBoxPositions();
        }
        private void VulComboBoxPositions()
        {
            foreach (var pos in positionsList)
            {
                ComboBoxPositions.Items.Add(pos);     // FROM: L:29  private List<string> positionsList = new List<string>() { "sup", "mid", "bot", "jung", "top" };  
            }
        }

        private void LaadChampionDataButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "csv"); /// csv file staat in debug 
                                                                                         /// C:\Users\elkes\OneDrive\Desktop\Semester 2\LeagueSim\LeagueSimulator\bin\Debug\csv
            try
            {
                if (ofd.ShowDialog() == true)   /// opent de verkenner 
                {
                    ChampionsData.LoadCSV(ofd.FileName);   // TO: 'ChampionData' L18  ChampionData.LoadCSV
                    DataGridChampions.ItemsSource = ChampionsData.GetDataViewChampions(); // vult het DataGrid op de xaml "DataGridChampions"
                                                                                         // TO:'ChampionData' L70      return DataTableChampions.AsDataView();
                    CheckBoxLaadChamionData.IsChecked = true; // CheckBox op de xaml word aangevinkt 
                   // EnableTabsEnDataGridAlsDataGeladen();     // TO: L84 kijkt als bijde CkeckBox's zijn aangevink 
                                                              // kijkt als bijde csv files zijn geladen
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);   // *foute format  *foute file   *fout bij het uitlezen 
            }





        }
        private void LaadAbilityDataButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EnableTabsEnDataGridAlsDataGeladen()
        {

        }
        private void ComboBoxPositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void DataGridChampions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void BestToWorstButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
