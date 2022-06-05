using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLibrary.Entities
{
    public class Ability
    {

        public int Id { get; set; }
        public string ChampionName { get; set; }
        public string Name { get; set; }


      
        public override string ToString()
        {
            return $"{Name}";
        }


        // constructor 
        public Ability(int id, string championName, string name)
        {
            Id = id;
            ChampionName = championName;
            Name = name;
        }


    }
}
