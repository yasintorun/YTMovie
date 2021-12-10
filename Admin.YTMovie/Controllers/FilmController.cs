using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Business.Validations.FluentValidation;
using CoreLayer.Extensions;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.YTMovie.Controllers
{
    public class FilmController : Controller
    {
        private IMovieService _movieService = InstanceFactory.GetInstance<IMovieService>();
        [Route("Film")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public PartialViewResult AddNewMovie()
        {
            return PartialView();
        }

        [HttpPost]
        public void AddNewMovie(Movie movie)
        {
            if(this.Validate(new MovieValidator(), movie))
            {
                var result = _movieService.Add(movie);
                if(result.Success)
                {

                }
            } else 
            {
                //doğrulama hatası
            }
        }
    }
}
