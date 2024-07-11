using ParaTech_Energy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ParaTech_Energy.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Login()
        {
            if (User.Identity.Name != null && User.Identity.Name != "")
            {
                if (Session["UserName"] != null)
                {
                    return RedirectToAction("Index", "Default");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return PartialView();
            }
        }
        [HttpPost]
        public ActionResult Login(FormCollection form, Login loginDetails)
        {
            if (ModelState.IsValid)
            {
                using (Paratech_EnergyEntities context = new Paratech_EnergyEntities())
                {
                    var adminUser = context.Users.Where(a => a.UserName == loginDetails.UserName && a.Password == loginDetails.Password && a.InActive == true).FirstOrDefault();
                    if (adminUser != null)
                    {
                        FormsAuthentication.SetAuthCookie(loginDetails.UserName, loginDetails.RememberMe);
                        Session["UserName"] = adminUser.UserName;
                        if (loginDetails.RememberMe)
                        {
                            HttpCookie cookie = new HttpCookie("Login");
                            cookie.Values.Add("UserName", adminUser.UserName);
                            cookie.Values.Add("Password", adminUser.Password);
                            cookie.Expires = DateTime.Now.AddDays(15);
                            Response.Cookies.Add(cookie);
                        }
                        return RedirectToAction("Content", "Content");
                    }
                    else
                    {
                        TempData["danger"] = "Login data is incorrect! Please try again";
                    }
                }
            }
            return View(loginDetails);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}