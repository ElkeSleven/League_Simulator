using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
ok
*/

namespace LeagueClassLibrary.Entities
{
    public  class Champion
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

        public Champion(string name, string title, string @class, int releaseYear, List<Ability> abilities, List<string> positions, string icon, string banner, int costRP, int costIP  )
        {
            Name = name;
            Title = title;
            Class = @class;
            ReleaseYear = releaseYear;
            Abilities = abilities;
            Positions = positions;
            IconSource = icon;
            BannerSource = banner;
            CostRP = costRP;
            CostRP = costIP;
        }
        public string GetCost()
        {
            return $"RP: {CostRP} / IP: { CostIP}";
        }
        public override string ToString()
        {
            return $"{Name} {Title}";
        }
    }
}
