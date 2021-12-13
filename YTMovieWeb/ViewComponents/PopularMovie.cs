using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Microsoft.AspNetCore.Mvc;

namespace YTMovieWeb.ViewComponents
{
    [ViewComponent]
    public class PopularMovie : ViewComponent
    {
        private IMovieService _movieService = InstanceFactory.GetInstance<IMovieService>();
        public IViewComponentResult Invoke()
        {
            var result = _movieService.GetMoviesByDetails();
            if (result == null || !result.Success || result.Data == null)
            {
                return View("Error");
            }
            var popularMovies = result.Data.OrderByDescending(x => x.Movie.View).Take(5).ToList();
            
            return View(popularMovies);
        }

    }
}
