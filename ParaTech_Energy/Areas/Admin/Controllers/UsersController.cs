using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ParaTech_Energy.Models;
using System.IO;
using ParaTech_Energy.Controllers;

namespace ParaTech_Energy.Areas.Admin.Controllers
{
    
    public class UsersController : BaseController
    {
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        public ActionResult Users()
        {
            var data = (from u in db.Users select u).ToList();
            return PartialView(data);
        }
        public ActionResult UsersCreate()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult UsersCreate(FormCollection form, Pictures picture)
        {
            bool ac = false;
            string InActive = Request.Form["InActive"];
            if (InActive == null)
            { ac = false; }
            else { ac = true; }
            string username = form["UserName"];
            var usr = (from u in db.Users
                       where u.UserName == username
                       select u).FirstOrDefault();
            if (usr == null)
            {
                User us = new User();

                HttpPostedFileBase httpobj = picture.File;
                string[] Filename = httpobj.FileName.Split('.');
                using (Stream inputStream = Request.Files[0].InputStream) //File Stream which is Uploaded  
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    us.UserImage = memoryStream.ToArray();
                }

                us.UserName = username;
                us.FullName = form["FullName"];
                us.Password = form["Password"];
                us.Email = form["Email"];
                us.InActive = ac;
                db.Users.Add(us);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("Users");
            }
            else
            {
                TempData["Error"] = "User Name already exists";
                return RedirectToAction("UsersCreate");
            }
        }
        // Edit
        public ActionResult UsersEdit(int id)
        {
            var edt = db.Users.Where(x => x.UserID == id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        public ActionResult UsersEdit(FormCollection form, Pictures picture)
        {
            int id = Convert.ToInt32(Request.Form["UserID"].ToString());
            var user = db.Users.Where(x => x.UserID == id).FirstOrDefault();
            if (user != null)
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
                if (picture.File != null)
                {
                    HttpPostedFileBase httpobj = picture.File;
                    string[] Filename = httpobj.FileName.Split('.');
                    using (Stream inputStream = Request.Files[0].InputStream) //File Stream which is Uploaded  
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        user.UserImage = memoryStream.ToArray();
                    }
                }
                user.UserName = form["UserName"];
                user.FullName = form["FullName"];
                user.Password = form["Password"];
                user.Email = form["Email"];
                user.InActive = ac;
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("Users");

            }
            return View(user);
        }
        public JsonResult UsersDelete(Int32 UserID)
        {
            User product = db.Users.Where(x => x.UserID == UserID).FirstOrDefault();
            db.Users.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}