using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; // voor streamreader
using System.Threading.Tasks;
using LeagueClassLibrary.Entities;
/*
ok

*/
namespace LeagueClassLibrary.DataAccess
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
                    string[] data = lines[i].Split(';');
                    Abilities.Add(new Ability(int.Parse(data[0]), data[1], data[2]));
                }
            }
            catch
            {
                Abilities = null;
                throw new Exception("Wrong file format!");
            }
        }
        /*  // van sander
          public static void LoadCSV(string padNaarCsv)
          {
              using(StreamReader sr = new StreamReader(padNaarCsv))
              {
                  sr.ReadToEnd();
                  while (!sr.EndOfStream)
                  {
                      string regel = sr.ReadLine();
                      string[] csv = regel.Split(';');

                      int id = Convert.ToInt32(csv[0]);
                      string chamionName = csv[1];
                      string name = csv[2];

                      Ability ability = new Ability(id, chamionName, name);
                      Abilities.Add(ability);
                  }
              }
          }
          */

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


        // van sander
        public static List<Ability> GetAbilitiesByChampionName2(string ChampionName)
        {
            List<Ability> abilitiesOfChampion = new List<Ability>();

            abilitiesOfChampion = (from ability in Abilities
                                   where ability.ChampionName.Equals(ChampionName)
                                   select ability).ToList();
            //abilitiesOfChampion =  Abilities.Where(x => x.ChampionName.Equals(ChampionName)).ToList();


            return abilitiesOfChampion;

        }


    }
}
