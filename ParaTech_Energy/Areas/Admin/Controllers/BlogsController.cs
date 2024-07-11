using ParaTech_Energy.Controllers;
using ParaTech_Energy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParaTech_Energy.Areas.Admin.Controllers
{
    public class BlogsController : BaseController
    {
        // GET: Admin/BlogNews
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        // GET: Admin/Content
        public ActionResult BlogNews()
        {
            Paratech_EnergyEntities db = new Paratech_EnergyEntities();
            var data = (from u in db.BlogNews select u).ToList();
            return View(data);
        }
        public ActionResult BlogNewsCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BlogNewsCreate(FormCollection form)
        {
            string title = form["Title"];
            var pag = (from u in db.BlogNews
                       where u.Title == title
                       select u).FirstOrDefault();
            if (pag == null)
            {
                BlogNew blogs = new BlogNew();
                blogs.PageName = form["PageName"];
                blogs.Title = form["Title"];
                blogs.CreateDate = Convert.ToDateTime(form["Date"]);
                blogs.Category = form["Category"];
                blogs.Tags = form["Tags"];
                blogs.Description = form["Description"];
                db.BlogNews.Add(blogs);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("BlogNews");
            }
            else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("BlogNews");
            }
        }

        public ActionResult EditBlogNews(int Id)
        {
            var edt = db.BlogNews.Where(x => x.ID == Id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditBlogNews(FormCollection form)
        {
            int Id = Convert.ToInt32(Request.Form["ID"].ToString());
            var blogs = db.BlogNews.Where(x => x.ID == Id).FirstOrDefault();
            if (blogs != null)
            {
                blogs.PageName = form["PageName"];
                blogs.Title = form["Title"];
                blogs.CreateDate = Convert.ToDateTime(form["Date"]).Date;
                blogs.Category = form["Category"];
                blogs.Tags = form["Tags"];
                blogs.Description = form["Description"];

                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Updated";
                return RedirectToAction("BlogNews");

            }
            return View(blogs);
        }
        public JsonResult DeleteBlogNews(Int32 bid)
        {
            BlogNew product = db.BlogNews.Where(x => x.ID == bid).FirstOrDefault();
            db.BlogNews.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}