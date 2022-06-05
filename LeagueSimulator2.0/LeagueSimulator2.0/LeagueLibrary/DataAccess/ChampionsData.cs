using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;  // DataTabel
using System.IO;  // File
using LeagueLibrary.Entities;

//ok
namespace LeagueLibrary.DataAccess
{
    public static class ChampionsData
    {
        private static DataTable DataTableChampions;
        private static Random R = new Random();

        // ïnitialiseerd DataTabel DataTableChampions 
        // maakt eerste column naam 
        // vult datatable met waarden
        public static void LoadCSV(string padNaarCsv)
        {

            DataTableChampions = new DataTable("Champions");
            string[] rijen = File.ReadAllLines(padNaarCsv);
            string[] headers = rijen[0].Split(';');   /// pakt de eerte rij van de file en gebruit deze waarden als headers 
            int index = 0;



            /* Kolommen (Column's) maken columName is variabele naam die we in de app. gebruiken 
            * ColumnName is de naam de als header staat
            */
            DataColumn columnName = new DataColumn(headers[index++], typeof(string));
            DataColumn columnTitle = new DataColumn(headers[index++], typeof(string));
            DataColumn columnClass = new DataColumn(headers[index++], typeof(string));
            DataColumn columnYear = new DataColumn(headers[index++], typeof(int));
            DataColumn columnPos1 = new DataColumn(headers[index++], typeof(string));
            DataColumn columnPos2 = new DataColumn(headers[index++], typeof(string));
            DataColumn columnPos3 = new DataColumn(headers[index++], typeof(string));
            DataColumn columnIcon = new DataColumn(headers[index++], typeof(string));
            DataColumn columnBanner = new DataColumn(headers[index++], typeof(string));
            DataColumn columnRPCost = new DataColumn(headers[index++], typeof(int));
            DataColumn columnIPCost = new DataColumn(headers[index++], typeof(int));



            // set RANGE 
            DataTableChampions.Columns.AddRange(new DataColumn[] {
                                columnName,columnTitle,columnClass,columnYear,columnPos1,columnPos2,
                                columnPos3, columnIcon,columnBanner,columnRPCost,columnIPCost
            });

            rijen.Skip(1).ToList().ForEach(rij =>
            {

                string[] data = rij.Split(';'); ;
                for (int i = 0; i < data.Length; i++)
                {
                    data = rij.Split(';');
                    if (string.IsNullOrEmpty(data[i]))         /// rij inhoud controlleren op null waarden 
                    {
                        data[i] = null;
                    }
                    if(!string.IsNullOrEmpty(data[i]))
                    {
                        data[i] = data[i].Trim();

                    }

                }
                DataTableChampions.Rows.Add(data);

            });




        }

        // getDataView
        public static DataView GetDataViewChampions()
        {
            if (DataTableChampions != null)
            {
                return DataTableChampions.AsDataView();
            }

            throw new Exception("Datagrid is null!");

        }

        // sorteren 
        public static DataView GetDataViewChampionsByPosition(string position)
        {
            if (DataTableChampions != null)
            {
                var result = from data in DataTableChampions.AsEnumerable()
                             where data.ItemArray.Contains(position)
                             select data;
                return result.AsDataView();
            }
            throw new Exception("Datagrid is null!");
        }


        // sorteren 
        public static DataView GetDataViewChampionsBestToWorst()
        {
            if (DataTableChampions != null)
            {
                var result = from data in DataTableChampions.AsEnumerable()
                             orderby data.Field<int>("ReleaseYear") descending,
                                data.Field<string>("ChampionPosition2") == null,
                                 data.Field<string>("ChampionPosition3") == null,
                                data.Field<string>("ChampionName")
                             select data;

                return result.AsDataView();
            }
            throw new Exception("Datagrid is null!");
        }


        // sorteren 
        public static Champion GetRandomChampionByPosition(string position)
        {
            if (DataTableChampions != null)
            {
                DataView dv = GetDataViewChampionsByPosition(position);
                DataRowView row = dv[r.Next(0, dv.Count)];

                string championsName = row["ChampionName"].ToString();
                string ChampionTitle = row["ChampionTitle"].ToString();
                string ChampionClass = row["ChampionClass"].ToString();
                int ReleaseYear = int.Parse(row["ReleaseYear"].ToString());
                string ChampionPosition1 = row["ChampionPosition1"].ToString();
                string ChampionPosition2 = row["ChampionPosition2"] != null ? row["ChampionPosition2"].ToString() : null;
                string ChampionPosition3 = row["ChampionPosition3"] != null ? row["ChampionPosition3"].ToString() : null;
                string ChampionIcon = row["ChampionIcon"].ToString();
                string ChampionBanner = row["ChampionBanner"].ToString();
                int RPCost = int.Parse(row["ChampionRPCost"].ToString());
                int IPCost = int.Parse(row["ChampionIPCost"].ToString());

                List<string> positions = new List<string>();
                positions.Add(ChampionPosition1);
                if (ChampionPosition2 != null)
                    positions.Add(ChampionPosition2);
                if (ChampionPosition3 != null)
                    positions.Add(ChampionPosition3);

                List<Ability> abilities = AbilityData.GetAbilitiesByChampionName(championsName);

                Champion randomChampion = new Champion(championsName, ChampionTitle, ChampionClass,
                    ReleaseYear, abilities, positions, ChampionIcon, ChampionBanner, IPCost, RPCost);

                return randomChampion;
            }
            throw new Exception("Datagrid is null!");
        }







    }
}
