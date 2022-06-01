using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Champion:
● Eigenschap: Name - string
● Eigenschap: Title - string
● Eigenschap: Class - string
● Eigenschap: ReleaseYear - int
● Eigenschap: Abilities - List < Ability >
● Eigenschap: Positions - List<string>
● Eigenschap: IconSource - string
● Eigenschap: BannerSource - string
● Eigenschap: CostIP - int
● Eigenschap: CostRP - int
● Constructor met een parameter voor elke eigenschap.
● Overschrijft ToString():

o Deze methode geeft de naam en titel terug van de champion.
● Publieke methode: GetCost() - string
o Deze methode geeft de IP en RP cost terug in de volgende template:
“RP: { CostRP} / IP: { CostIP}”.
*/

namespace LeagueClassLibrary.Entities
{
    public class Champion
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Class { get; set; }
        public int ReleaseYear { get; set; }

        public List<Ability> Abilities { get; set; }
        public List<string> Positions { get; set; }
        public string IconSource { get; set; }
        public string BannerSource { get; set; }

        public int CostIP { get; set; }
        public int CostRP { get; set; }

        protected Champion(string name, string title, string @class, int releaseYear, List<Ability> abilities, List<string> positions, string iconSource, string bannerSource, int costIP, int costRP)
        {
            Name = name;
            Title = title;
            Class = @class;
            ReleaseYear = releaseYear;
            Abilities = abilities;
            Positions = positions;
            IconSource = iconSource;
            BannerSource = bannerSource;
            CostIP = costIP;
            CostRP = costRP;
        }

        public string GetCost()
        {
            return $"?";
        }





        public override string ToString()
        {
            return $"{Name} {Title}";
        }
    }
}
