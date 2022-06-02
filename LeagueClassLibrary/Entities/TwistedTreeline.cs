using LeagueClassLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 ● Erft over van Match
● Overschrijft GenereerTeams:
o Deze methode zorgt er voor dat de twee lists, Team1Champions en
Team2Champions elk gevuld zijn met drie champion objecten met de
positions “top”, “top” en “jung”. Gebruik hier de
GetRandomChampionByPosition(position) methode van ChampionData
voor
 */
namespace LeagueClassLibrary.Entities
{
    public class TwistedTreeline : Match
    {


        public TwistedTreeline(string code) : base(code)
        {
        }

        public override void GenereerTeams()
        {

            Team1Champions = new List<Champion>();
            Team2Champions = new List<Champion>();

            List<string> positions = new List<string>()
            { "top", "top","jung" };


            foreach (string position in positions)
            {
                Team1Champions.Add(ChampionData.GetRandomChampionByPosition(position));
            }

            foreach (string position in positions)
            {
                Team1Champions.Add(ChampionData.GetRandomChampionByPosition(position));
            }
        }
    }
}
