using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Match(*):
● Eigenschap: Team1Champions - List < Champion >
● Eigenschap: Team2Champions - List < Champion >
● Eigenschap: Winner - int
● Eigenschap: Code - string
● Constructor met één parameter: code.
● Publieke abstracte methode: GenereerTeams() - void
*/

namespace LeagueClassLibrary.Entities
{
    public abstract class Match : IWinnable
    {
        public List<Champion> Team1Champions { get; set; }
        public List<Champion> Team2Champions { get; set; } 
        public int Winner { get; set; }
        public string Code { get; set; }
        public Match(string code)
        {
            Code = code;
        }
        public abstract void GenereerTeams();




        public void DiscideWinner()
        {
            
            
            
            throw new NotImplementedException();
        }
    }
}

