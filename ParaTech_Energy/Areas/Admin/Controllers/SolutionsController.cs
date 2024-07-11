using ParaTech_Energy.Controllers;
using ParaTech_Energy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace ParaTech_Energy.Areas.Admin.Controllers
{
    public class SolutionsController : BaseController
    {
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        // GET: Admin/Content
        public ActionResult Solution()
        {
            Paratech_EnergyEntities db = new Paratech_EnergyEntities();
            var data = (from u in db.Solutions select u).ToList();
            return View(data);
        }
        public ActionResult SolutionCreate()
        {
            ViewBag.PageNameddl = new SelectList(db.Solutions.GroupBy(x=>x.PageName).Select(x => new { Value = x.Key, Text = x.Key }), "Value", "Text");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult SolutionCreate(FormCollection form, Solution data, Pictures pic)
        {
            if (ModelState.IsValid)
            {
                if (pic.File != null)
                {
                    DateTime current = DateTime.Now;
                    long tick = current.Ticks;
                    var picture = Path.GetFileName(tick + "_" + data.PageTitle + "_" + data.PageName);
                    var ext = Path.GetExtension(pic.File.FileName);
                    string path = Path.Combine(Server.MapPath("~/images/ProjectImages/"), picture + ext);
                    string savepath = "~/images/ProjectImages/" + picture + ext;
                    pic.File.SaveAs(path);
                    data.PageImage = savepath;
                }
                db.Solutions.Add(data);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("Solution");
            }
            else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("Solution");
            }
        }
        public ActionResult EditSolution(int Id)
        {
            ViewBag.PageNameddl = new SelectList(db.Solutions.GroupBy(x => x.PageName).Select(x => new { Value = x.Key, Text = x.Key }), "Value", "Text");
            var edt = db.Solutions.Where(x => x.ID == Id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditSolution(FormCollection form, Solution data, Pictures pic)
        {
            if (ModelState.IsValid)
            {
                var edt = db.Solutions.Where(x => x.ID == data.ID).FirstOrDefault();
                string savepath = null;
                if (edt != null)
                {
                    DateTime current = DateTime.Now;
                    long tick = current.Ticks;
                    if (pic.File != null)
                    {
                        FileInfo myfileinf = new FileInfo(Server.MapPath(edt.PageImage));
                        if (System.IO.File.Exists(myfileinf.FullName))
                        {
                            System.IO.File.Delete(myfileinf.FullName);
                        }
                        var picture = Path.GetFileName(edt.PageImage);
                        var ext = Path.GetExtension(pic.File.FileName);
                        string path = Path.Combine(Server.MapPath("~/images/ProjectImages/"), picture);
                        savepath = "~/images/ProjectImages/" + picture + ext;
                        pic.File.SaveAs(path);
                    }
                    //db.Entry(data).State = EntityState.Modified;
                    edt.PageName = data.PageName;
                    edt.PageTitle = data.PageTitle;
                    edt.NewPage = data.NewPage;
                    edt.PageDes = data.PageDes;
                    edt.MetaDescription = data.MetaDescription;
                    edt.MetaKeywords = data.MetaKeywords;
                    edt.MetaTitle = data.MetaTitle;
                    if (!string.IsNullOrEmpty(savepath))
                    {
                        edt.PageImage = savepath;
                    }
                    db.SaveChanges();
                    TempData["Done"] = "Your Data Has Been Successfully Updated";
                    return RedirectToAction("Solution");
                }
            }
            return View(data);
        }

        public JsonResult DeleteSolution(Int32 Id)
        {
            Solution product = db.Solutions.Where(x => x.ID == Id).FirstOrDefault();
            FileInfo myfileinf = new FileInfo(Server.MapPath(product.PageImage));
            if (System.IO.File.Exists(myfileinf.FullName))
            {
                System.IO.File.Delete(myfileinf.FullName);
            }
            db.Solutions.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}