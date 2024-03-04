using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdbInsert
{
    public static class sqlDAL
    {
        private static string connectionString = "Persist Security Info=False;Integrated Security=true; Initial Catalog=imdbDB;Server=LAPTOP-1OS9C9II";
        public static void InsertTitleTypes(List<string> titleTypes) 
        {
            using(SqlConnection conn = new SqlConnection(connectionString)) 
            {
                conn.Open();
                foreach (string titleType in titleTypes)
                {
                    using (SqlCommand insertTitleType = new SqlCommand("INSERT INTO TitleTypes VALUES(@titleType)", conn))
                    {
                        insertTitleType.Parameters.AddWithValue("@titleType", titleType);
                        insertTitleType.ExecuteNonQuery();
                    }
                }
            }
        }
        public static void InsertGenres(List<string> genres) 
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                foreach (string genre in genres)
                {
                    using (SqlCommand insertGenre = new SqlCommand("INSERT INTO Genres VALUES(@genre)", conn))
                    {
                        insertGenre.Parameters.AddWithValue("@genre", genre);
                        insertGenre.ExecuteNonQuery();
                    }
                }
            }
        }
        public static List<TitleType> GetTitleTypes() 
        {
            List<TitleType> titleTypes = new List<TitleType>();
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                using (SqlCommand getAllTitleTypes = new SqlCommand("SELECT * FROM TitleTypes",connection))
                {
                    using(SqlDataReader sqlDataReader = getAllTitleTypes.ExecuteReader()) 
                    {
                        if(sqlDataReader.HasRows)
                        {
                            while(sqlDataReader.Read()) 
                            {
                                titleTypes.Add(new TitleType(
                                    sqlDataReader.GetInt32(0),
                                    sqlDataReader.GetString(1)
                                    ));
                            }
                        }
                    }
                }
            }
            return titleTypes;
        }
        public static List<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand getAllGenres = new SqlCommand("SELECT * FROM Genres", connection))
                {
                    using (SqlDataReader sqlDataReader = getAllGenres.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                genres.Add(new Genre(
                                    sqlDataReader.GetInt32(0),
                                    sqlDataReader.GetString(1)
                                    ));
                            }
                        }
                    }
                }
            }
            return genres;
        }
        public static void InsertTitles(List<Title> titles)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Tconst",typeof (string));
            dataTable.Columns.Add("TitleTypeID", typeof (int));
            dataTable.Columns.Add("PrimaryTitle", typeof(string));
            dataTable.Columns.Add("OriginalTitle", typeof (string));
            dataTable.Columns.Add("IsAdult", typeof(bool));
            dataTable.Columns.Add("StartYear", typeof(int));
            dataTable.Columns.Add("EndYear", typeof (int));
            dataTable.Columns.Add("RunTimeMinutes", typeof(int));
            foreach(Title title in titles) 
            {
                DataRow rows = dataTable.NewRow();
                rows["Tconst"] = title.Tconst;
                rows["TitleTypeID"] = title.TitleTypeID;
                rows["PrimaryTitle"] = title.PrimaryTitle;
                rows["OriginalTitle"] = title.OriginalTitle;
                rows["IsAdult"] = title.IsAdult;
                FillRowValue(rows, "StartYear", title.StartYear);
                FillRowValue(rows, "EndYear", title.EndYear);
                FillRowValue(rows, "RunTimeMinutes", title.RunTimeMinutes);
                dataTable.Rows.Add(rows);
            }

            DataTable genreDataTable = new DataTable();
            genreDataTable.Columns.Add("Tconst", typeof(string));
            genreDataTable.Columns.Add("GenreID", typeof(int));
            foreach (Title title in titles)
            {
                foreach (int genreID in title.Genres)
                {
                    DataRow genreRow = genreDataTable.NewRow();
                    genreRow["Tconst"] = title.Tconst;
                    genreRow["GenreID"] = genreID;
                    genreDataTable.Rows.Add(genreRow);
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            using(SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                connection.Open();
                bulkCopy.DestinationTableName = "Titles";
                bulkCopy.WriteToServer(dataTable);
                bulkCopy.DestinationTableName = "Titles_Genres";
                bulkCopy.WriteToServer(genreDataTable);
            }
        }
        private static void FillRowValue(DataRow row, string columnName, object? value)
        {
            if(value == null)
            {
                row[columnName] = DBNull.Value;
            }
            else
            {
                row[columnName] = value;
            }
        }

        public static void InsertProfessions(List<string> professions)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand cmd = new SqlCommand("INSERT INTO Professions VALUES(@profession)",
                connection,transaction);
            SqlParameter profParameter = new SqlParameter("@profession", System.Data.SqlDbType.VarChar, 255);
            cmd.Parameters.Add(profParameter);

            cmd.Prepare();
            foreach(string prof in professions) 
            {
                profParameter.Value = prof;

                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
        }
        public static void InsertNames(List<Name> names)
        {
            DataTable nameTable = new DataTable();
            nameTable.Columns.Add("Nconst", typeof(string));
            nameTable.Columns.Add("PrimaryName", typeof (string));
            nameTable.Columns.Add("BirthYear", typeof(int));
            nameTable.Columns.Add("DeathYear", typeof(int));
            foreach(Name name in names)
            {
                DataRow rows = nameTable.NewRow();
                rows["Nconst"] = name.Nconst;
                FillRowValue(rows, "PrimaryName", name.PrimaryName);
                FillRowValue(rows, "BirthYear", name.BirthYear);
                FillRowValue(rows, "DeathYear", name.DeathYear);
                nameTable.Rows.Add(rows);
            }

            DataTable knownForTable = new DataTable();
            knownForTable.Columns.Add("Nconst",typeof(string));
            knownForTable.Columns.Add("Tconst", typeof(string));
            foreach(Name name in names)
            {
                foreach (string known in name.KnownForTitles) 
                {
                    DataRow rows = knownForTable.NewRow();
                    rows["Nconst"] = name.Nconst;
                    rows["Tconst"] = known;
                    knownForTable.Rows.Add(rows);
                }
            }

            DataTable professionTable = new DataTable();
            professionTable.Columns.Add("Nconst", typeof(string));
            professionTable.Columns.Add("ProfessionID", typeof(int));
            foreach(Name name in names) 
            {
                foreach(int prof in name.PrimaryProfessions)
                {
                    DataRow rows = professionTable.NewRow();
                    rows["Nconst"] = name.Nconst;
                    rows["ProfessionID"] = prof;
                    professionTable.Rows.Add(rows);
                }
            }
            
            using(SqlConnection connection = new SqlConnection(connectionString))
            using(SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                connection.Open();
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.DestinationTableName = "Names";
                bulkCopy.WriteToServer(nameTable);
                bulkCopy.DestinationTableName = "KnownFor";
                bulkCopy.WriteToServer(knownForTable);
                bulkCopy.DestinationTableName = "PrimaryProfessions";
                bulkCopy.WriteToServer(professionTable);    
            }
        }

        public static List<Profession> GetProfessions()
        {
            List<Profession> professions = new List<Profession>();
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using(SqlCommand getAllProfessions = new SqlCommand("SELECT * FROM Professions",conn)) 
                {
                    using(SqlDataReader sqlDataReader = getAllProfessions.ExecuteReader()) 
                    {
                        if(sqlDataReader.HasRows)
                        {
                            while(sqlDataReader.Read()) 
                            {
                                professions.Add(new Profession(
                                    sqlDataReader.GetInt32(0),
                                    sqlDataReader.GetString(1)
                                    ));
                            }
                        }
                    }
                }
            }
            return professions;
        }
        private static int? GetByProfession(string prof)
        {
            using(SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();
                using(SqlCommand cmd = new SqlCommand("SELECT ProfessionID FROM Professions WHERE Profession = @profession",connection)) 
                {
                    SqlParameter profParamater = new SqlParameter("@profession",SqlDbType.VarChar,100);
                    cmd.Parameters.Add(profParamater);
                    cmd.Prepare();
                    profParamater.Value = prof;
                    using(SqlDataReader sqlDataReader = cmd.ExecuteReader())
                    {
                        if(sqlDataReader.HasRows)
                        {
                            while(sqlDataReader.Read())
                            {
                                return sqlDataReader.GetInt32(0);
                            }
                        }
                    }

                }
            }
            return null;
        }
        public static void InsertCrew(List<Crew> crew)
        {
            int? directorReturn = GetByProfession("director");
            int? directorId = null; 
            if(directorReturn != null) 
            {
                directorId = directorReturn;
            }
            int? writerReturn = GetByProfession("writer");
            int? writerId = null;
            if (directorReturn != null)
            {
                writerId = writerReturn;
            }

            DataTable crewTable = new DataTable();
            crewTable.Columns.Add("Tconst", typeof(string));
            crewTable.Columns.Add("Nconst", typeof(string));
            crewTable.Columns.Add("ProfessionID", typeof (int));
            foreach(Crew c in crew) 
            {
                foreach(string director in  c.Directors)
                {
                    DataRow rows = crewTable.NewRow();
                    rows["Tconst"] = c.Tconst;
                    rows["Nconst"] = director;
                    rows["ProfessionID"] = directorId;
                    crewTable.Rows.Add(rows);
                }
                foreach(string writer in c.Writers)
                {
                    DataRow rows = crewTable.NewRow();
                    rows["Tconst"] = c.Tconst;
                    rows["Nconst"] = writer;
                    rows["ProfessionID"] = writerId;
                    crewTable.Rows.Add(rows);
                }
            }
            using(SqlConnection connection = new SqlConnection(connectionString))
            using(SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                connection.Open();
                bulkCopy.DestinationTableName = "Crews";
                bulkCopy.WriteToServer(crewTable);
            }
        }
    }
}
