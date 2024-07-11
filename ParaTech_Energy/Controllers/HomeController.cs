using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParaTech_Energy.Models;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using ParaTech_Energy.Code;
using System.Xml.Linq;
using System.Globalization;

namespace ParaTech_Energy.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        // GET: Home
        #region SiteMap
        public IReadOnlyCollection<SitemapNode> GetSitemapNodes(UrlHelper urlHelper)
        {
            List<SitemapNode> nodes = new List<SitemapNode>();

            nodes.Add(
                new SitemapNode()
                {
                    Url = urlHelper.AbsoluteRouteUrl("index"),
                    Priority = 1
                });
            nodes.Add(
               new SitemapNode()
               {
                   Url = urlHelper.AbsoluteRouteUrl("aboutus"),
                   Priority = 0.9
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = urlHelper.AbsoluteRouteUrl("solution"),
                   Priority = 0.9
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = urlHelper.AbsoluteRouteUrl("projects"),
                   Priority = 0.9
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = urlHelper.AbsoluteRouteUrl("ordernow"),
                   Priority = 0.9
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = urlHelper.AbsoluteRouteUrl("contactus"),
                   Priority = 0.9
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = urlHelper.AbsoluteRouteUrl("calculator"),
                   Priority = 0.9
               });
            nodes.Add(
               new SitemapNode()
               {
                   Url = urlHelper.AbsoluteRouteUrl("faqs"),
                   Priority = 0.9
               });
            //foreach (int productId in productRepository.GetProductIds())
            //{
            //    nodes.Add(
            //       new SitemapNode()
            //       {
            //           Url = urlHelper.AbsoluteRouteUrl("ProductGetProduct", new { id = productId }),
            //           Frequency = SitemapFrequency.Weekly,
            //           Priority = 0.8
            //       });
            //}

            return nodes;
        }

        
        public string GetSitemapDocument(IEnumerable<SitemapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (SitemapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }
        public ActionResult SitemapXml()
        {
            var sitemapNodes = GetSitemapNodes(this.Url);
            string xml = GetSitemapDocument(sitemapNodes);
            return this.Content(xml, "text/xml"/*, System.Net.Mime.ContentType.Xml,*/ /*System.Text.Encoding.UTF8*/);
        }
        #endregion
        public ActionResult Index(GetAllTables item)
        {
            item.img = db.WebImages.ToList();
            item.projects = db.Projects.ToList();
            item.pkgd = db.SolarPackageDs.Where(x=>x.ForHome==true).ToList();
            return PartialView(item);
        }
        public ActionResult _ViewProject(int id)
        {
            var dep = db.ProjectImages.Where(x => x.ProjectID == id).ToList();
            List<DataPoint> depPoints = new List<DataPoint>();
            foreach (var s in dep.Select(g => new { src = g.ProjectImg, title = g.Project.ProjectName }))
                depPoints.Add(new DataPoint(s.src.Replace("~",""), s.title));

            ViewBag.depPoints = JsonConvert.SerializeObject(depPoints);
            return View();
        }
        public ActionResult Calculator(GetAllTables item)
        {
            item.lstcalculator = db.Calculators.ToList();
            return PartialView(item);
        }
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Calculator(GetAllTables item, FormCollection form)
        {
            try
            {
                string name = form["Name"];
                var data = item.lstcalculatordetail;
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress("noreplypts5@gmail.com", "ParaTech Energy Solutions Query");
                mm.To.Add(new MailAddress("fiaz@paratechenergy.com", "Ch Fiaz"));
                mm.CC.Add(new MailAddress("Info@paratechenergy.com", "Info"));
                //mm.CC.Add(new MailAddress("afzaal@paratech.com.pk", "Afzaal"));
                mm.Subject = "ParaTech Energy Solutions Query";
                mm.Body += "<b>Dear ParaTech Energy Solutions Team,</b><br/> <br/> My Name is " + form["FullName"] + ".This is my contact #" + form["Phone"] + " and email address is " + form["Email"] + ".<br/> <br/>";
                mm.Body += "<table class='table table-bordered' width='80%' border=1 cellspacing=0 cellpadding=5><tbody><tr><td><b>Name</b></td><td><b>Watts</b></td><td><b>Qty</b></td><td><b>Total Watts</b></td>";
                foreach (var itm in data)
                {
                    if (itm.Qty != null)
                    {

                        mm.Body += "</tr><tr><td>" + itm.Name + "</td><td>" + itm.WattsActual + "</td><td>" + itm.Qty + "</td><td>" + itm.Watts + "</td></tr>";

                    }
                }
                mm.Body += "<tr><td colspan='3'><b>Sub Total Watts are:</b></td><td><b> " + form["TotalWatts"] + "</b></td></tr>";
                mm.Body += "</tbody></table>";
                mm.Body += "<br />" + form["Text"] + ".";
                mm.Body += "<p margin=0><b>Best Regards,<br/> ParaTech Energy Solutions</b><br/>" + "<a margin=0 href=" + "http://paratechenergy.com/" + " class='text - uppercase h3'><span class='text'>ParaTech Energy Solutions</span></a>.</p>";
                mm.IsBodyHtml = true;

                MailMessage mmclnt = new MailMessage();
                mmclnt.From = new MailAddress("noreplypts5@gmail.com", "No Reply");
                mmclnt.To.Add(new MailAddress(form["Email"]));
                mmclnt.Subject = "ParaTech Energy Solutions";
                mmclnt.Body += "<b>Dear " + form["FullName"] + ",</b><br/><br/> We have just received your request.Our team member will get back to you as soon as possible.<br/> In the meantime, feel free to browse the " +
                          "<a margin=0 href=" + "http://paratechenergy.com/" + ">ParaTech Energy Solutions</a>.";
                mmclnt.Body += "<p margin=0><b>Best Regards,<br/> ParaTech Energy Solutions</b><br/>" + "<a href=" + "http://paratechenergy.com/" + ">ParaTech Energy Solutions</a>.</p>";
                mmclnt.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential("noreplypts5@gmail.com", "paratech@123");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = nc;
                smtp.Send(mm);
                smtp.Send(mmclnt);
                TempData["Message"] = "Mail Sent Successfully!";
            }
            catch (Exception)
            {
                TempData["mesage"] = "Please Fill the Form First & Must Fill Your Contact Information";

            }
            return RedirectToAction("Calculator", "Home");
        }
        public ActionResult Project()
        {

            var imag = (from u in db.Projects select u).ToList();
            return View(imag);
        }
        public ActionResult Client()
        {

            var clnt = (from u in db.Clients select u).ToList();
            return View(clnt);
        }
        public ActionResult ClientDetail(FormCollection form, int Id)
        {
            var clnt = db.Clients.Where(x => x.CID == Id).ToList();
            return View(clnt);
        }

        public ActionResult DetailProject(GetAllTables item, FormCollection form,int ID)
        {
            item.projects = db.Projects.Where(x => x.ID == ID).ToList();
            item.projectImages = db.ProjectImages.Where(x => x.ProjectID == ID).ToList();
            return View(item);
        }
        public ActionResult Blogs()
        {
            //var blog = (from u in db.BlogNews select u.PageName == "Blogs").ToList();
            var blog = db.BlogNews.Where(x => x.PageName == "Blogs").ToList();
            return View(blog);
        }
        public ActionResult BlogsDetail(FormCollection form, int Id)
        {
            var blog = db.BlogNews.Where(x => x.ID == Id && x.PageName == "Blogs").ToList();
            return View(blog);
        }
        public ActionResult LatestNews()
        {
            var blog = db.BlogNews.Where(x => x.PageName == "Latest News").ToList();
            return View(blog);
        }
        public ActionResult LatestNewsDetail(FormCollection form, int Id)
        {
            var blog = db.BlogNews.Where(x => x.ID == Id && x.PageName == "Latest News").ToList();
            return View(blog);
        }

        public ActionResult AboutUs()
        { 
            var cntnt = db.Contents.Where(x => x.Page == "About Us").ToList();
            return View(cntnt);
        }
        public ActionResult Solutions()
        {
            var solut = db.Contents.Where(x => x.Page == "Solutions").ToList();
            return View(solut);
        }
        public ActionResult SolutionsDetail(string maintitle,string title,GetAllTables item)
        {
            item.solution = db.Solutions.Where(x => x.PageName.Replace(" ", "-").ToLower() == title).ToList();
            ViewBag.PageData = db.Solutions.FirstOrDefault(x => x.PageName.Replace(" ", "-").ToLower() == title);
            return View(item);
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs( FormCollection form)
        {
            try
            {
                string name = form["Name"];
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress("noreplypts5@gmail.com", "No Reply");
                //mm.To.Add(new MailAddress("asad0646841@gmail.com", "Asad Ahmed ParaTech"));
                mm.To.Add(new MailAddress("fiaz@paratechenergy.com", "Ch Fiaz Hussain ParaTech"));
                mm.CC.Add(new MailAddress("Info@paratechenergy.com", "Info ParaTech"));
                mm.Subject = form["Name"] + " - ParaTech Energy Solutions";
                mm.Body += "Hi,<br/> My Name is " + form["Name"] + ".This is my contact #" + form["Contact"] + " and email address is " + form["Email"] + ".";
                mm.Body += "<br />" + form["Subject"] + ".";
                mm.Body += "<br />" + form["Message"] + ".";
                mm.IsBodyHtml = true;

                MailMessage mmclnt = new MailMessage();
                mmclnt.From = new MailAddress("noreplypts5@gmail.com", "No Reply");
                mmclnt.To.Add(new MailAddress(form["Email"]));
                mmclnt.Subject = form["Name"] +" - ParaTech Energy Solutions";
                mmclnt.Body += "Hi,<br/>" + form["Name"] + ".We have just received your request.Our team member will get back to you as soon as possible.<br/> In the meantime, feel free to browse the" +
                          "<a href=" + Url.Action("Index", "Home") + "; class='text - uppercase h3'><span class='text'>ParaTech Energy</span></a>.";
                mmclnt.Body += "<br />" + form["Subject"] + ".";
                mmclnt.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                NetworkCredential nc = new NetworkCredential("noreplypts5@gmail.com", "paratech@123");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = nc;
                smtp.Send(mmclnt);
                smtp.Send(mm);
                TempData["Message"] = "Mail Sent Successfully!";
            }
            catch (Exception)
            {
                TempData["mesage"] = "Please Fill the Form First & Must fill Name and Email box";

            }
            return RedirectToAction("ContactUs", "Home");
        }
        public ActionResult Products(string title)
        {
            ViewBag.CatName = db.ProductCategories.FirstOrDefault(x => x.CategoryName.Replace(" ","-").ToLower() == title).CategoryName;
                var pro = db.Products.Where(x => x.ProductCategory.CategoryName.Replace(" ", "-").ToLower() == title).ToList();
                return View(pro);
        }
        public ActionResult Packages(GetAllTables item, string titlem)
        {
            item.pkgm = db.SolarPackageMs.Where(x=>x.TitleM.Replace(" ", "-").ToLower() == titlem).FirstOrDefault();
            item.pkgd = db.SolarPackageDs.Where(x => x.MID == item.pkgm.MID).ToList();
            return View(item);
        }
        public ActionResult GetAFreeQuote(string title)
        {
            FreeQuote item = new FreeQuote();
            ViewBag.PackageList = new SelectList(db.SolarPackageDs.Select(x => new { Value = x.TitleD, Text = x.TitleD }), "Value", "Text",title);
            return View(item);
        }
        [HttpPost]
        public ActionResult GetAFreeQuote(FreeQuote item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string name = item.FullName;
                    MailMessage mm = new MailMessage();
                    mm.From = new MailAddress("noreplypts5@gmail.com", "ParaTech Energy Solutions");
                    //mm.To.Add(new MailAddress("afzaal@paratech.com.pk", "Muhammad Afzaal"));
                    mm.To.Add(new MailAddress("fiaz@paratechenergy.com", "Ch Fiaz Hussain"));
                    mm.CC.Add(new MailAddress("Info@paratechenergy.com", "Info ParaTech"));
                    mm.Subject = "Get A Free Quote - ParaTech Energy Solutions";
                    mm.Body += "<b>Hi Paratech Energy Solutions Team,</b><br/><br/> Please Check below my query. <br/><br/>";
                    mm.Body += "<b>Full Name: </b>" + item.FullName;
                    mm.Body += "<br/><b>Email: </b>" + item.Email;
                    mm.Body += "<br/><b>City: </b>" + item.City;
                    mm.Body += "<br/><b>Phone: </b>" + item.Phone;
                    mm.Body += "<br/><b>Package: </b>" + item.Package;
                    mm.Body += "<br />" + item.Message + ".";
                    mm.Body += "<br /><br /><h3 style='margin: 0;padding: 0;'>Best Regards,</h3>";
                    mm.Body += "<h4 style='margin: 0;padding: 0;'>ParaTech Energy Solutions</h3>";
                    mm.Body += "<a href='http://paratechenergy.com/'>paratechenergy.com</a>";
                    mm.IsBodyHtml = true;

                    MailMessage mmclnt = new MailMessage();
                    mmclnt.From = new MailAddress("noreplypts5@gmail.com", "No Reply");
                    mmclnt.To.Add(new MailAddress(item.Email));
                    mmclnt.Subject = item.FullName + " - ParaTech Energy Solutions";
                    mmclnt.Body += "<b>Hi " + item.FullName + ",</b><br/><br/>We have just received your request.Our team member will get back to you as soon as possible.<br/> In the meantime, feel free to browse the " +
                              "<a href='http://paratechenergy.com/'>ParaTech Energy Solutions</a>.";
                    mmclnt.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    NetworkCredential nc = new NetworkCredential("noreplypts5@gmail.com", "paratech@123");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = nc;
                    smtp.Send(mmclnt);
                    smtp.Send(mm);
                    TempData["Message"] = "You Query Successfully Send.";
                }
                else
                {
                    string strmessages = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage));
                    TempData["MessageError"] = strmessages;
                    ViewBag.PackageList = new SelectList(db.SolarPackageDs.Select(x => new { Value = x.TitleD, Text = x.TitleD }), "Value", "Text",item.Package);
                    return View("GetAFreeQuote", item);
                }
            }
            catch (Exception e)
            {
                TempData["MessageError"] = e.Message;

            }
            return RedirectToAction("GetAFreeQuote", "Home");
        }
        public ActionResult FAQs(GetAllTables item)
        {
            item.faqs = db.FAQs.ToList();
            return View(item);
        }
    }
}