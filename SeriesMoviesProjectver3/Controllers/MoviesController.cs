using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeriesMoviesProjectver3.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace SeriesMoviesProjectver3.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        SeriesMoviesDatabaseEntities smd = new SeriesMoviesDatabaseEntities();
        public ActionResult Index(int values=1)
        {
            var movies = smd.Tbl_Movies.ToList().ToPagedList(values,5);
            return View(movies);
        }

        [HttpGet]
        public ActionResult NewMovies()
        {
            List<SelectListItem> movies = (from i in smd.Tbl_Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.ID.ToString()
                                           }

                                         ).ToList();
            ViewBag.val = movies;
            return View();
        }

        [HttpPost]
        public ActionResult NewMovies(Tbl_Movies movies)
        {
            var cat = smd.Tbl_Category.Where(x => x.ID == movies.Tbl_Category.ID).FirstOrDefault();
            movies.Tbl_Category = cat;
            smd.Tbl_Movies.Add(movies);
            smd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMovies(int id)
        {
            var movies = smd.Tbl_Movies.Find(id);
            smd.Tbl_Movies.Remove(movies);
            smd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetMovies(int id)
        {

            var movies = smd.Tbl_Movies.Find(id);
            return View("GetMovies", movies);
        }
        [HttpPost]
        public ActionResult UpdateMovies(Tbl_Movies movies)
        {

            var mov = smd.Tbl_Movies.Find(movies.ID);
            mov.MoviesName = movies.MoviesName;
            mov.Director = movies.Director;
            mov.Description = movies.Description;
            mov.IMDB = movies.IMDB;
            mov.Image = movies.Image;
            mov.Category = movies.Category;
            smd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}