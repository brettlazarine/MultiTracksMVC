using Dapper;
using Microsoft.AspNetCore.Mvc;
using MultiTracksMVC.Models;
using System.Data;

namespace MultiTracksMVC
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IDbConnection _conn;

        public ArtistRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Artist> SearchArtists(string artistName)
        {
                string query = "SELECT * FROM Artist WHERE Title LIKE @artistName";
                return _conn.Query<Artist>(query, new { artistName });
        }

        public void AddArtist(Artist artist)
        {
            string query = "INSERT INTO Artist (DateCreation, Title, Biography, ImageURL, HeroURL) " +
                           "VALUES (@DateCreation, @Title, @Biography, @ImageURL, @HeroURL)";

            artist.DateCreation = DateTime.Now; 

            _conn.Execute(query, artist);
        }
        public List<Song> GetSongs(int pageSize, int pageNumber)
        {
            int startRow = (pageNumber - 1) * pageSize + 1;
            int endRow = pageNumber * pageSize;

            string query = "SELECT * FROM Song ORDER BY SongID LIMIT @StartRow, @PageSize";
            return _conn.Query<Song>(query, new { StartRow = startRow, PageSize = pageSize }).ToList();
        }

    }
}
