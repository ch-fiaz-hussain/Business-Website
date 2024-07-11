using ParaTech_Energy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParaTech_Energy.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var item = db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            if (item != null)
            {
                ViewBag.fullname = item.FullName;
                ViewBag.userimage = item.UserImage;
                ViewBag.email = item.Email;
                ViewBag.id = item.UserID;
            }
            var usercount = db.Users.Count();
            ViewBag.usercount = usercount;
            
            base.OnActionExecuting(filterContext);
        }

    }

}