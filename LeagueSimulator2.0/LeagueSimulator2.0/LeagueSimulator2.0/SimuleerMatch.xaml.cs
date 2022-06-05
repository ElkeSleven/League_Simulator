using LeagueLibrary.DataAccess;
using LeagueLibrary.Entities;
using System;
using System.Collections.Generic;
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
using Path = System.IO.Path;

namespace LeagueSimulator2._0
{
    /// <summary>
    /// Interaction logic for SimuleerMatch.xaml
    /// </summary>
    public partial class SimuleerMatch : Window
    {
        public SimuleerMatch()
        {
            InitializeComponent();
        }
        private Match currentMatch;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           // MatchData.InitializeDataTableMatches();
        }

        //// wpf2 /// Bij :hover over een img   
        private void LaadChampion(int indexChampion, int team)
        {
            if (currentMatch != null)
            {
                if (team == 1)
                {
                    if (indexChampion < currentMatch.Team1Champions.Count)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team1Champions[indexChampion].BannerSource);/// images file staat in debug 
                                                                                                                                                           /// ..\LeagueSim\LeagueSimulator\bin\Debug\images
                        ImageBanner.Source =
                            new BitmapImage(new Uri(path,
                                UriKind.Absolute));
                        TextBlockChampion.Text = currentMatch.Team1Champions[indexChampion].Title;      //FILL: txtbox 
                        TextBlockClass.Text = currentMatch.Team1Champions[indexChampion].Class;         //FILL: txtbox 
                        TextBlockCost.Text = currentMatch.Team1Champions[indexChampion].GetCost();      //FILL: txtbox 
                        ListBoxChampionAbilities.Items.Clear();                                         //CLEAR: listbox
                        foreach (var ability in currentMatch.Team1Champions[indexChampion].Abilities)
                        {
                            ListBoxChampionAbilities.Items.Add(ability);  // FILL: listbox  met ability's
                        }
                    }

                }
                else
                {
                    if (indexChampion < currentMatch.Team2Champions.Count)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team2Champions[indexChampion].BannerSource);/// images file staat in debug 
                                                                                                                                                           /// ..\LeagueSim\LeagueSimulator\bin\Debug\images
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
        //// haald de img op     //// pxl 
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


        // tab 2
        private void Genereer5v5Button_Click(object sender, RoutedEventArgs e)
        {
            string code = PasswordBoxMatchCode.Password;
            if (!string.IsNullOrEmpty(code)) 
            {
                bool isUniek = MatchData.IsUniqueCode(code);/*            */// kijkt als de code al voorkomt in de table dataTabelMatches
                if (isUniek)           
                {
                    currentMatch = new SummonesRift(code);                /// 
                    currentMatch.GenereerTeams();

                    List<BitmapImage> icons = new List<BitmapImage>();
                    for (int i = 0; i < currentMatch.Team1Champions.Count; i++)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team1Champions[i].IconSource);/// images file staat in debug 
                                                                                                                                             /// ..\LeagueSim\LeagueSimulator\bin\Debug\images
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
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team2Champions[i].IconSource);/// images file staat in debug 
                                                                                                                                             /// ..\LeagueSim\LeagueSimulator\bin\Debug\images
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



        // tab 2
        private void Genereer3v3Button_Click(object sender, RoutedEventArgs e)
        {
            string code = PasswordBoxMatchCode.Password;
            if (!string.IsNullOrEmpty(code))
            {
                if (MatchData.IsUniqueCode(code)) //TO:
                {
                    currentMatch = new TwistedTreeline(code);  //TO: 
                    currentMatch.GenereerTeams(); //INTERFACE

                    List<BitmapImage> icons = new List<BitmapImage>();
                    for (int i = 0; i < currentMatch.Team1Champions.Count; i++)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team1Champions[i].IconSource);/// images file staat in debug 
                                                                                                                                             ///  haalt een specifieke img op ( + currentMatch.Team1Champions[i].IconSource)
                                                                                                                                             /// ..\LeagueSim\LeagueSimulator\bin\Debug\images + currentMatch.Team1Champions[i].IconSource
                        icons.Add(new BitmapImage(new Uri(path, UriKind.Absolute)));
                    }
                    ImageIconChampion1Team1.Source = icons[0];   // FILL:
                    ImageIconChampion2Team1.Source = icons[1];
                    ImageIconChampion3Team1.Source = icons[2];

                    icons.Clear();
                    for (int i = 0; i < currentMatch.Team1Champions.Count; i++)
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/" + currentMatch.Team2Champions[i].IconSource);/// images file staat in debug 
                                                                                                                                             /// ..\LeagueSim\LeagueSimulator\bin\Debug\images
                        icons.Add(new BitmapImage(new Uri(path, UriKind.Absolute)));
                    }
                    ImageIconChampion1Team2.Source = icons[0];
                    ImageIconChampion2Team2.Source = icons[1]; // FILL
                    ImageIconChampion3Team2.Source = icons[2];
                }
                else
                {
                    MessageBox.Show("Code moet uniek zijn!");  /// als de gebruiker dezelfde code heeft ingegeven 
                }
            }
            else
            {
                MessageBox.Show("Code verplicht!");  /// als de gebruiker geeen code heeft ingegeven 
            }
        }


        // tab 2
        private void BeslisWinnaarButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentMatch != null)
            {
                currentMatch.DecideWinner();  // INTERFACE:  
                string winner = currentMatch.Winner == 1 ? "Red" : "Blue";  //FILL
                MessageBox.Show($"The winner is {winner}");   //FILL
                MatchData.AddFinishedMatch(currentMatch); // TO: 'MatchData'
                ClearSimulatieTab();   //TO: 
                currentMatch = null;    // CLEAR
            }
        }

        // na dat een match over is   /// als de gebruiker op OK klikt 
        private void ClearSimulatieTab()
        {
            PasswordBoxMatchCode.Password = string.Empty;    //CLEAR: txt
            TextBlockChampion.Text = string.Empty;           //CLEAR: txt
            TextBlockClass.Text = string.Empty;              //CLEAR  txt
            TextBlockCost.Text = string.Empty;               //CLEAR: txt

            ListBoxChampionAbilities.Items.Clear(); // CLEAR listbox 

            string path = Path.Combine(Directory.GetCurrentDirectory() + "/images/icons/empty_icon.png");    /// images file staat in debug  
            // haalt een specifieke img op 
            /// ..\LeagueSim\LeagueSimulator\bin\Debug\images\icons\empty_icon.png
            /// 
            BitmapImage emptyImage = new BitmapImage(new Uri(path, UriKind.Absolute));

            ImageBanner.Source = null;                          // CLEAR: img 

            ImageIconChampion1Team1.Source = emptyImage;        //FILL: img 
            ImageIconChampion2Team1.Source = emptyImage;
            ImageIconChampion3Team1.Source = emptyImage;
            ImageIconChampion4Team1.Source = emptyImage;
            ImageIconChampion5Team1.Source = emptyImage;

            ImageIconChampion1Team2.Source = emptyImage;       //FILL: img
            ImageIconChampion2Team2.Source = emptyImage;
            ImageIconChampion3Team2.Source = emptyImage;
            ImageIconChampion4Team2.Source = emptyImage;
            ImageIconChampion5Team2.Source = emptyImage;
        }


    }
}
