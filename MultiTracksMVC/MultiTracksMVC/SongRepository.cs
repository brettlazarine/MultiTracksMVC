using Dapper;
using MultiTracksMVC.Models;
using System.Collections.Generic;
using System.Data;

namespace MultiTracksMVC
{
    public class SongRepository : ISongRepository
    {
        private readonly IDbConnection _conn;

        public SongRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Song> SearchSongs(int pageSize, int pageNumber)
        {
            int offset = (pageNumber - 1) * pageSize;
            string query = "SELECT * FROM Song LIMIT @pageSize OFFSET @offset";
            return _conn.Query<Song>(query, new { pageSize, offset });
        }

        public int GetTotalSongCount()
        {
            string query = "SELECT COUNT(*) FROM Song";
            return _conn.ExecuteScalar<int>(query);
        }

    }
}
