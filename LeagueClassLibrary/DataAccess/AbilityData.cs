using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; // voor streamreader
using System.Threading.Tasks;
using LeagueClassLibrary.Entities;
/*
● Private eigenschap: Abilities - List<Ability>
● Publieke methode: LoadCSV(string padNaarCsv) – void
o LoadCSV(string padNaarCsv) zorgt er voor dat de Abilities list
geïnitialiseerd is. De methode gebruikt het pad naar het csv bestand
dat meegegeven wordt om de List te vullen met Ability objecten.
● Publieke methode: GetAbilitiesByChampionName(string championName) –
List<Ability>
o Deze methode geeft een list terug van Ability objecten die van een
champion zijn met de gegeven naam. Gebruik hier een Linq query
voor.

*/
namespace LeagueClassLibrary.DataAccess
{
    public static class AbilityData
    {
        private static List<Ability> Abilities { get; set; }
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
        


        public static List<Ability> GetAbilitiesByChampionName(string ChampionName)
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
