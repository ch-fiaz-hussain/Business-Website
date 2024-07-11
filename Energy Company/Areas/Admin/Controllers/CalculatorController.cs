using ParaTech_Energy.Controllers;
using ParaTech_Energy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParaTech_Energy.Areas.Admin.Controllers
{
    public class CalculatorController : BaseController
    {
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        public ActionResult Calculator()
        {
            var data = (from u in db.Calculators select u).ToList();
            return PartialView(data);
        }
        public ActionResult CalculatorCreate()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CalculatorCreate(FormCollection form)
        {
            string name = form["Name"];
            var usr = (from u in db.Calculators
                       where u.Name == name
                       select u).FirstOrDefault();
            if (usr == null)
            {
                Calculator us = new Calculator();
                us.Name = name;
                us.TotalWatts = Convert.ToDecimal(form["TotalWatts"]);
                db.Calculators.Add(us);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("Calculator");
            }
            else
            {
                TempData["Error"] = "Name already exists";
                return RedirectToAction("CalculatorCreate");
            }
        }
        // Edit
        public ActionResult CalculatorEdit(int id)
        {
            var edt = db.Calculators.Where(x => x.ID == id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        public ActionResult CalculatorEdit(FormCollection form)
        {
            int id = Convert.ToInt32(Request.Form["ID"].ToString());
            var user = db.Calculators.Where(x => x.ID == id).FirstOrDefault();
            if (user != null)
            {
                user.Name = form["Name"];
                user.TotalWatts = Convert.ToDecimal(form["TotalWatts"]);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("Calculator");

            }
            return View(user);
        }
        public JsonResult CalculatorDelete(Int32 ID)
        {
            Calculator product = db.Calculators.Where(x => x.ID == ID).FirstOrDefault();
            db.Calculators.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}