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
using System.Windows.Shapes;
using LeagueLibrary.DataAccess;


namespace LeagueSimulator2._0
{
    /// <summary>
    /// Interaction logic for OverzichtMatches.xaml
    /// </summary>
    public partial class OverzichtMatches : Window
    {
        public OverzichtMatches()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // MatchData.InitializeDataTableMatches();                         // TO: 'MatchData'

            DataGridMatches.ItemsSource = MatchData.GetDataViewMatches();   // vult het DataGrid op de xaml "DataGridMatches"
                                                                            // TO: 'MatchData'  return 
        }



        private void ExportToXMLButton_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
