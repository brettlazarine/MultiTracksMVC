using System.Collections.Generic;
using MultiTracksMVC.Models;

namespace MultiTracksMVC
{
    public interface ISongRepository
    {
        IEnumerable<Song> SearchSongs(int pageSize, int pageNumber);
        public int GetTotalSongCount();
    }
}
