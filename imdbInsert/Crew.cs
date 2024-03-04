using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdbInsert
{
    public class Crew
    {
        public string Tconst {  get; set; }
        public List<string> Directors { get; set; }
        public List<string> Writers { get; set; }

        public Crew(string tconst, List<string> directors, List<string> writers) 
        {
            Tconst = tconst;
            Directors = directors;
            Writers = writers;
        }
    }
}
