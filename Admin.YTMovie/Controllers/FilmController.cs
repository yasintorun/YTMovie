using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Business.Validations.FluentValidation;
using CoreLayer.Extensions;
using Entities.Dtos;
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
        private IGenreService _genreService = InstanceFactory.GetInstance<IGenreService>();
        private IMovieGenreService _movieGenreService = InstanceFactory.GetInstance<IMovieGenreService>();
        public IActionResult Index()
        {
            var movies = _movieService.GetMovieDetails();

            return View(movies.Data);
        }


        [HttpGet]
        public IActionResult AddNewMovie()
        {
            var genres = _genreService.GetAll();
            ViewBag.Genres = genres.Data;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewMovie(AddMovieDto addMovieDto)
        {
            if(this.Validate(new MovieValidator(), addMovieDto.Movie))
            {
                var result = _movieService.AddWithGenres(addMovieDto);   
                
                this.SetMessage(result);

                return RedirectToAction("Index");
            } else 
            {
                //doğrulama hatası
            }
            return AddNewMovie();
        }
    }
}
