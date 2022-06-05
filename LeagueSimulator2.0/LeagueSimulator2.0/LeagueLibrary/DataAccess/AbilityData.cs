using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueLibrary.Entities;
using System.Data;
using System.IO;

namespace LeagueLibrary.DataAccess
{
    public static class AbilityData
    {
        private static List<Ability> Abilities { get; set; }

        public static void LoadCSV(string padNaarCsv)
        {
            Abilities = new List<Ability>();
            try
            {
                string[] lines = File.ReadAllLines(padNaarCsv);

                for (int i = 1; i < lines.GetLength(0); i++)
                {
                    string[] data;
                    data = lines[i].Split(';');

                    int abilityId = int.Parse(data[0]);
                    string championName = data[1];
                    string abilityName = data[2];
                       

                    Abilities.Add(new Ability(abilityId, championName , abilityName));
                }
            }
            catch
            {
                Abilities = null;
                throw new Exception("Wrong file format!");
            }



        }

    }
}
