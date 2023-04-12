using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.Service;


namespace MovieApp.Controllers
{

    public class MoviesController : Controller
    {
        public IMovieService _service;
        public MoviesController(IMovieService movieService) {
            _service = movieService;
        }

        public async Task<ActionResult> Index() {
            ViewBag.genres = await _service.GetGenre();
            ViewBag.trending = await _service.GetTrending();
            ViewBag.upcoming = await _service.GetUpcoming();
            ViewBag.popular = await _service.GetPopular();
            ViewBag.toprated = await _service.GetTopRated();
            return View();
        }

        public async Task<ActionResult> Detail(int id)
        {
            ViewBag.genres = await _service.GetGenre();
            ViewBag.detail = await _service.GetDetail(id);
            ViewBag.similar = await _service.GetSimilarMovie(id);
            return View();
        }

        public async Task<ActionResult> MovieList(int id ,int? pageNumber)
        {
            ViewBag.genres = await _service.GetGenre();
            List<Result> result = await _service.GetGenreMovie(id);
            int pageSize = 10;
            return View(await PaginatedList<Result>.CreateAsync(result, pageNumber ?? 1, pageSize));
        }

        public async Task<ActionResult> SearchMovie(string key, int? pageNumber)
        {
            ViewBag.genres = await _service.GetGenre();
            List<Result> result = await _service.GetSearchMovie(key);
            int pageSize = 10;
            return View("MovieList",await PaginatedList<Result>.CreateAsync(result, pageNumber ?? 1, pageSize));
        }

    }
}
