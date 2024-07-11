using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ParaTech_Energy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("index", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("sitemap", "sitemap.xml", new { controller = "Home", action = "SitemapXml" });
            routes.MapRoute("aboutus", "about-us", new { controller = "Home", action = "AboutUs" });
            routes.MapRoute("solution", "solar-solutions", new { controller = "Home", action = "Solutions" });
            routes.MapRoute("projects", "projects", new { controller = "Home", action = "Project" });
            routes.MapRoute("ordernow", "order-now", new { controller = "Home", action = "GetAFreeQuote" });
            routes.MapRoute("contactus", "contact-us", new { controller = "Home", action = "ContactUs" });
            routes.MapRoute("calculator", "solar-calculator", new { controller = "Home", action = "Calculator" });
            routes.MapRoute("faqs", "faqs", new { controller = "Home", action = "FAQs" });
            routes.MapRoute("solarpkg", "solar-packages/{titlem}/", new { controller = "Home", action = "Packages", titlem = UrlParameter.Optional });
            routes.MapRoute("solarsolutiondetail", "solar-solutions/{title}/", new { controller = "Home", action = "SolutionsDetail", title = UrlParameter.Optional });
            routes.MapRoute("product", "products/{maintitle}/{title}/", new { controller = "Home", action = "Products", maintitle = UrlParameter.Optional, title = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
