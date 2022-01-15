using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using CoreLayer.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YTMovie.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        ICommentService _commentService = InstanceFactory.GetInstance<ICommentService>();
        IMovieService _movieService = InstanceFactory.GetInstance<IMovieService>();
        public IActionResult Index()
        {
            var result = _commentService.GetAllDetails();
            var movies = _movieService.GetAll();
            ViewBag.Movies = movies.Data;
            return View(result.Data);
        }

        public IActionResult ChangeStatusComment(int id)
        {
            var result = _commentService.ChangeStatus(id);

            this.SetMessage(result);

            return RedirectToAction("Index");
        }

    }
}
