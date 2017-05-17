using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {

            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
 


        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
               Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
             if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    //Movie = Movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);

            }
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var MovieDB = _context.Movies.Single(c => c.Id == movie.Id);
                MovieDB.Name = movie.Name;
                MovieDB.DateAdded = movie.DateAdded;
                MovieDB.ReleaseDate = movie.ReleaseDate;
                MovieDB.NumberInStock = movie.NumberInStock;
                MovieDB.GenreId = movie.GenreId;

            }

            try
            {
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }            
            return RedirectToAction("Index", "Movies");
        }

        //Edit Movie
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
    }
}