using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLibrary.Entities
{
    public class Ability
    {

        int Id { get; set; }
        string ChampionName { get; set; }
        string Name { get; set; }


      
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
