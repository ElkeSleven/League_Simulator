using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using LeagueLibrary.DataAccess;
using Path = System.IO.Path;


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


        //** initialize datatable  ** datagrid vullen 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         
            //MatchData.InitializeDataTableMatches();                         // TO: 'MatchData'

            DataGridMatches.ItemsSource = MatchData.GetDataViewMatches();   // vult het DataGrid op de xaml "DataGridMatches"
                                                                            // TO: 'MatchData'  return 
        }


        //** Path doorgeven   * opslaan als XML
        private void ExportToXMLButton_Click(object sender, RoutedEventArgs e)
        {
            string pad = Path.Combine(Directory.GetCurrentDirectory());

                MatchData.ExportToXML(pad);


        }

    } 
}
