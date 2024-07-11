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
    public class ClientController : BaseController
    {
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        // GET: Admin/Client
        public ActionResult Client()
        {
            Paratech_EnergyEntities db = new Paratech_EnergyEntities();
            var data = (from u in db.Clients select u).ToList();
            return View(data);
        }
        public ActionResult AddClient()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddClient(FormCollection form, Client clnt, Pictures pic)
        {
            if (ModelState.IsValid)
            {
                DateTime current = DateTime.Now;
                long tick = current.Ticks;
                clnt.ClientName = clnt.ClientName;
                clnt.CliProjName = form["ClientProject"];
                clnt.CliDescription = form["ClientDescription"];
                var picture = Path.GetFileName(tick + "_" + clnt.ClientName + ".");
                var ext = Path.GetExtension(pic.File.FileName);
                string path = Path.Combine(Server.MapPath("~/images/ClientImg/"), picture + ext);
                string savepath = "~/images/ClientImg/" + picture + ext;
                pic.File.SaveAs(path);
                clnt.ClientLogo = savepath;
                db.Clients.Add(clnt);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("Client");
            }
           else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("Client");
            }
        }
        public ActionResult EditClient(int Id)
        {
            var edt = db.Clients.Where(x => x.CID == Id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditClient(FormCollection form, Client clnt, Pictures pic)
        {
            if (ModelState.IsValid)
            {
                int Id = Convert.ToInt32(form["CID"]);
                var edt = db.Clients.Where(x => x.CID == Id).FirstOrDefault();
                if (edt != null)
                {
                    DateTime current = DateTime.Now;
                    long tick = current.Ticks;
                    edt.ClientName = clnt.ClientName;
                    edt.CliProjName = clnt.CliProjName;
                    edt.CliDescription = clnt.CliDescription;
                    if (pic.File != null)
                    {
                        FileInfo myfileinf = new FileInfo(Server.MapPath(edt.ClientLogo));
                        if (System.IO.File.Exists(myfileinf.FullName))
                        {
                            System.IO.File.Delete(myfileinf.FullName);
                        }
                        var picture = Path.GetFileName(edt.ClientLogo);
                        var ext = Path.GetExtension(pic.File.FileName);
                        string path = Path.Combine(Server.MapPath("~/images/ClientImg/"), picture + ext);
                        string savepath = "~/images/ClientImg/" + picture + ext;
                        edt.ClientLogo = savepath;
                        pic.File.SaveAs(path);
                    }
                    db.SaveChanges();
                    TempData["Done"] = "Your Data Has Been Successfully Updated";
                    return RedirectToAction("Client");

                }
            }

            return View(clnt);
        }
        public JsonResult DeleteClient(Int32 CId)
        {
            Client product = db.Clients.Where(x => x.CID == CId).FirstOrDefault();
            FileInfo myfileinf = new FileInfo(Server.MapPath(product.ClientLogo));
            if (System.IO.File.Exists(myfileinf.FullName))
            {
                System.IO.File.Delete(myfileinf.FullName);
            }

            db.Clients.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}