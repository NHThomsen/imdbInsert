using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdbInsert
{
    public class TitleType
    {
        public int TitleTypeID { get; private set; }
        public string Type { get; private set;}

        public TitleType(int titleTypeID, string type)
        {
            TitleTypeID = titleTypeID;
            Type = type;
        }
    }
}
