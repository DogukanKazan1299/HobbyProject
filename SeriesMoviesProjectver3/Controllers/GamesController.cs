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
    public class GamesController : Controller
    {
        // GET: Games
        SeriesMoviesDatabaseEntities smd = new SeriesMoviesDatabaseEntities();
      
        public ActionResult Index(int values = 1)
        {
            var games = smd.Tbl_Games.ToList().ToPagedList(values,5);
            return View(games);
        }

        [HttpGet]
        public ActionResult NewGames()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewGames(Tbl_Games games)
        {
            smd.Tbl_Games.Add(games);
            smd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteGames(int id)
        {
            var games = smd.Tbl_Games.Find(id);
            smd.Tbl_Games.Remove(games);
            smd.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult GetGames(int id)
        {
            var games = smd.Tbl_Games.Find(id);
            return View("GetGames", games);
        }
        public ActionResult UpdateGames(Tbl_Games games)
        {
            var game = smd.Tbl_Games.Find(games.ID);
            game.Gamename = games.Gamename;
            game.Director = games.Director;
            game.Technology = games.Technology;
            game.ReleaseDate = games.ReleaseDate;
            game.Image = games.Image;
            game.Category = games.Category;
            smd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}