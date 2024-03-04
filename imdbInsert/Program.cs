using imdbInsert;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        DateTime start = DateTime.Now;

        #region basics
        #region Get TitleTypes and Genres
        //List<string> types = new List<string>();
        //List<string> allGenres = new List<string>();
        //List<string> genres = new List<string>();
        //string genresNotSplit = "";
        //foreach (string line in File.ReadLines(@"C:\imdbTemp\data.tsv").Skip(1))
        //{
        //    if (!types.Contains(line.Split("\t")[1]))
        //    {
        //        types.Add(line.Split("\t")[1]);
        //    }

        //    genresNotSplit = line.Split("\t")[8];
        //    genres = genresNotSplit.Split(",").ToList();
        //    foreach (string genre in genres)
        //    {
        //        if (!allGenres.Contains(genre) && genre != "\\N")
        //        {
        //            allGenres.Add(genre);
        //        }
        //    }
        //}
        //sqlDAL.InsertGenres(allGenres);
        //sqlDAL.InsertTitleTypes(types);
        #endregion

        #region All titles
        //List<TitleType> titleTypes = sqlDAL.GetTitleTypes();
        //List<Genre> allGenres = sqlDAL.GetGenres();
        //List<int> genres = new List<int>();
        //List<Title> titles = new List<Title>();
        //int? startYear = 0;
        //int? endYear = 0;
        //int? runTimeMin = 0;
        //bool isAdult = false;
        //int amountOfLines = File.ReadLines(@"C:\imdbTemp\data.tsv").Count();
        //int previousValue = 1;
        //for (int i = 100000; i <= amountOfLines + 100000; i += 100000)
        //{
        //    //Console.WriteLine(i + " - " + previousValue);
        //    // 3 minutter og 13 sekunder for alle rækker
        //    foreach (string line in File.ReadLines(@"C:\imdbTemp\data.tsv").Take(i).Skip(previousValue))
        //    {
        //        if (line.Split("\t")[8] != "\\N")
        //        {
        //            foreach (string genr in line.Split("\t")[8].Split(","))
        //            {
        //                genres.Add(allGenres.Find(g => g.GenreName == genr).GenreID);
        //            }
        //        }
        //        if (line.Split("\t")[5] != "\\N")
        //        {
        //            startYear = int.Parse(line.Split("\t")[5]);
        //        }
        //        else
        //        {
        //            startYear = null;
        //        }
        //        if (line.Split("\t")[6] != @"\N")
        //        {
        //            endYear = int.Parse(line.Split("\t")[6]);
        //        }
        //        else
        //        {
        //            endYear = null;
        //        }
        //        if (line.Split("\t")[4] == "1")
        //        {
        //            isAdult = true;
        //        }
        //        if (line.Split("\t")[7] != "\\N")
        //        {
        //            runTimeMin = int.Parse(line.Split("\t")[7]);
        //        }
        //        else
        //        {
        //            runTimeMin = null;
        //        }
        //        titles.Add(new Title(
        //            line.Split("\t")[0],
        //            titleTypes.Find(tt => tt.Type == line.Split("\t")[1]).TitleTypeID,
        //            line.Split("\t")[2],
        //            line.Split("\t")[3],
        //            isAdult,
        //            startYear,
        //            endYear,
        //            runTimeMin,
        //            genres
        //            ));
        //        genres = new List<int>();
        //        isAdult = false;
        //    }
        //    sqlDAL.InsertTitles(titles);
        //    titles.Clear();
        //    previousValue = i;
        //};
        #endregion
        #endregion

        #region Names
        #region Get all professions
        //List<string> allProfessions = new List<string>();
        //string professionNotSplit = "";
        //foreach (string line in File.ReadLines(@"C:\imdbTemp\names\data.tsv").Skip(1))
        //{
        //    if (line.Split("\t")[4] != "\\N")
        //    {
        //        professionNotSplit = line.Split("\t")[4];
        //        foreach(string prof in professionNotSplit.Split(",")) 
        //        {
        //            if(!allProfessions.Contains(prof) && prof != "")
        //            {
        //                allProfessions.Add(prof);
        //            }
        //        }
        //    }
        //}
        //sqlDAL.InsertProfessions(allProfessions);
        #endregion
        #region All names
        //List<Name> names = new List<Name>();
        //List<Profession> allProfessions = sqlDAL.GetProfessions();
        //string? primaryName;
        //int? birthYear;
        //int? deathYear;
        //List<int> primaryProf = new List<int>();
        //List<string> knownFor = new List<string>();
        //int amountOfLines = File.ReadLines(@"C:\imdbTemp\names\data.tsv").Count();
        //int previousValue = 1;
        //for (int i = 100000; i <= amountOfLines + 100000; i += 100000)
        //{
        //    Console.WriteLine(i + " - " + previousValue);
        //    foreach (string line in File.ReadLines(@"C:\imdbTemp\names\data.tsv").Take(i).Skip(previousValue))
        //    {
        //        if (line.Split("\t")[1] != "\\N")
        //        {
        //            primaryName = line.Split("\t")[1];
        //        }
        //        else
        //        {
        //            primaryName = null;
        //        }
        //        if (line.Split("\t")[2] != "\\N")
        //        {
        //            birthYear = int.Parse(line.Split("\t")[2]);
        //        }
        //        else
        //        {
        //            birthYear = null;
        //        }
        //        if (line.Split("\t")[3] != "\\N")
        //        {
        //            deathYear = int.Parse(line.Split("\t")[3]);
        //        }
        //        else
        //        {
        //            deathYear = null;
        //        }
        //        if (line.Split("\t")[4] != "\\N")
        //        {
        //            foreach(string prof in line.Split("\t")[4].Split(","))
        //            {
        //                if(prof != "")
        //                { 
        //                    primaryProf.Add(allProfessions.Find(p => p.ProfessionName == prof).ProfessionID);
        //                }
        //            }
        //        }
        //        if (line.Split("\t")[5] != "\\N")
        //        {
        //            knownFor = line.Split("\t")[5].Split(",").ToList();
        //        }
        //        names.Add(new Name(
        //            line.Split("\t")[0],
        //            primaryName,
        //            birthYear,
        //            deathYear,
        //            primaryProf,
        //            knownFor
        //            ));
        //        primaryProf = new List<int>();
        //        knownFor = new List<string>();
        //        primaryName = null;
        //        birthYear = null;
        //        deathYear = null;
        //    }
        //    sqlDAL.InsertNames(names);
        //    names.Clear();
        //    previousValue = i;
        //}
        #endregion
        #endregion

        #region Crews
        List<Crew> crew = new List<Crew>();
        string? tconst = null;
        List<string> directors = new List<string>();
        List<string> writers = new List<string>();
        int amountOfLines = File.ReadLines(@"C:\imdbTemp\crews\data.tsv").Count();
        int previousValue = 1;
        for (int i = 100000; i <= amountOfLines + 100000; i += 100000)
        {
            Console.WriteLine(i + " - " + previousValue);
            foreach (string line in File.ReadLines(@"C:\imdbTemp\crews\data.tsv").Take(i).Skip(previousValue))
            {
                if (line.Split("\t")[0] != "\\N")
                {
                    tconst = line.Split("\t")[0];
                }
                if (line.Split("\t")[1] != "\\N")
                {
                    directors = line.Split("\t")[1].Split(",").ToList();
                }
                if (line.Split("\t")[2] != "\\N")
                {
                    writers = line.Split("\t")[2].Split(",").ToList();
                }
                crew.Add(new Crew(tconst, directors, writers));
                directors = new List<string>();
                writers = new List<string>();
            }
            sqlDAL.InsertCrew(crew);
            crew = new List<Crew>();
            previousValue = i;
        }
        #endregion

        DateTime end = DateTime.Now;
        Console.WriteLine(end - start);

        Console.ReadKey();
    }
}