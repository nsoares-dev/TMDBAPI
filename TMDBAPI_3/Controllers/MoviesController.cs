using Microsoft.AspNetCore.Mvc;
using TMDBAPI_3.Services;

namespace TMDBAPI_3.Controllers
{
    public class MoviesController : Controller
    {

        private readonly TmdbService _tmdbService;

        public MoviesController(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var genres = await _tmdbService.GetGenreAsync();

            return View(genres);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string query, int? genreId, int? year)
        {
            var movies = await _tmdbService.SearchMoviesAsync(query, genreId, year);

            return View(movies);
        }

    }
}
