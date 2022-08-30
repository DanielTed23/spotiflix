namespace spotiflix
{
    internal class Series
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? WWW { get; set; }
        public List<Episode> Episodes { get; set; } = new();


        
        public string GetReleaseDate()
        {
            return ReleaseDate.ToString("D");
        }
    }




    internal class Episode
    {
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Season { get; set; }
        public int EpisodeNum { get; set; }
        public DateTime Length { get; set; }
    }




    }




