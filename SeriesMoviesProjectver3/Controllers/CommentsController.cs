using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeriesMoviesProjectver3.Models.Entity;


namespace SeriesMoviesProjectver3.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        SeriesMoviesDatabaseEntities smd = new SeriesMoviesDatabaseEntities();
        public ActionResult Index()
        {
            var comment = smd.Tbl_Comment.ToList();
            return View(comment);
        }
        [HttpGet]
        public ActionResult NewComments()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewComments(Tbl_Comment comments)
        {
            var comment = smd.Tbl_Comment.Add(comments);
            smd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteComments(int id)
        {
            var comment = smd.Tbl_Comment.Find(id);
            smd.Tbl_Comment.Remove(comment);
            smd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetComments(int id)
        {
            var comments = smd.Tbl_Comment.Find(id);
            return View("GetComments", comments);
        }
        public ActionResult UpdateComments(Tbl_Comment comments)
        {
            var comment = smd.Tbl_Comment.Find(comments.ID);
            comment.Comment = comments.Comment;
            comment.Username = comments.Username;
            smd.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}