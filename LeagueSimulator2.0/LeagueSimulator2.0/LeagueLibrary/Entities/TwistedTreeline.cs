using LeagueLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLibrary.Entities
{
    public class TwistedTreeline : Match
    {
        public TwistedTreeline(string code) : base(code) { }

        public override void GenereerTeams()
        {
            Team1Champions = new List<Champion>();
            Team2Champions = new List<Champion>();

            Champion top = ChampionsData.GetRandomChampionByPosition("top");
            Champion top2 = ChampionsData.GetRandomChampionByPosition("top");
            Champion jung = ChampionsData.GetRandomChampionByPosition("jung");
            Team1Champions.AddRange(new Champion[] { top, top2, jung });

            Champion topTeam2 = ChampionsData.GetRandomChampionByPosition("top");
            Champion top2Team2 = ChampionsData.GetRandomChampionByPosition("top");
            Champion jungTeam2 = ChampionsData.GetRandomChampionByPosition("jung");
            Team2Champions.AddRange(new Champion[] { topTeam2, top2Team2, jungTeam2 });
        }

    }



}
