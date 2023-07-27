using Microsoft.AspNetCore.Mvc;
using MultiTracksMVC.Models;

namespace MultiTracksMVC
{
    public interface IArtistRepository
    {
        public IEnumerable<Artist> SearchArtists(string artistName);
        public void AddArtist(Artist artist);
        List<Song> GetSongs(int pageSize, int pageNumber);
    }
}
