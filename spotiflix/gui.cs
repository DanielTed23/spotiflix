using spotiflix;

namespace OOPSpotiflixV2
{
    internal class Gui
    {

        Data data = new Data();
        private string path = @"C:\Users\danie\OneDrive\Skrivebord\Data\savedata.txt";
        public Gui()
        {

            data.MovieList = new();
            data.SeriesList = new();
            LoadData();

            while (true)
            {
                Menu();
            }
        }

        private void Menu()
        {
            Console.WriteLine("\nMENU\n1 for movies\n2 for series\n3 for music\n4 for save\n5 for load");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    MovieMenu();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SeriesMenu();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    SaveData();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    LoadData();
                    break;
                default:
                    break;
            }
        }
        private void SaveData()
        {

            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path, json);
            Console.WriteLine("File Saved Succesfully at " + path);
        }

        private void LoadData()
        {
            string json = File.ReadAllText(path);
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
            Console.WriteLine("File loaded succesfully from " + path);
        }

        private void SeriesMenu()
        {
            Console.WriteLine("\nSERIES MENU\n1 for list of series\n2 for search series\n3 for add new series");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowSeriesList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchSeries();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddSeries();
                    break;



                default:
                    break;
            }
        }

        private void MovieMenu()
        {
            Console.WriteLine("\nMOVIE MENU\n1 for list of movies\n2 for search movies\n3 for add new movie");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowMovieList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchMovie();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddMovie();
                    break;

                default:
                    break;
            }
        }

        
        private void AddSeries()


        {
            Console.Clear();
            Series series = new Series();
            series.Title = GetString("Title: ");
            series.Genre = GetString("Genre: ");
            series.ReleaseDate = GetReleaseDate();
            series.WWW = GetString("WWW: ");

            ShowSeries(series);
            Console.WriteLine("Confirm adding to list (Y/N)");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Y:
                    data.SeriesList.Add(series);
                    break;
                default:
                    break;
            }
        }

        private void AddEpisodes(Series serie)
        {
            Console.Clear();
            Episode episode = new Episode();
            episode.Title = GetString("Title: ");
            episode.Title = Console.ReadLine();
            episode.Season = GetInt("Season: ");
            episode.Season = int.Parse(Console.ReadLine());
            episode.EpisodeNum = GetInt("Episode Number: ");
            episode.EpisodeNum = int.Parse(Console.ReadLine());
            episode.ReleaseDate = GetReleaseDate();
            Console.WriteLine("Confirm adding to list (N/Y)");
            if (Console.ReadKey().Key == ConsoleKey.Y) serie.Episodes.Add(episode);
        }

    


            private void AddMovie()
        {
            Console.Clear();
            Movie movie = new Movie();
            movie.Title = GetString("Title: ");
            movie.Length = GetLength();
            movie.Genre = GetString("Genre: ");
            movie.ReleaseDate = GetReleaseDate();
            movie.WWW = GetString("WWW: ");

            ShowMovie(movie);
            Console.WriteLine("Confirm adding to list (Y/N)");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Y:
                    data.MovieList.Add(movie);
                    break;
                default:
                    break;
            }
        }

        private void SearchSeries()
        {
            Console.Clear();
            Console.Write("Search: ");
            string? search = Console.ReadLine().ToUpper();
            foreach (Series series in data.SeriesList)
            {
                if (search != null)
                {
                    if (series.Title.ToUpper().Contains(search) || series.Genre.ToUpper().Contains(search))
                        ShowSeries(series);
                }
            }
        }

        private void SearchMovie()
        {
            Console.Clear();
            Console.Write("Search: ");
            string? search = Console.ReadLine().ToUpper();
            foreach (Movie movie in data.MovieList)
            {
                if (search != null)
                {
                    if (movie.Title.ToUpper().Contains(search) || movie.Genre.ToUpper().Contains(search))
                        ShowMovie(movie);
                }
            }
        }

        private DateTime GetLength()
        {
            DateTime to;
            do
            {
                Console.Write("Length (hh:mm:ss): ");
            }
            while (!DateTime.TryParse("01-01-0001 " + Console.ReadLine(), out to));
            return to;
        }
        private DateTime GetReleaseDate()
        {
            DateTime dateOnly;
            do
            {
                Console.Write("Release Date (dd/mm/yyyy): ");
            }
            while (!DateTime.TryParse(Console.ReadLine(), out dateOnly));
            return dateOnly;
        }
        private string GetString(string type)
        {
            string? input;
            do
            {
                Console.Write(type);
                input = Console.ReadLine();
            }
            while (input == null || input == "");
            return input;
        }

        private int GetInt(string request)
        {
            int result;
            do
            {
                Console.WriteLine(request);
            }
            while (!int.TryParse(Console.ReadLine(), out result));
            return result;
        }
        private void ShowMovie(Movie m)
           
        {
            Console.Clear();
            Console.WriteLine($"{m.Title} {m.GetLength()} {m.Genre} {m.GetReleaseDate()} {m.WWW}");
        }

        private void ShowMovieList()
        {

            foreach (Movie m in data.MovieList)
            {
                Console.Clear();
                ShowMovie(m);
            }
        }



        private void ShowSeries(Series s)

        {
            Console.Clear();
            Console.WriteLine($"{s.Title}  {s.Genre} {s.GetReleaseDate()} {s.WWW}");
        }

        private void ShowSeriesList()
        {
            foreach (Series s in data.SeriesList)
            {
                Console.Clear();
                ShowSeries(s);
            }
        }
    }
}