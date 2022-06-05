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
        public static DataTable DataTableMatches { get; set; }

        public static void InitializeDataTableMatches()
        {
            try
            {
                DataTableMatches = new DataTable("Matches");

                DataColumn dataColumnId = new DataColumn("Id", typeof(int));
                DataColumn dataColumnCode = new DataColumn("Code", typeof(string));
                DataColumn dataColumnWinner = new DataColumn("Winner", typeof(string));
                dataColumnId.AutoIncrement = true;
                dataColumnId.AutoIncrementSeed = 1;
                dataColumnId.AutoIncrementStep = 1;

                DataTableMatches.Columns.AddRange(new DataColumn[]
                {
                    dataColumnId,dataColumnCode,dataColumnWinner
                });
                DataColumn[] primaryKey = { dataColumnId };
                DataTableMatches.PrimaryKey = primaryKey;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void AddFinishedMatch(Match match)
        {
            if (DataTableMatches != null)
            {
                string winner = match.Winner == 1 ? "Red" : "Blue";
                DataRow row = DataTableMatches.NewRow();
                row[1] = winner;
                row[2] = match.Code;

                DataTableMatches.Rows.Add(row);
            }
        }

        public static DataView GetDataViewMatches()
        {
            return DataTableMatches.AsDataView();
        }

        public static void ExportToXML(string filePath)
        {
            try
            {
                DataTableMatches.WriteXml(filePath + "/Matches.xml");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool IsUniqueCode(string code)
        {
            foreach (DataRow row in DataTableMatches.Rows)
            {
                if (row.ItemArray.Contains(code))
                {
                    return false;
                }
            }

            return true;
        }



    }
}
