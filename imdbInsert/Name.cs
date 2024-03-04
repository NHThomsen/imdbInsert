using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdbInsert
{
    public class Name
    {
        public string Nconst { get; set; }
        public string? PrimaryName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public List<int> PrimaryProfessions { get; set; }
        public List<string> KnownForTitles { get; set; }

        public Name(string nconst, string? primaryName, int? birthYear, int? deathYear, List<int> primary, List<string> knownFor) 
        {
            Nconst = nconst;
            PrimaryName = primaryName;
            BirthYear = birthYear;
            DeathYear = deathYear;
            PrimaryProfessions = primary;
            KnownForTitles = knownFor;
        }
    }
}
