namespace spotiflix
{
    internal class Music
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? WWW { get; set; }
        public List<Song> Songs { get; set; } = new();

    }
    internal class Song
    {
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        public DateTime Lengt { get; set; }
    }
}