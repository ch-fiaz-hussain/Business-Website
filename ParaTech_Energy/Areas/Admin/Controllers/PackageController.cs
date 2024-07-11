using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using ParaTech_Energy.Models;
using ParaTech_Energy.Controllers;
namespace ParaTech_Energy.Areas.Admin.Controllers
{
    public class PackageController : BaseController
    {
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        // GET: Admin/Package
        public ActionResult Packages()
        {
            Paratech_EnergyEntities db = new Paratech_EnergyEntities();
            var data = (from u in db.SolarPackageMs select u).ToList();
            return View(data);
        }
        public ActionResult AddPackages()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddPackages(FormCollection form, Pictures pic, SolarPackageM packg)
        {
            bool ac = false;
            string InActive = Request.Form["InActive"];
            if (InActive == null)
            { ac = false; }
            else { ac = true; }

            if (ModelState.IsValid)
            {
                DateTime current = DateTime.Now;
                long tick = current.Ticks;
                packg.TitleM = form["PackageTile"];
                packg.SubtitleM = form["PackageSubTile"];
                packg.DescripM = form["PackageDescrip"];
                packg.InActive = ac;
                var picture = Path.GetFileName(tick + "_" + packg.TitleM + ".");
                var ext = Path.GetExtension(pic.File.FileName);
                string path = Path.Combine(Server.MapPath("~/img/PackageImg/"), picture + ext);
                string savepath = "~/img/PackageImg/" + picture + ext;
                pic.File.SaveAs(path);
                packg.ImageM = savepath;

                db.SolarPackageMs.Add(packg);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("Packages");
            }
            else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("Packages");
                ;
            }
        }
        public ActionResult EditPackages(int id)
        {
            var edt = db.SolarPackageMs.Where(x => x.MID == id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditPackages(FormCollection form, Pictures pic, SolarPackageM packg)
        {
            bool ac = false;
            string InActive = Request.Form["InActive"];
            if (InActive == null)
            {
                ac = false;
            }
            else
            {
                ac = true;
            }
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(form["ID"]);
                var edt = db.SolarPackageMs.Where(x => x.MID == id).FirstOrDefault();
                if (edt != null)
                {
                    edt.TitleM = form["PackageTile"];
                    edt.SubtitleM = form["PackageSubTile"];
                    edt.DescripM = form["PackageDescrip"];
                    edt.InActive = ac;
                    DateTime current = DateTime.Now;
                    long tick = current.Ticks;

                    DateTime curnt = DateTime.Now;
                    long tickee = curnt.Ticks;
                    
                    if (pic.File != null)
                    {
                        FileInfo myfileinf = new FileInfo(Server.MapPath(edt.ImageM));
                        if (System.IO.File.Exists(myfileinf.FullName))
                        {
                            System.IO.File.Delete(myfileinf.FullName);
                        };
                        var picture = Path.GetFileName(edt.ImageM);
                        var ext = Path.GetExtension(pic.File.FileName);
                        string path = Path.Combine(Server.MapPath("~/img/PackageImg/"), picture + ext);
                        string savepath = "~/img/PackageImg/" + picture + ext;
                        edt.ImageM = savepath;
                        pic.File.SaveAs(path);
                    }
                    db.SaveChanges();
                    TempData["Done"] = "Your Data Has Been Successfully Updated";
                    return RedirectToAction("Packages");
                }
            }
            //return View(packg);
            return RedirectToAction("Packages");
        }

        public JsonResult DeletePackages(int pID)
        {
            SolarPackageM product = db.SolarPackageMs.Where(x => x.MID == pID).FirstOrDefault();
            FileInfo myfileinf = new FileInfo(Server.MapPath(product.ImageM));
            if (System.IO.File.Exists(myfileinf.FullName))
            {
                System.IO.File.Delete(myfileinf.FullName);
            }
            db.SolarPackageMs.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PackDetails()
        {
            Paratech_EnergyEntities db = new Paratech_EnergyEntities();
            var data = (from u in db.SolarPackageDs select u).ToList();
            return View(data);
        }
        public ActionResult AddPackDetails()
        {
            ViewBag.PackageList = new SelectList(db.SolarPackageMs.Where(x => x.InActive == true).Select(x => new { Value = x.MID, Text = x.TitleM }), "Value", "Text");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddPackDetails(SolarPackageD unit, FormCollection form, Pictures pic)
        {
            if (ModelState.IsValid)
            {
                bool ac = false;
                string InActive = Request.Form["ForHome"];
                if (InActive == null)
                { ac = false; }
                else { ac = true; }

                DateTime current = DateTime.Now;
                long tick = current.Ticks;
                unit.TitleD = form["DetailTile"];
                unit.SubtitleD = form["DetailSubTile"];
                unit.DescripD = form["DetailDescrip"];
                unit.ForHome = ac;
                unit.Price = unit.Price;
                unit.MID = unit.MID;
                var picture = Path.GetFileName(tick + "_" + unit.MID + "_" + unit.TitleD + ".");
                var ext = Path.GetExtension(pic.File.FileName);
                string path = Path.Combine(Server.MapPath("~/img/PackageDImg/"), picture + ext);
                string savepath = "~/img/PackageDImg/" + picture + ext;
                pic.File.SaveAs(path);
                unit.ImageD = savepath;
                db.SolarPackageDs.Add(unit);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("PackDetails");
            }
            else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("PackDetails");
                ;
            }
        }
        public ActionResult EditPackDetails(int Id)
        {
            ViewBag.PackageList = new SelectList(db.SolarPackageMs.Where(x => x.InActive == true).Select(x => new { Value = x.MID, Text = x.TitleM }), "Value", "Text");
            var edt = db.SolarPackageDs.Where(x => x.DID == Id).FirstOrDefault();
            return View(edt);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditPackDetails(SolarPackageD unit, FormCollection form, Pictures pic)
        {
            if (ModelState.IsValid)
            {
                int Id = Convert.ToInt32(form["ID"]);
                var edt = db.SolarPackageDs.Where(x => x.DID == Id).FirstOrDefault();
                if (edt != null)
                {
                    bool ac = false;
                    string InActive = Request.Form["ForHome"];
                    if (InActive == null)
                    { ac = false; }
                    else { ac = true; }
                    edt.TitleD = form["DetailTile"];
                    edt.SubtitleD = form["DetailSubTile"];
                    edt.DescripD = form["DetailDescrip"];
                    edt.ForHome = ac;
                    edt.Price = unit.Price;
                    edt.MID = unit.MID;
                    DateTime current = DateTime.Now;
                    long tick = current.Ticks;

                    DateTime curnt = DateTime.Now;
                    long tickee = curnt.Ticks;




                    if (pic.File != null)
                    {
                        FileInfo myfileinf = new FileInfo(Server.MapPath(edt.ImageD));
                        if (System.IO.File.Exists(myfileinf.FullName))
                        {
                            System.IO.File.Delete(myfileinf.FullName);
                        };
                        var picture = Path.GetFileName(edt.ImageD);
                        var ext = Path.GetExtension(pic.File.FileName);
                        string path = Path.Combine(Server.MapPath("~/img/PackageDImg/"), picture + ext);
                        string savepath = "~/img/PackageDImg/" + picture + ext;
                        edt.ImageD = savepath;
                        pic.File.SaveAs(path);
                    }
                    db.SaveChanges();
                    TempData["Done"] = "Your Data Has Been Successfully Updated";
                    return RedirectToAction("PackDetails");
                }
            }
            return RedirectToAction("PackDetails");
        }
        public JsonResult DeletePackDetails(int pID)
        {
            SolarPackageD product = db.SolarPackageDs.Where(x => x.DID == pID).FirstOrDefault();
            FileInfo myfileinf = new FileInfo(Server.MapPath(product.ImageD));
            if (System.IO.File.Exists(myfileinf.FullName))
            {
                System.IO.File.Delete(myfileinf.FullName);
            }
            db.SolarPackageDs.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}