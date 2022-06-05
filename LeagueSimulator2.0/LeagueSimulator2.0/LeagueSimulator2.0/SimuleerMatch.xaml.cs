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

        //// tab 2 /// Bij het overen over een img van een champion  
        private void LaadChampion(int indexChampion, int team)
        {
           
            
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
      
        }
        // tab 2
        private void Genereer3v3Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
        // tab 2
        private void BeslisWinnaarButton_Click(object sender, RoutedEventArgs e)
        {
          
        }

        // na dat een match over is   /// als de gebruiker op OK klikt 
        private void ClearSimulatieTab()
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
