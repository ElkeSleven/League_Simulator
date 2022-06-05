using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using LeagueLibrary.Entities;
using System.IO;

namespace LeagueLibrary.DataAccess
{
    public static class MatchData
    {

        //**
        public static DataTable DataTableMatches { get; set; }


        //** column   *kolomnamen aanmaken 
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


        //** voegt de match toe aan  DataTableMatches  */
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


        //**DataView matches  * / 
        public static DataView GetDataViewMatches()
        {
            if(DataTableMatches != null)
            {
                return DataTableMatches.AsDataView();
            }
            return null;
            
        }


        /**Save as XML  *****/
        public static void ExportToXML(string pad)
        {
            try
            {
                DataTableMatches.WriteXml(pad + "\\Matches.xml");
            }
            catch (Exception e)
            {
                throw e;     // De objectverwijzing is niet op een exemplaar van een object ingesteld.
            }
        }


        /**Controlle als de ingegeven code uniek is */
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
