
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
using System.Data;

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
        
        /***********/// Loading 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            VulComboBoxPositions();
            MatchData.InitializeDataTableMatches();
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
                    GetDataViewChampions();                                                     /// vult het DataGrid op de xaml "DataGridChampions"
                                                                                                /// TO:'ChampionData'    return DataTableChampions.AsDataView();

                    CheckBoxLaadChamionData.IsChecked = true  ;                                 /// CheckBox op de xaml word aangevinkt 
                    EnableTabsEnDataGridAlsDataGeladen();                                       /// TO: kijkt als bijde CkeckBox's zijn aangevink 
                                                                                                /// kijkt als bijde csv files zijn geladen
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);                                             /// *foute format  *foute file   *fout bij het uitlezen 
            }
        }


        /*********/// verkennner word geapend en de file word doorgegeven aan Data.LoadCSV 
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

                    CheckBoxLaadAbilityData.IsChecked = true;                                   /// CheckBox op de xaml word aangevinkt 
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



        /**********/// activerd de button in de menu 
        private void EnableTabsEnDataGridAlsDataGeladen()
        {
            if (CheckBoxLaadAbilityData.IsChecked == true && CheckBoxLaadChamionData.IsChecked == true) // kijkt als bijde csv files geladen zijn 
            {
                DataGridChampions.IsEnabled = true;  // zet DataGridChampions_SelectionChanged op active
                simuleerMatch.IsEnabled = true; // zet de menu button op active 
                overzichtMatches.IsEnabled = true;// zet de menu button op active 
            }
        }





        //AsDataView *GetDataViewChampions
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            GetDataViewChampions();
        }
    
        //**AsDataView **DataGridChampions.ItemsSource    *ResetButton_Click   *LaadChampionDataButton_Click
        private void GetDataViewChampions()
        {
            DataGridChampions.ItemsSource = ChampionsData.GetDataViewChampions();       /// vult het DataGrid op de xaml "DataGridChampions"
                                                                                        /// TO:'ChampionData'    return DataTableChampions.AsDataView();
        }




        //** SelectionChanged **Sort  ***** sorteren op positions  { "sup", "mid", "bot", "jung", "top" };  
        private void ComboBoxPositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxPositions.SelectedItem != null) // kijkt als er een item is gesilecteerd   { "sup", "mid", "bot", "jung", "top" };  
            {

                DataGridChampions.ItemsSource =
                    ChampionsData.GetDataViewChampionsByPosition(ComboBoxPositions.SelectedItem.ToString()); // TO: 'ChampionData'
            }
        }
              
        //** SelectionChanged ***** img naam en title ophalen uit de selected row 
        private void DataGridChampions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridChampions.SelectedItem != null)
            {
                try
                {
                    DataRowView drv = (DataRowView)DataGridChampions.CurrentCell.Item;                                                   // selected row  
                    
                    string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + drv.Row.ItemArray[7]);                     // ItemArray[7]   imageSorce
                    
                    ImageChampion.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));                                   // FILL: img

                    TextBlockChampionTitle.Text = drv.Row.ItemArray[0] + " " + drv.Row.ItemArray[1];                                     // FILL ; textbox met naam en title
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);                                                                                   //* als het pad niet gevonden word   
                }
            }

        }



        //**Sort ***** sorteren op ReleaseYear , ChampionPosition2 , ChampionPosition , ChampionName
        private void BestToWorstButton_Click(object sender, RoutedEventArgs e)
        {
            DataGridChampions.ItemsSource = ChampionsData.GetDataViewChampionsBestToWorst();   // vult het DataGrid op de xaml "DataGridChampions"
                                                                                               // TO: 'ChampionData' 
        }
        /*  tip 
         *  descending : van nieuw naar oud  , van groot naar klein 
         *  a
         *  
         *  
         *  
         *  
         *  
         *  
         */


        //** open wpf   **** naar Overzicht Match ( *datatabele  -match -winner -code  , *als xml opslaan 
        private void overzichtMatches_Click(object sender, RoutedEventArgs e)
        {
            OverzichtMatches oM = new OverzichtMatches();
            oM.ShowDialog();
        }


        // open wpf   **** naar Simuleer Match ( *random match genereren 3v3 of 5v5  , *random winner ,  *:hover -img -name -title ,  *
        private void simuleerMatch_Click(object sender, RoutedEventArgs e)
        {
            SimuleerMatch sM = new SimuleerMatch();
            sM.ShowDialog();
        }
    }
}
