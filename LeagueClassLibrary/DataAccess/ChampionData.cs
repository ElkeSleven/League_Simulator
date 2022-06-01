using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Private eigenschap: DataTableChampions – DataTable
o De DataTableChampions kolommen voor position2 en position3 kunnen
null zijn. Zie de csv en Tabel 1.
● Private variable: r - Random
o Het random object wordt gebruikt in
GetRandomChampionByPosition(string position).
● Publieke methode: LoadCSV(string padNaarCsv) – void
o LoadCSV(string padNaarCsv) zorgt er voor dat de DataTableChampions
geïnitialiseerd is. De methode gebruikt het pad naar het csv bestand
dat meegegeven wordt om de DataTable te vullen met records.
● Publieke methode: GetDataViewChampion() – DataView
o Deze methode zet de data uit DataTableChampions om naar een
DataView.
● Publieke methode: GetDataViewChampionsByPosition(string position) -
DataView
o Deze methode filtert DataTableChampions op basis van position. Als
een champion de gegeven position bevat, dan wordt de champion
weergegeven in de DataView
● Publieke methode: GetDataViewChampionsBestToWorst() - DataView
o Deze methode sorteert de rijen in DataTableChampions op de
volgende criteria:
▪ Op het jaar dat ze zijn uitgekomen. Meest recent naar oud.
▪ Vervolgens op hoeveel posities een champion heeft. Meer
posities naar minder.
▪ Tot slot op de alfabetische volgorde van de naam.
● Publieke methode: GetRandomChampionByPosition(string position) -
Champion
o Deze methode geeft een willekeurig Champion object terug uit
DataTableChampions die de gegeven position bevat. Maak gebruik van
de GetAbilitiesByChampionName(string name) methode uit AbilityData
om de abilities op te vragen.

 */
namespace LeagueClassLibrary.DataAccess
{
    public static class ChampionData
    {
        public static DataTable DataTableChampions { get; set; }
        private static Random r = new Random();
        /*
         ChampionName;
        ChampionTitle
        ;ChampionClass
        ;ReleaseYear
        ;ChampionPosition1
        ;ChampionPosition2
        ;ChampionPosition3
        ;ChampionIcon
        ;ChampionBanner
        ;ChampionRPCost
        ;ChampionIPCost
         
         */
        public static void LoadCSV(string padNaarCsv)
        {
            Champion c;

            string[] ChampionName;
            string[] ChampionTitle;
            string[] ChampionClass;
            string[] ReleaseYear;
            string[] ChampionPosition1;
            string[] ChampionPosition2;
            string[] ChampionPosition3;
            string[] ChampionIcon;
            string[] ChampionBanner;
            string[] ChampionRPCost;
            string[] ChampionIPCost;


            using (StreamReader sr = new StreamReader(padNaarCsv))
            {
                while (!sr.EndOfStream)
                {
                    ChampionName = sr.ReadLine().Split(';');
                    ChampionTitle = sr.ReadLine().Split(';');
                    ChampionClass = sr.ReadLine().Split(';');
                    ReleaseYear = sr.ReadLine().Split(';');
                    ChampionPosition1 = sr.ReadLine().Split(';');
                    ChampionPosition2 = sr.ReadLine().Split(';');
                    ChampionPosition3 = sr.ReadLine().Split(';');
                    ChampionIcon = sr.ReadLine().Split(';');
                    ChampionBanner = sr.ReadLine().Split(';');
                    ChampionRPCost = sr.ReadLine().Split(';');
                    ChampionIPCost = sr.ReadLine().Split(';');



                    // c =  new Champion( );

                }


            }
        }

    }
}
