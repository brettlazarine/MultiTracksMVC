namespace MultiTracksMVC.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public DateTime DateCreation { get; set; }
        public int ArtistID { get; set; }
        public string? Title { get; set; }
        public string? ImageURL { get; set; }
        public int Year { get; set; }
    }
}
