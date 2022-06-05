using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LeagueLibrary.Entities
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

        public string GetCost()
        { 
            string cost_string =  "deze champ kost: \n\r";
            return cost_string + " IP: " + CostIP + "RP: " + CostRP;
             
        }

        public override string ToString()
        {
            return $"{Name} {Title}";
        }
    }
}
