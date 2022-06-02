using LeagueClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 3 MatchData
● Private eigenschap: DataTableMatches - DataTable

● Publieke methode: InitializeDataTableMatches() - void
o Deze methode initialiseert de DataTableMatches met een Id (int),
Code (string) en Winner (string) kolom. Zorg er voor dat de Id kolom
automatisch incrementeert. Zie tabel 3.


● Publieke methode: AddFinishedMatch(Match match) - void
o Deze methode voegt een match toe aan de DataTableMatches.
Verander de team code van het match object naar de namen: “Red”
of “Blue”. Als de Winner eigenschap van het match object gelijk is
aan 1, dan wint team “Red”. Zoniet, dan wint team “Blue”.


● Publieke methode: GetDataViewMatches() - DataView
o Deze methode zet de data uit DataTableMatches om naar een DataView


● Publieke methode: ExportToXML() - void
o Deze methode exporteert de inhoud van DataTableMatches naar een
bestand, genaamd “Matches.xml”. Laat de gebruiker zelf kiezen waar
hij of zij dit bestand wenst op te slaan.


● Publieke methode: IsUniqueCode(string code) - bool
o Deze methode geeft true terug als de gegeven code nog niet
voorkomt in DataTableMatches.


 */
namespace LeagueClassLibrary.DataAccess
{
    public static class MatchData
    {
        private static DataTable DataTabelMatches;
        public static void InitializeDataTableMatches()
        {
          

            /*
             * 
             o Deze methode initialiseert de DataTableMatches met een Id (int),
            Code (string) en Winner (string) kolom. Zorg er voor dat de Id kolom
            automatisch incrementeert. Zie tabel 3.
             */


        }
        public static void AddFinishedMatch(Match match)
        {


            /*
             * o Deze methode voegt een match toe aan de DataTableMatches.
Verander de team code van het match object naar de namen: “Red”
of “Blue”. Als de Winner eigenschap van het match object gelijk is
aan 1, dan wint team “Red”. Zoniet, dan wint team “Blue”.

             */
        }
        public static DataView GetDataViewMatches()
        {
            //o Deze methode zet de data uit DataTableMatches om naar een DataView  
            DataView dv = new DataView();




            return dv;


        }
        public static void ExportToXML()
        {
            DataTable dt = new DataTable();
            





        }
        /*        //● Publieke methode: ExportToXML() - void
                o Deze methode exporteert de inhoud van DataTableMatches naar een
        bestand, genaamd “Matches.xml”. Laat de gebruiker zelf kiezen waar
        hij of zij dit bestand wenst op te slaan.*/





        /*
● Publieke methode: IsUniqueCode(string code) - bool
o Deze methode geeft true terug als de gegeven code nog niet
voorkomt in DataTableMatches.*/
        public static bool IsUniqueCode(string code)
        {
            bool isUnique = false;




            return isUnique;
        }



    }
}
