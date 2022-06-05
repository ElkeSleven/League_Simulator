using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLibrary.Entities
{
    public abstract class Match
    {
       public  List<Champion> Team1Champions;
       public List<Champion> Team2Champions;

        public int Winner;
        public string Code;

        public abstract void GenereerTeams();  // geen body omdat deze method abstract is 
    }
}
