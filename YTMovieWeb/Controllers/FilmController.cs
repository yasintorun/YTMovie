using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Microsoft.AspNetCore.Mvc;

namespace YTMovieWeb.Controllers
{
    public class FilmController : Controller
    {
        IMovieService _movieService = InstanceFactory.GetInstance<IMovieService>();

        public IActionResult Index()
        {
            var allMovies = _movieService.GetMoviesByDetails();
            if(allMovies == null || allMovies.Data == null || !allMovies.Success)
            {
                return View("Error");
            }

            return View(allMovies.Data);
        }

        public IActionResult Detay(int id)
        {
            var movieResult = _movieService.GetDetail(id);
            if(movieResult == null || !movieResult.Success)
            {
                return View("Error");
            }

            return View(movieResult.Data);
        }

    }
}