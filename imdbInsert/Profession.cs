using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdbInsert
{
    public class Profession
    {
        public int ProfessionID { get; set; }
        public string ProfessionName { get;}

        public Profession(int professionID, string professionName)
        {
            ProfessionID = professionID;
            ProfessionName = professionName;
        }
    }
}
