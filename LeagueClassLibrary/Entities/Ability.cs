﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 Ability:
● Eigenschap: Id - int
● Eigenschap: ChampionName - string
● Eigenschap: Name - string
● Constructor met een parameter voor elke eigenschap.
● Overschrijft ToString():
o Deze methode geeft de naam terug van de ability. 
 */
namespace LeagueClassLibrary.Entities
{
    public class Ability
    {
        public int Id { get; set; }
        public string ChampionName { get; set; }
        public string Name { get; set; }

        public Ability(int id, string championName, string name)
        {
            Id = id;
            ChampionName = championName;
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
