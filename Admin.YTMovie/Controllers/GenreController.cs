using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.DependencyResolvers.Ninject;
using Business.Validations.FluentValidation;
using CoreLayer.Extensions;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YTMovie.Controllers
{
    public class GenreController : Controller
    {
        private IGenreService _genreService = InstanceFactory.GetInstance<IGenreService>();
        public IActionResult Index()
        {
            var genres = _genreService.GetAll();
            if(genres.Data == null)
            {
                return NotFound(genres);
            }
            return View(genres.Data);
        }

        
        [HttpGet]
        public IActionResult AddNewGenre()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewGenre(Genre genre)
        {
            
            if(this.Validate(new GenreValidator(), genre))
            {
                var result = _genreService.Add(genre);

                if(result == null || !result.Success)
                {
                    TempData["message"] = "error";
                    ViewBag.Message = result.Message;
                } else
                {
                    TempData["message"] = "added";
                }
                return RedirectToAction("Index");
            } else
            {
                //doğrulama hatası
            }

            return View();  
        }

        [HttpGet]
        public IActionResult UpdateGenre(int id)
        {
            var genre = _genreService.GetById(id);
            if(genre == null)
            {
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        [HttpPost]
        public IActionResult UpdateGenre(Genre genre)
        {
            return View(genre);
        }
    }
}
