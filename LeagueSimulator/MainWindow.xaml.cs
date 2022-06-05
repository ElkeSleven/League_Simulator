using LeagueClassLibrary.DataAccess;
using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LeagueClassLibrary.Entities;
using Path = System.IO.Path;

namespace LeagueSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> positionsList = new List<string>() { "sup", "mid", "bot", "jung", "top" };
        private Match currentMatch;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LaadChampionDataButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "csv");
            try
            {
                if (ofd.ShowDialog() == true)   /// opent de verkenner 
                {
                    ChampionData.LoadCSV(ofd.FileName);   // TO: L18 ChampionData.LoadCSV
                    DataGridChampions.ItemsSource = ChampionData.GetDataView();
                    CheckBoxLaadChamionData.IsChecked = true;
                    EnableTabsEnDataGridAlsDataGeladen();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EnableTabsEnDataGridAlsDataGeladen()
        {
            if (CheckBoxLaadAbilityData.IsChecked == true && CheckBoxLaadChamionData.IsChecked == true)
            {
                DataGridChampions.IsEnabled = true;
                TabItemSimuleerMatch.IsEnabled = true;
                TabItemOverzichtMatches.IsEnabled = true;

                MatchData.InitializeDataTableMatches();
                DataGridMatches.ItemsSource = MatchData.GetDataViewMatches();
            }
        }

        private void LaadAbilityDataButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "csv");
            try
            {
                if (ofd.ShowDialog() == true)
                {
                    AbilityData.LoadCSV(ofd.FileName);
                    CheckBoxLaadAbilityData.IsChecked = true;
                    EnableTabsEnDataGridAlsDataGeladen();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }


        private void ComboBoxPositions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxPositions.SelectedItem != null)
            {
                try
                {
                    DataGridChampions.ItemsSource =
                        ChampionData.GetDataViewChampionsByPosition(ComboBoxPositions.SelectedItem.ToString());
                }
                catch (Exception exception)
                {
                    ComboBoxPositions.SelectedIndex = -1;
                    MessageBox.Show(exception.Message);
                }

            }
        }

        private void BestToWorstButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridChampions.ItemsSource = ChampionData.GetDataViewChampionsBestToWorst();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridChampions.ItemsSource = ChampionData.GetDataView();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DataGridChampions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridChampions.SelectedItem != null)
            {
                try
                {
                    DataRowView drv = (DataRowView)DataGridChampions.CurrentCell.Item;
                    string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + drv.Row.ItemArray[7]);
                    ImageChampion.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));

                    TextBlockChampionTitle.Text = drv.Row.ItemArray[0] + " " + drv.Row.ItemArray[1];
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void LaadChampion(int indexChampion, int team)
        {
            if (currentMatch != null)
            {
                if (team == 1)
                {
                    if (indexChampion < currentMatch.Team1Champions.Count)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team1Champions[indexChampion].BannerSource);
                        ImageBanner.Source =
                            new BitmapImage(new Uri(path,
                                UriKind.Absolute));
                        TextBlockChampion.Text = currentMatch.Team1Champions[indexChampion].Title;
                        TextBlockClass.Text = currentMatch.Team1Champions[indexChampion].Class;
                        TextBlockCost.Text = currentMatch.Team1Champions[indexChampion].GetCost();
                        ListBoxChampionAbilities.Items.Clear();
                        foreach (var ability in currentMatch.Team1Champions[indexChampion].Abilities)
                        {
                            ListBoxChampionAbilities.Items.Add(ability);
                        }
                    }

                }
                else
                {
                    if (indexChampion < currentMatch.Team2Champions.Count)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team2Champions[indexChampion].BannerSource);
                        ImageBanner.Source =
                            new BitmapImage(new Uri(path,
                                UriKind.Absolute));
                        TextBlockChampion.Text = currentMatch.Team2Champions[indexChampion].Title;
                        TextBlockClass.Text = currentMatch.Team2Champions[indexChampion].Class;
                        TextBlockCost.Text = currentMatch.Team2Champions[indexChampion].GetCost();
                        ListBoxChampionAbilities.Items.Clear();
                        foreach (var ability in currentMatch.Team2Champions[indexChampion].Abilities)
                        {
                            ListBoxChampionAbilities.Items.Add(ability);
                        }
                    }
                }
            }
        }

        #region ImageIconChampion methodes
        private void ImageIconChampion1Team1_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(0, 1);
        }
        private void ImageIconChampion2Team1_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(1, 1);
        }
        private void ImageIconChampion3Team1_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(2, 1);
        }
        private void ImageIconChampion4Team1_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(3, 1);
        }
        private void ImageIconChampion5Team1_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(4, 1);
        }
        private void ImageIconChampion1Team2_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(0, 2);
        }
        private void ImageIconChampion2Team2_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(1, 2);
        }
        private void ImageIconChampion3Team2_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(2, 2);
        }
        private void ImageIconChampion4Team2_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(3, 2);
        }
        private void ImageIconChampion5Team2_MouseEnter(object sender, MouseEventArgs e)
        {
            LaadChampion(4, 2);
        }
        #endregion

        private void Genereer5v5Button_Click(object sender, RoutedEventArgs e)
        {
            string code = PasswordBoxMatchCode.Password;
            if (!string.IsNullOrEmpty(code))
            {
                if (MatchData.IsUniqueCode(code))
                {
                    currentMatch = new SummonersRift(code);
                    currentMatch.GenereerTeams();

                    List<BitmapImage> icons = new List<BitmapImage>();
                    for (int i = 0; i < currentMatch.Team1Champions.Count; i++)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team1Champions[i].IconSource);
                        icons.Add(new BitmapImage(new Uri(path, UriKind.Absolute)));
                    }
                    ImageIconChampion1Team1.Source = icons[0];
                    ImageIconChampion2Team1.Source = icons[1];
                    ImageIconChampion3Team1.Source = icons[2];
                    ImageIconChampion4Team1.Source = icons[3];
                    ImageIconChampion5Team1.Source = icons[4];

                    icons.Clear();
                    for (int i = 0; i < currentMatch.Team1Champions.Count; i++)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team2Champions[i].IconSource);
                        icons.Add(new BitmapImage(new Uri(path, UriKind.Absolute)));
                    }
                    ImageIconChampion1Team2.Source = icons[0];
                    ImageIconChampion2Team2.Source = icons[1];
                    ImageIconChampion3Team2.Source = icons[2];
                    ImageIconChampion4Team2.Source = icons[3];
                    ImageIconChampion5Team2.Source = icons[4];
                }
                else
                {
                    MessageBox.Show("Code moet uniek zijn!");
                }
            }
            else
            {
                MessageBox.Show("Code verplicht!");
            }
        }

        private void Genereer3v3Button_Click(object sender, RoutedEventArgs e)
        {
            string code = PasswordBoxMatchCode.Password;
            if (!string.IsNullOrEmpty(code))
            {
                if (MatchData.IsUniqueCode(code))
                {
                    currentMatch = new TwistedTreeline(code);
                    currentMatch.GenereerTeams();

                    List<BitmapImage> icons = new List<BitmapImage>();
                    for (int i = 0; i < currentMatch.Team1Champions.Count; i++)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team1Champions[i].IconSource);
                        icons.Add(new BitmapImage(new Uri(path, UriKind.Absolute)));
                    }
                    ImageIconChampion1Team1.Source = icons[0];
                    ImageIconChampion2Team1.Source = icons[1];
                    ImageIconChampion3Team1.Source = icons[2];

                    icons.Clear();
                    for (int i = 0; i < currentMatch.Team1Champions.Count; i++)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team2Champions[i].IconSource);
                        icons.Add(new BitmapImage(new Uri(path, UriKind.Absolute)));
                    }
                    ImageIconChampion1Team2.Source = icons[0];
                    ImageIconChampion2Team2.Source = icons[1];
                    ImageIconChampion3Team2.Source = icons[2];
                }
                else
                {
                    MessageBox.Show("Code moet uniek zijn!");
                }
            }
            else
            {
                MessageBox.Show("Code verplicht!");
            }
        }

        private void ExportToXMLButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.InitialDirectory = Directory.GetCurrentDirectory();
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    MatchData.ExportToXML(sfd.FileName);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }
        }

        private void BeslisWinnaarButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentMatch != null)
            {
                //currentMatch.DecideWinner();
                string winner = currentMatch.Winner == 1 ? "Red" : "Blue";
                MessageBox.Show($"The winner is {winner}");
                MatchData.AddFinishedMatch(currentMatch);
                ClearSimulatieTab();
                currentMatch = null;
            }
        }

        private void ClearSimulatieTab()
        {
            PasswordBoxMatchCode.Password = string.Empty;
            TextBlockChampion.Text = string.Empty;
            TextBlockClass.Text = string.Empty;
            TextBlockCost.Text = string.Empty;

            ListBoxChampionAbilities.Items.Clear();
            string path = System.IO.Path.Combine(Directory.GetCurrentDirectory() + "/images/icons/empty_icon.png");
            BitmapImage emptyImage = new BitmapImage(new Uri(path, UriKind.Absolute));

            ImageBanner.Source = null;

            ImageIconChampion1Team1.Source = emptyImage;
            ImageIconChampion2Team1.Source = emptyImage;
            ImageIconChampion3Team1.Source = emptyImage;
            ImageIconChampion4Team1.Source = emptyImage;
            ImageIconChampion5Team1.Source = emptyImage;

            ImageIconChampion1Team2.Source = emptyImage;
            ImageIconChampion2Team2.Source = emptyImage;
            ImageIconChampion3Team2.Source = emptyImage;
            ImageIconChampion4Team2.Source = emptyImage;
            ImageIconChampion5Team2.Source = emptyImage;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var pos in positionsList)
            {
                ComboBoxPositions.Items.Add(pos);  // FROM: L:29  private List<string> positionsList = new List<string>() { "sup", "mid", "bot", "jung", "top" };  
            }
        }
    }
}

