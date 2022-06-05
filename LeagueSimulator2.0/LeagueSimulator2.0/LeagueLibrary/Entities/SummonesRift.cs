using LeagueLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLibrary.Entities
{
    public class SummonesRift : Match
    {
        public SummonesRift(string code) : base(code) { }

        public override void GenereerTeams()
        {
            Team1Champions = new List<Champion>();
            Team2Champions = new List<Champion>();

            Champion sup = ChampionsData.GetRandomChampionByPosition("sup");
            Champion mid = ChampionsData.GetRandomChampionByPosition("mid");
            Champion jung = ChampionsData.GetRandomChampionByPosition("jung");
            Champion bot = ChampionsData.GetRandomChampionByPosition("bot");
            Champion top = ChampionsData.GetRandomChampionByPosition("top");
            Team1Champions.AddRange(new Champion[] { sup, mid, jung, bot, top });

            Champion sup2 = ChampionsData.GetRandomChampionByPosition("sup");
            Champion mid2 = ChampionsData.GetRandomChampionByPosition("mid");
            Champion jung2 = ChampionsData.GetRandomChampionByPosition("jung");
            Champion bot2 = ChampionsData.GetRandomChampionByPosition("bot");
            Champion top2 = ChampionsData.GetRandomChampionByPosition("top");
            Team2Champions.AddRange(new Champion[] { sup2, mid2, jung2, bot2, top2 });
        }

        

    }
}
