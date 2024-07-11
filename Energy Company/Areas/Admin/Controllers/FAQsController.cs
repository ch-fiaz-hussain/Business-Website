using ParaTech_Energy.Controllers;
using ParaTech_Energy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParaTech_Energy.Areas.Admin.Controllers
{
    public class FAQsController : BaseController
    {
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        // GET: Admin/Content
        public ActionResult FAQ()
        {
            var data = (from u in db.FAQs select u).ToList();
            return View(data);
        }
        public ActionResult FAQCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult FAQCreate(FormCollection form,FAQ item)
        {
            var pag = (from u in db.FAQs where u.Question == item.Question select u).FirstOrDefault();
            if (pag == null)
            {
                db.FAQs.Add(item);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("FAQ");
            }
            else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("FAQ");
            }
        }

        public ActionResult EditFAQ(int Id)
        {
            var edt = db.FAQs.Where(x => x.ID == Id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditFAQ(FormCollection form,FAQ item)
        {
            var pcon = db.FAQs.Where(x => x.ID == item.ID).FirstOrDefault();
            if (pcon != null)
            {
                pcon.Question = item.Question;
                pcon.Description = item.Description;
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Updated";
                return RedirectToAction("FAQ");

            }
            return View(pcon);
        }
        public JsonResult DeleteFAQ(Int32 pID)
        {
            FAQ product = db.FAQs.Where(x => x.ID == pID).FirstOrDefault();
            db.FAQs.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        
    }
}