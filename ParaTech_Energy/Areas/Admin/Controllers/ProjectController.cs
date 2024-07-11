using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using ParaTech_Energy.Models;
using ParaTech_Energy.Controllers;
using System.Threading;

namespace ParaTech_Energy.Areas.Admin.Controllers
{
    public class ProjectController : BaseController
    {
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        // GET: Admin/Content
        public ActionResult Project()
        {
            Paratech_EnergyEntities db = new Paratech_EnergyEntities();
            var data = (from u in db.Projects select u).ToList();
            return View(data);
        }
        public ActionResult ProjectCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectCreate(FormCollection form, Project pro, Pictures pic)
        {
            if (ModelState.IsValid)
            {
                DateTime current = DateTime.Now;
                long tick = current.Ticks;
                var picture = Path.GetFileName(tick + "_" + pro.ProjectName + "_" + pro.ContentType);
                var ext = Path.GetExtension(pic.File.FileName);
                string path = Path.Combine(Server.MapPath("~/images/ProjectImages/"), picture + ext);
                string savepath = "~/images/ProjectImages/" + picture + ext;
                pic.File.SaveAs(path);
                pro.ProjectImage = savepath;
                db.Projects.Add(pro);
                db.SaveChanges();
                foreach (var Multiimg in pic.multiple)
                {
                    Thread.Sleep(1000);
                    ProjectImage pimg = new ProjectImage();
                    int id = pro.ID;
                    pimg.ProjectID = id;
                    DateTime current2 = DateTime.Now;
                    long ticks = current2.Ticks;
                    var picture2 = Path.GetFileName(ticks + "_" + pro.ProjectName);
                    string path2 = Path.Combine(Server.MapPath("~/images/ProjectdetailImages/"), picture2 + "_" + id+ Multiimg.FileName.Substring(Multiimg.FileName.LastIndexOf(".")));
                    string savepath2 = "~/images/ProjectdetailImages/" + picture2 + "_" + id+ Multiimg.FileName.Substring(Multiimg.FileName.LastIndexOf("."));
                    Multiimg.SaveAs(path2);
                    pimg.ProjectImg = savepath2;
                    db.ProjectImages.Add(pimg);
                    db.SaveChanges();
                }

                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("Project");
            }
            else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("Project");
            }
        }
        public ActionResult EditProject( int Id)
        {
            var edt = db.Projects.Where(x => x.ID == Id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditProject(FormCollection form, Project pro, Pictures pic)
        {
            if (ModelState.IsValid)
            {
                int Id = Convert.ToInt32(form["ID"]);
                var edt = db.Projects.Where(x => x.ID == Id).FirstOrDefault();
                if (edt != null)
                {
                    DateTime current = DateTime.Now;
                    long tick = current.Ticks;
                    edt.ProjectName = pro.ProjectName;
                    edt.Category = pro.Category;
                    edt.ContentType = pro.ContentType;
                    edt.ProjectDescription = pro.ProjectDescription;
                    if (pic.File != null)
                    {
                        FileInfo myfileinf = new FileInfo(Server.MapPath(edt.ProjectImage));
                        if (System.IO.File.Exists(myfileinf.FullName))
                        {
                            System.IO.File.Delete(myfileinf.FullName);
                        }
                        var picture = Path.GetFileName(edt.ProjectImage);
                        var ext = Path.GetExtension(pic.File.FileName);
                        string path = Path.Combine(Server.MapPath("~/images/ProjectImages/"), picture + ext);
                        string savepath = "~/images/ProjectImages/" + picture + ext;
                        edt.ProjectImage = savepath;

                        pic.File.SaveAs(path);
                    }
                    db.SaveChanges();
                    TempData["Done"] = "Your Data Has Been Successfully Updated";
                    return RedirectToAction("Project");
                }
            }
            return View(pro);
        }

        public JsonResult DeleteProject(Int32 Id)
        {
            Project product = db.Projects.Where(x => x.ID == Id).FirstOrDefault();
            FileInfo myfileinf = new FileInfo(Server.MapPath(product.ProjectImage));
            if (System.IO.File.Exists(myfileinf.FullName))
            {
                System.IO.File.Delete(myfileinf.FullName);
            }
            db.Projects.Remove(product);
            List<ProjectImage> imgs = db.ProjectImages.Where(x => x.ProjectID == product.ID).ToList();
            foreach(var del in imgs)
            {
                FileInfo mydel = new FileInfo(Server.MapPath(del.ProjectImg));
                if (System.IO.File.Exists(mydel.FullName))
                {
                    System.IO.File.Delete(mydel.FullName);
                }
                db.ProjectImages.Remove(del);
            }
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}