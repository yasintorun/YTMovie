using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Business.Validations.FluentValidation;
using Core.Utils.Results;
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
            var movies = _movieService.GetMoviesByDetails();

            return View(movies.Data);
        }

        //Gerçek sitedeki detay sayfasını görüntüleyecek.
        //public IActionResult Detay(int id)
        //{
        //    var movieResult = _movieService.GetById(id);
        //    if(!movieResult.Success || movieResult.Data == null)
        //    {
        //        this.SetMessage(movieResult);

        //        return RedirectToAction("Index");
        //    }

        //    return View(movieResult.Data);
        //}


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

        [HttpGet]
        public IActionResult EditMovie(int id)
        {   
            var movieResult = _movieService.GetDetail(id);
            if(!movieResult.Success || movieResult.Data == null)
            {
                this.SetMessage(movieResult);
                return RedirectToAction("Index");
            }

            var genres = _genreService.GetAll();
            ViewBag.Genres = genres.Data;

            AddMovieDto dto = new AddMovieDto()
            {
                Id = id,
                Movie = movieResult.Data.Movie,
                GenreIds = movieResult.Data.Genres.Select(x => x.Id).ToArray(),
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult EditMovie(AddMovieDto addMovieDto)
        {

            if (this.Validate(new MovieValidator(), addMovieDto.Movie))
            {
                var result = _movieService.EditWithGenres(addMovieDto);

                this.SetMessage(result);

                return RedirectToAction("Index");
            }
            else
            {
                //doğrulama hatası
            }

            return View(addMovieDto);
        }

        [HttpGet]
        public IActionResult DeleteMovie(int id)
        {
            var deleteResult = _movieService.Delete(new Movie { Id=id});

            this.SetMessage(deleteResult);

            return RedirectToAction("Index");
        }
    }
}
