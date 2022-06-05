using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeagueLibrary.Entities;
using System.Data;
using System.IO;
///ok
namespace LeagueLibrary.DataAccess
{
    public static class AbilityData
    {
         public static List<Ability> Abilities { get; set; }
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
         public static List<Ability> GetAbilitiesByChampionName(string championName)
        {
            if (Abilities != null)
            {
                var result = from ability in Abilities
                    where ability.ChampionName.Equals(championName)
                    select ability;
                return result.ToList();
            }

            return null;
        }

    }
}
