using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdbInsert
{
    public class Genre
    {
        public int GenreID { get; private set; }
        public string GenreName {  get; private set; }

        public Genre(int ID, string name) 
        {
            GenreID = ID;
            GenreName = name;
        }
    }
}
