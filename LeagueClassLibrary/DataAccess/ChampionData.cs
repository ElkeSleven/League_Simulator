using LeagueClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        public static DataTable DataTableChampion { get; set; }
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
            //1. Maat DataTable
            DataTableChampion = new DataTable("Champions");

            //2 maak alle DataColumn's
            DataColumn name = new DataColumn("Name",  typeof(string));
            DataColumn title = new DataColumn("Title",  typeof(string));
            DataColumn releaseYear = new DataColumn("ReleaseYear",  typeof(int));
            DataColumn position1 = new DataColumn("Position1",  typeof(string));
            DataColumn position2 = new DataColumn("Position2",  typeof(string));
            DataColumn position3 = new DataColumn("Position2",  typeof(string));
            DataColumn banner = new DataColumn("Icon Sourse", typeof (string));
        }

        public static DataView GetDataView()
        {
            return DataTableChampion.DefaultView;
        }


        public static Champion GetRandomChampionByPosition(string position)  // top mid bot jug 
        {
            Champion champion = null;

            // eerst kijken als de champ de position heeft en dan .. een wilkeurige champ nemen 
            var championsMetCorrectePosition =
                DataTableChampion.AsEnumerable()
                .Where(x => x["Position 1"].ToString().Equals(position) ||
                x["Position 2"].ToString().Equals(position) ||
                x["Position 3"].ToString().Equals(position)
               ).ToList();

            int rIndex = r.Next(0, championsMetCorrectePosition.Count);
            
            var geselecteerdeChampionRow = championsMetCorrectePosition[rIndex];

            List<string> positions = new List<string>()
            {
                geselecteerdeChampionRow["Position 1"].ToString(),
                geselecteerdeChampionRow["Position 2"].ToString(),
                geselecteerdeChampionRow["Position 3"].ToString()
            };

           string championName  = geselecteerdeChampionRow["Name"].ToString();
            List<Ability> abilities = AbilityData.GetAbilitiesByChampionName(championName);

            champion = new Champion(
                championName,
                geselecteerdeChampionRow["Title"].ToString(),
                geselecteerdeChampionRow["Class"].ToString(), 
                Convert.ToInt32(geselecteerdeChampionRow["Release"]),
                abilities,
                position,
                geselecteerdeChampionRow["Icon Source"].ToString(),
                geselecteerdeChampionRow[""]
                );

            return champion;
        }
    }
}
