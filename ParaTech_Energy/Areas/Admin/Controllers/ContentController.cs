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
    public class ContentController : BaseController
    {
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        // GET: Admin/Content
        public ActionResult Content()
        {
            Paratech_EnergyEntities db = new Paratech_EnergyEntities();
            var data = (from u in db.Contents select u).ToList();
            return View(data);
        }
        public ActionResult ContentCreate()
        { 
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ContentCreate(FormCollection form)
        {
            string title = form["Title"];
            var pag = (from u in db.Contents
                       where u.Title == title
                       select u).FirstOrDefault();
            if (pag == null)
            {
                Content pcon = new Content();
                pcon.Title = title;
                //pcon.Title = form["Title"];
                pcon.Page = form["Page"];
                pcon.PContnt = form["CText"];
                db.Contents.Add(pcon);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("Content");
            }
            else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("Content");
            }
        }

        public ActionResult EditContent(int Id)
        {
            var edt = db.Contents.Where(x => x.pID == Id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditContent(FormCollection form)
        {
            int Id = Convert.ToInt32(Request.Form["pID"].ToString());
            var pcon = db.Contents.Where(x => x.pID == Id).FirstOrDefault();
            if (pcon != null)
            {
                pcon.Title = form["Title"];
                pcon.Page = form["Page"];
                pcon.PContnt = form["CText"];
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Updated";
                return RedirectToAction("Content");

            }
            return View(pcon);
        }
        public JsonResult DeleteContent(Int32 pID)
        {
            Content product = db.Contents.Where(x => x.pID == pID).FirstOrDefault();
            db.Contents.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult WebImages()
        {
            Paratech_EnergyEntities db = new Paratech_EnergyEntities();
            var data = (from u in db.WebImages select u).ToList();
            return View(data);
        }
        public ActionResult AddWebImages()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWebImages(FormCollection form, WebImage imag,Pictures pic)
        {
            if (ModelState.IsValid)
            {
                imag.PageName = imag.PageName;
                imag.PageLocation = imag.PageLocation;
                DateTime current = DateTime.Now;
                long tick = current.Ticks;
                var picture = Path.GetFileName(tick+"_"+imag.PageName+"_"+imag.PageLocation);
                var ext = Path.GetExtension(pic.File.FileName);
                string path = Path.Combine(Server.MapPath("~/images/webimg/"), picture+ext);
                string savepath = "~/images/webimg/" + picture + ext;
                pic.File.SaveAs(path);
                imag.ImagePath = savepath;
                db.WebImages.Add(imag);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("WebImages");
            }
            else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("WebImages");
            }
        }
        public ActionResult EditWebImages(int id)
        {
            var edt = db.WebImages.Where(x => x.ID == id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWebImages(FormCollection form, WebImage imag, Pictures pic)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(form["ID"]);
                var edt = db.WebImages.Where(x => x.ID == id).FirstOrDefault();
                if (edt != null)
                {
                    DateTime curent = DateTime.Now;
                    long ticks = curent.Ticks;
                    edt.PageName = imag.PageName;
                    edt.PageLocation = imag.PageLocation;
                    if (pic.File != null && pic.File.ContentLength > 0)
                    {
                        if(edt.ImagePath !=null && edt.ImagePath != "")
                        {
                            System.IO.File.Delete(Request.PhysicalApplicationPath + edt.ImagePath.Replace("~",""));
                        }
                        var picture = Path.GetFileName(ticks + "_" + imag.PageName + "_" + imag.PageLocation);
                        string path = Path.Combine(Server.MapPath("~/images/webimg/"), picture + pic.File.FileName.Substring(pic.File.FileName.LastIndexOf(".")));
                        string savepath = "~/images/webimg/" + picture + pic.File.FileName.Substring(pic.File.FileName.LastIndexOf("."));
                        edt.ImagePath = savepath;
                        pic.File.SaveAs(path);
                    }
                    db.SaveChanges();
                    TempData["Done"] = "Your Data Has Been Successfully Updated";
                    return RedirectToAction("WebImages");
                }
            }
            return View(imag);
        }
        public JsonResult DeleteWebImages(Int32 ID)
        {
            WebImage product = db.WebImages.Where(x => x.ID == ID).FirstOrDefault();
            FileInfo myfileinf = new FileInfo(Server.MapPath(product.ImagePath));
            if (System.IO.File.Exists(myfileinf.FullName))
            {
                System.IO.File.Delete(myfileinf.FullName);
            }

            db.WebImages.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }

    
}