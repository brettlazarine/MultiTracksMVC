using Microsoft.AspNetCore.Mvc;
using MultiTracksMVC.Models;
using MultiTracksMVC;

public class ArtistController : Controller
{
    private readonly IArtistRepository _artistRepository;
    private readonly ISongRepository _songRepository;

    public ArtistController(IArtistRepository artistRepository, ISongRepository songRepository)
    {
        _artistRepository = artistRepository;
        _songRepository = songRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SearchArtist(string artistName)
    {
        var artists = _artistRepository.SearchArtists(artistName);
        return View(artists);
    }

    public IActionResult AddArtist()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddArtist(Artist artist)
    {
        if (ModelState.IsValid)
        {
            _artistRepository.AddArtist(artist);
            return RedirectToAction("SearchArtist");
        }

        return View(artist);
    }
    public IActionResult GetAllSongs(int pageSize = 10, int pageNumber = 1)
    {
        var songs = _songRepository.SearchSongs(pageSize, pageNumber);

        // Get total song count for pagination
        int totalSongs = _songRepository.GetTotalSongCount();
        int totalPages = (int)Math.Ceiling((double)totalSongs / pageSize);

        // Set ViewBag properties for pagination links
        ViewBag.PageSize = pageSize;
        ViewBag.PageNumber = pageNumber;
        ViewBag.TotalPages = totalPages;
        ViewBag.TotalSongs = totalSongs;

        return View(songs);
    }


}
