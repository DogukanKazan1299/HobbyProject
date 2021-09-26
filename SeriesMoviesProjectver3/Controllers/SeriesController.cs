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
    public class SeriesController : Controller
    {
        // GET: Series
        SeriesMoviesDatabaseEntities smd = new SeriesMoviesDatabaseEntities();
        public ActionResult Index(int values=1)
        {
            var series = smd.Tbl_Series.ToList().ToPagedList(values,5);
            return View(series);
        }

        [HttpGet]
        public ActionResult NewSeries()
        {
            List<SelectListItem> series = (from i in smd.Tbl_Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.ID.ToString()
                                           }

                                         ).ToList();
            ViewBag.val = series;
            return View();
        }

        [HttpPost]
        public ActionResult NewSeries(Tbl_Series series)
        {
            
            var cat = smd.Tbl_Category.Where(x => x.ID == series.Tbl_Category.ID).FirstOrDefault();
            series.Tbl_Category = cat;
            smd.Tbl_Series.Add(series);
            smd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSeries(int id)
        {
            var series = smd.Tbl_Series.Find(id);
            smd.Tbl_Series.Remove(series);
            smd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetSeries(int id)
        {
            
            var series = smd.Tbl_Series.Find(id);
            return View("GetSeries", series);
        }
        [HttpPost]
        public ActionResult UpdateSeries(Tbl_Series series)
        {
            
            var seri = smd.Tbl_Series.Find(series.ID);
            seri.SeriesName = series.SeriesName;
            seri.Director = series.Director;
            seri.Description = series.Description;
            seri.IMDB = series.IMDB;
            seri.Image = series.Image;
            seri.Category = series.Category;
            smd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}