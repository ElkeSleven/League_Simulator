using LeagueClassLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ok
namespace LeagueClassLibrary.Entities
{
    public class TwistedTreeline : Match
    {
        public TwistedTreeline(string code) : base(code){}

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


        /// Ander manier voor GenereerTeams    voluitgeschreven
/*        public override void GenereerTeams()
        {
            Team1Champions = new List<Champion>();
            Team2Champions = new List<Champion>();

            Champion top = ChampionData.GetRandomChampionByPosition("top");
            Champion top2 = ChampionData.GetRandomChampionByPosition("top");
            Champion jung = ChampionData.GetRandomChampionByPosition("jung");
            Team1Champions.AddRange(new Champion[] { top,top2,jung
            });

            Champion topTeam2 = ChampionData.GetRandomChampionByPosition("top");
            Champion top2Team2 = ChampionData.GetRandomChampionByPosition("top");
            Champion jungTeam2 = ChampionData.GetRandomChampionByPosition("jung");
            Team2Champions.AddRange(new Champion[] { topTeam2, top2Team2, jungTeam2
            });
        }*/



    }
}
