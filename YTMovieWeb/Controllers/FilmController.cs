using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Business.Validations.FluentValidation;
using CoreLayer.Extensions;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace YTMovieWeb.Controllers
{
    public class FilmController : Controller
    {
        IMovieService _movieService = InstanceFactory.GetInstance<IMovieService>();
        ICommentService _commentService = InstanceFactory.GetInstance<ICommentService>();

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

            var comments = _commentService.GetByMovieId(id);
            if(comments.Success && comments.Data != null)
            {
                ViewBag.Comments = comments.Data;
            }

            ViewBag.MovieId = id;
            return View(movieResult.Data);
        }
        

        public List<Entities.Dtos.MovieDto> PopularMovieList()
        {
            var result = _movieService.GetMoviesByDetails();
            if (result == null || !result.Success || result.Data == null)
            {
                return new List<Entities.Dtos.MovieDto>();
            }
            var popularMovies = result.Data.OrderByDescending(x => x.Movie.View).Take(5);

            return popularMovies.ToList();
        }

        [HttpGet]
        public PartialViewResult CommentForm()
        {

            Comment comment = new Comment();

            return PartialView(comment);
        }

        [HttpPost]
        public IActionResult CommentForm(Comment comment)
        {
         
            if(this.Validate(new CommentValidator(), comment))
            {

                var addResult = _commentService.Add(comment);
                this.SetMessage(addResult);
            }
            return RedirectToAction("Detay", new {id = comment.MovieId });
        }

    }
}