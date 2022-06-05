using LeagueClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LeagueClassLibrary.DataAccess
{
    public static class ChampionData
    {
        public static DataTable DataTableChampions { get; set; }
        private static Random r = new Random();
   
        public static void LoadCSV(string padNaarCsv)
        {
            DataTableChampions = new DataTable("Champions");
            try
            {
                string[] lines = File.ReadAllLines(padNaarCsv);
                string[] headers = lines[0].Split(';');
                int index = 0;

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


                DataTableChampions.Columns.AddRange(new DataColumn[]
                {
                    columnName,columnTitle,columnClass,columnYear,columnPos1,columnPos2,
                    columnPos3, columnIcon,columnBanner,columnRPCost,columnIPCost
                });

                lines.Skip(1).ToList().ForEach(t =>
                {
                    string[] data = t.Split(';');
                    if (string.IsNullOrEmpty(data[5]))
                    {
                        data[5] = null;
                    }

                    if (string.IsNullOrEmpty(data[6]))
                    {
                        data[6] = null;
                    }

                    DataTableChampions.Rows.Add(data);
                });

            }
            catch
            {
                DataTableChampions = null;
                throw new Exception("Wrong file format!");
            }
        }    //ok

        public static DataView GetDataView()
        {
            if (DataTableChampions != null)
            {
                return DataTableChampions.AsDataView();
            }

            throw new Exception("Datagrid is null!");
        }


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
        // van sem
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

        // van sander
/*        public static Champion GetRandomChampionByPosition2(string position)  // top mid bot jug 
        {
            Champion champion = null;

            // eerst kijken als de champ de position heeft en dan .. een wilkeurige champ nemen 
            var championsMetCorrectePosition =
                DataTableChampions.AsEnumerable()
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
                positions,
                geselecteerdeChampionRow["Icon Source"].ToString(),
                geselecteerdeChampionRow["Banner Source"].ToString(),
                Convert.ToInt32(geselecteerdeChampionRow["RP"]),
                Convert.ToInt32(geselecteerdeChampionRow["IP"])
                );

            return champion;
        }*/
    }
}
