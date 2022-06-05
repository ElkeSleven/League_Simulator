using LeagueClassLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*● Erft over van Match
● Overschrijft GenereerTeams:
o Deze methode zorgt er voor dat de twee lists, Team1Champions en
Team2Champions elk gevuld zijn met vijf champion objecten met de
positions “sup”, “mid”, “jung”, “bot” en “top”. Gebruik hier de
GetRandomChampionByPosition(position) methode van ChampionData
voor.*/
namespace LeagueClassLibrary.Entities
{
    public class SummonersRift : Match
    {
        public SummonersRift(string code) : base(code){}

        public override void GenereerTeams()
        {
            Team1Champions = new List<Champion>();
            Team2Champions = new List<Champion>();
            
            List<string> positions = new List<string>()
            { "sup", "mid","bot","jung","top" };
            

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

            Champion sup = ChampionData.GetRandomChampionByPosition("sup");
            Champion mid = ChampionData.GetRandomChampionByPosition("mid");
            Champion jung = ChampionData.GetRandomChampionByPosition("jung");
            Champion bot = ChampionData.GetRandomChampionByPosition("bot");
            Champion top = ChampionData.GetRandomChampionByPosition("top");
            Team1Champions.AddRange(new Champion[] { sup, mid, jung, bot, top });

            Champion sup2 = ChampionData.GetRandomChampionByPosition("sup");
            Champion mid2 = ChampionData.GetRandomChampionByPosition("mid");
            Champion jung2 = ChampionData.GetRandomChampionByPosition("jung");
            Champion bot2 = ChampionData.GetRandomChampionByPosition("bot");
            Champion top2 = ChampionData.GetRandomChampionByPosition("top");
            Team2Champions.AddRange(new Champion[] { sup2, mid2, jung2, bot2, top2 });
        }*/
    }
}
