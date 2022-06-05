using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLibrary.Entities
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

        public abstract void GenereerTeams();  // geen body omdat deze method abstract is 

        public void DecideWinner()
        {
            double gemiddeldeTeam1 = 0;
            double gemiddeldeTeam2 = 0;
            for (int i = 0; i < Team1Champions.Count; i++)
            {
                gemiddeldeTeam1 += Team1Champions[i].ReleaseYear;
                gemiddeldeTeam2 += Team2Champions[i].ReleaseYear;
            }

            gemiddeldeTeam1 /= Team1Champions.Count;
            gemiddeldeTeam2 /= Team2Champions.Count;

            if (!gemiddeldeTeam1.Equals(gemiddeldeTeam2))
            {
                Winner = gemiddeldeTeam1 > gemiddeldeTeam2 ? 1 : 0;
            }
            else
            {
                int AssassinCountTeam1 = 0;
                int AssassinCountTeam2 = 0;
                for (int i = 0; i < Team1Champions.Count; i++)
                {
                    AssassinCountTeam1 = Team1Champions[i].Class.Equals("Assassin") ? AssassinCountTeam1 + 1 : AssassinCountTeam1;
                    AssassinCountTeam2 = Team2Champions[i].Class.Equals("Assassin") ? AssassinCountTeam2 + 1 : AssassinCountTeam2;
                }

                if (AssassinCountTeam1 == AssassinCountTeam2)
                {
                    Winner = 1;
                }
                else
                {
                    Winner = AssassinCountTeam1 > AssassinCountTeam2 ? 1 : 0;
                }
            }
        }
     
    }
}
