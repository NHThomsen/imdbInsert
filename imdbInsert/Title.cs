using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdbInsert
{
    public class Title
    {
        public string Tconst {  get; private set; }
        public int TitleTypeID { get; private set; }
        public string PrimaryTitle { get; private set; }
        public string OriginalTitle { get; private set; }
        public bool IsAdult { get; private set; }
        public int? StartYear { get; private set; }
        public int? EndYear { get; private set; }
        public int? RunTimeMinutes { get; private set; }
        public List<int> Genres { get; private set; }

        public Title(string titleConst, int titleTypeID, string primaryTitle, string originalTitle,
            bool isAdult, int? startYear, int? endYear, int? runTimeMinutes, List<int> genres) 
        {
            Tconst = titleConst;
            TitleTypeID = titleTypeID;
            PrimaryTitle = primaryTitle;
            OriginalTitle = originalTitle;
            IsAdult = isAdult;
            StartYear = startYear;
            EndYear = endYear;
            RunTimeMinutes = runTimeMinutes;
            Genres = genres;
        }
    }
}
