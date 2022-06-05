
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
        /************///
        private List<string> positionsList = new List<string>() { "sup", "mid", "bot", "jung", "top" };
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulComboBoxPositions();
        }
       
        /***********/// combobox word gevult met de waarde uit de list positionsList
        private void VulComboBoxPositions()
        {
            foreach (var pos in positionsList)
            {
                ComboBoxPositions.Items.Add(pos);     // FROM: L:29  private List<string> positionsList = new List<string>() { "sup", "mid", "bot", "jung", "top" };  
            }
        }
        
        /***********/// verkennner word geapend en de file word doorgegeven aan Data.LoadCSV 
        private void LaadChampionDataButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "csv");        /// csv file staat in debug 
                                                                                                /// ..\LeagueSim\LeagueSimulator\bin\Debug\csv
            try
            {
                if (ofd.ShowDialog() == true)                                                   /// opent de verkenner 
                {                                                                               
                    ChampionsData.LoadCSV(ofd.FileName);                                        /// TO: 'ChampionData'   ChampionData.LoadCSV
                    DataGridChampions.ItemsSource = ChampionsData.GetDataViewChampions();       /// vult het DataGrid op de xaml "DataGridChampions"
                                                                                                /// TO:'ChampionData'    return DataTableChampions.AsDataView();
                                                                                               
                    CheckBoxLaadChamionData.IsChecked = true  ;                                 /// CheckBox op de xaml word aangevinkt 
                   // EnableTabsEnDataGridAlsDataGeladen();                                     /// TO: kijkt als bijde CkeckBox's zijn aangevink 
                                                                                                /// kijkt als bijde csv files zijn geladen
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);                                             /// *foute format  *foute file   *fout bij het uitlezen 
            }





        }


        /******/// verkennner word geapend en de file word doorgegeven aan Data.LoadCSV 
        private void LaadAbilityDataButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();                  
            ofd.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "csv");        /// csv file staat in debug 
                                                                                                /// C:\Users\elkes\OneDrive\Desktop\Semester 2\LeagueSim\LeagueSimulator\bin\Debug\csv
            try
            {
                if (ofd.ShowDialog() == true)                                                   /// opent de verkenner 
                {
                    AbilityData.LoadCSV(ofd.FileName);                                          /// TO: 'AbilityData' 

                    CheckBoxLaadChamionData.IsChecked = true;                                   /// CheckBox op de xaml word aangevinkt 
                    EnableTabsEnDataGridAlsDataGeladen();                                       /// EnableTabsEnDataGridAlsDataGeladen();  
                                                                                                /// TO: kijkt als bijde CkeckBox's zijn aangevink 
                                                                                                /// kijkt als bijde csv files zijn geladen
                }   
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);                                              /// *foute format  *foute file   *fout bij het uitlezen 
            }
        }

        /********/// activerd de button in de menu 
        private void EnableTabsEnDataGridAlsDataGeladen()
        {
            if (CheckBoxLaadAbilityData.IsChecked == true && CheckBoxLaadChamionData.IsChecked == true) // kijkt als bijde csv files geladen zijn 
            {
                DataGridChampions.IsEnabled = true;  // zet DataGridChampions_SelectionChanged op active
                simuleerMatch.IsEnabled = true; // zet de menu button op active 
                overzichtMatches.IsEnabled = true;// zet de menu button op active 
            }
        }

        // sort
        private void ComboBoxPositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        // sort
        private void DataGridChampions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        // sort 
        private void BestToWorstButton_Click(object sender, RoutedEventArgs e)
        {

        }
        // 
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {

        }


        // open wpf
        private void overzichtMatches_Click(object sender, RoutedEventArgs e)
        {
            OverzichtMatches oM = new OverzichtMatches();
            oM.ShowDialog();
        }
        // open wpf
        private void simuleerMatch_Click(object sender, RoutedEventArgs e)
        {
            SimuleerMatch sM = new SimuleerMatch();
            sM.ShowDialog();
        }
    }
}
