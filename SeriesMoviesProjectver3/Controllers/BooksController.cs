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
    public class BooksController : Controller
    {
        // GET: Books
        SeriesMoviesDatabaseEntities smd = new SeriesMoviesDatabaseEntities();
        public ActionResult Index(int values=1)
        {
            var books = smd.Tbl_Books.ToList().ToPagedList(values,5);
            return View(books);
        }

        [HttpGet]
        public ActionResult NewBooks()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewBooks(Tbl_Books books)
        {
            var book = smd.Tbl_Books.Add(books);
            smd.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBooks(int id)
        {
            var books = smd.Tbl_Books.Find(id);
            smd.Tbl_Books.Remove(books);
            smd.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetBooks(int id)
        {
            var books = smd.Tbl_Books.Find(id);
            return View("GetBooks", books);
        }

        public ActionResult UpdateBooks(Tbl_Books books)
        {
            var book = smd.Tbl_Books.Find(books.ID);
            book.BookName = books.BookName;
            book.Writer = books.Writer;
            book.ReleaseYear = books.ReleaseYear;
            book.Image = books.Image;
            book.Category = books.Category;
            smd.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}