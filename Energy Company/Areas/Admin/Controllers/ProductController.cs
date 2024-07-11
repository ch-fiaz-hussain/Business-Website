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
    public class ProductController : BaseController
    {
        Paratech_EnergyEntities db = new Paratech_EnergyEntities();
        public ActionResult ProductCategory()
        {
            Paratech_EnergyEntities db = new Paratech_EnergyEntities();
            var data = (from u in db.ProductCategories select u).ToList();
            return View(data);
        }

        public ActionResult AddProductCategory()
        {
            var prolist = db.ProductCategories.Where(x => x.InActive == true).ToList();
            List<object> list = new List<object>();
            foreach (var s in prolist.Where(x =>x.CategoryID==null))
                list.Add(new
                {
                    Id = s.ID,
                    Name = s.CategoryName
                });
            ViewBag.ProductList = new SelectList(list, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddProductCategory(ProductCategory unit)
        {
            bool ac = false;
            string InActive = Request.Form["InActive"];
            if (InActive == null)
            { ac = false; }
            else { ac = true; }

            string title = unit.CategoryName;
            var pag = (from u in db.ProductCategories
                       where u.CategoryName == title
                       select u).FirstOrDefault();
            
            if (pag == null)
            {
                ProductCategory procat = new ProductCategory();
                procat.CategoryName = title;
                procat.InActive = ac;
                procat.CategoryID = unit.CategoryID;
                db.ProductCategories.Add(procat);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("ProductCategory");
            }
            else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("ProductCategory");
            }


        }

        public ActionResult EditProductCategory(int Id)
        {
            var prolist = db.ProductCategories.Where(x => x.InActive == true).ToList();
            List<object> list = new List<object>();
            foreach (var s in prolist.Where(x => x.CategoryID == null))
                list.Add(new
                {
                    Id = s.ID,
                   Name = s.CategoryName
                });
            ViewBag.ProductList = new SelectList(list, "Id", "Name");
            var edt = db.ProductCategories.Where(x => x.ID == Id).FirstOrDefault();
            return View(edt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProductCategory(ProductCategory item, FormCollection form)
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
                int Id = Convert.ToInt32(form["ID"]);
                var edt = db.ProductCategories.Where(x => x.ID == Id).FirstOrDefault();
                if (edt != null)
                {
                    edt.CategoryName = form["CategoryName"]; 
                    edt.InActive = ac;
                    edt.CategoryID = item.CategoryID;
                    db.SaveChanges();
                    edt = item;
                    TempData["Done"] = "Your Data Has Been Successfully Updated";
                    return RedirectToAction("ProductCategory");
                }
            }
            return View(item);
             
        }
        
        public JsonResult DeleteProductCategory(int ID)
        {
            ProductCategory product = db.ProductCategories.Where(x => x.ID == ID).FirstOrDefault();
            db.ProductCategories.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Products()
        {
            Paratech_EnergyEntities db = new Paratech_EnergyEntities();
            var data = (from u in db.Products select u).ToList();
            return View(data);
        }
        public ActionResult AddProducts()
        {
            ViewBag.ProductList = new SelectList(db.ProductCategories.Where(x => x.InActive == true).Select(x => new { Value = x.ID, Text = x.CategoryName }), "Value", "Text");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddProducts(Product unit, FormCollection form, Pictures pic)
        {
            if (ModelState.IsValid)
            {
                DateTime current = DateTime.Now;
                long tick = current.Ticks;
                unit.ProdContent = form["ProductContent"];
                unit.TotalWatts = form["TotalWatts"];
                unit.ProductcatID = unit.ProductcatID;
                var picture = Path.GetFileName(tick + "_" + unit.ProductcatID + "_" + unit.TotalWatts + ".");
                var ext = Path.GetExtension(pic.File.FileName);
                string path = Path.Combine(Server.MapPath("~/images/ProductImg/"), picture + ext);
                string savepath = "~/images/ProductImg/" + picture + ext;
                pic.File.SaveAs(path);
                unit.ProductImg = savepath;

                DateTime curnt = DateTime.Now;
                long tickee = curnt.Ticks;
                var pictre = Path.GetFileName("_" + tickee + unit.TotalWatts + ".");
                var extn = Path.GetExtension(pic.File2.FileName);
                string path2 = Path.Combine(Server.MapPath("~/images/ProductFile/"), pictre + extn);
                string savepath2 = "~/images/ProductFile/" + pictre + extn;
                pic.File2.SaveAs(path2);
                unit.ProductFile = savepath2;

                db.Products.Add(unit);
                db.SaveChanges();
                TempData["Done"] = "Your Data Has Been Successfully Saved";
                return RedirectToAction("Products");
            }
            else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("Products");
                ;
            }
}
        public ActionResult EditProducts(int Id)
        {
            ViewBag.ProductList = new SelectList(db.ProductCategories.Where(x => x.InActive == true).Select(x => new { Value = x.ID, Text = x.CategoryName }), "Value", "Text");
            var edt = db.Products.Where(x => x.ID == Id).FirstOrDefault();
            return View(edt);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditProducts(Product unit, FormCollection form, Pictures pic)
        {
            if (ModelState.IsValid)
            {
                int Id = Convert.ToInt32(form["ID"]);
                var edt = db.Products.Where(x => x.ID == Id).FirstOrDefault();
                if (edt != null)
                {
                    edt.TotalWatts = unit.TotalWatts;
                    edt.ProductcatID = unit.ProductcatID;
                    edt.ProdContent = form["ProductContent"];
                    DateTime current = DateTime.Now;
                    long tick = current.Ticks;

                    DateTime curnt = DateTime.Now;
                    long tickee = curnt.Ticks;

                    

                    
                    if (pic.File !=null)
                    {
                        FileInfo myfileinf = new FileInfo(Server.MapPath(edt.ProductImg));
                        if (System.IO.File.Exists(myfileinf.FullName))
                        {
                            System.IO.File.Delete(myfileinf.FullName);
                        };
                        var picture = Path.GetFileName(edt.ProductImg);
                        var ext = Path.GetExtension(pic.File.FileName);
                        string path = Path.Combine(Server.MapPath("~/images/ProductImg/"), picture + ext);
                        string savepath = "~/images/ProductImg/" + picture + ext;
                        edt.ProductImg = savepath;
                        pic.File.SaveAs(path);
                    }
                    if (pic.File2 != null)
                    {
                        FileInfo myfile = new FileInfo(Server.MapPath(edt.ProductFile));
                        if (myfile != null)
                        {
                            System.IO.File.Delete(myfile.FullName);
                        }
                        var pictre = Path.GetFileName(edt.ProductFile);
                        var extn = Path.GetExtension(pic.File2.FileName);
                        string path2 = Path.Combine(Server.MapPath("~/images/ProductFile/"), pictre + extn);
                        string savepath2 = "~/images/ProductFile/" + pictre + extn;
                        pic.File2.SaveAs(path2);
                        edt.ProductFile = savepath2;
                    }
                    db.SaveChanges();
                    TempData["Done"] = "Your Data Has Been Successfully Updated";
                    return RedirectToAction("Products");
                }
            }
            return View(unit);
        }
        public JsonResult DeleteProducts(int pID)
        {
            Product product = db.Products.Where(x => x.ID == pID).FirstOrDefault();
            FileInfo myfileinf = new FileInfo(Server.MapPath(product.ProductImg));
            if (System.IO.File.Exists(myfileinf.FullName))
            {
                System.IO.File.Delete(myfileinf.FullName);
            }
            FileInfo myfileinf2 = new FileInfo(Server.MapPath(product.ProductFile));
            if (System.IO.File.Exists(myfileinf2.FullName))
            {
                System.IO.File.Delete(myfileinf2.FullName);
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductCategoryDescription()
        {
            Paratech_EnergyEntities db = new Paratech_EnergyEntities();
            var data = (from u in db.ProductCategoryDes select u).ToList();
            return View(data);
        }

        public ActionResult AddProdcatDescription()
        {
            ViewBag.ProductList = new SelectList(db.ProductCategories.Where(x => x.InActive == true).Select(x => new { Value = x.ID, Text = x.CategoryName }), "Value", "Text");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult AddProdcatDescription(ProductCategoryDe item, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                ProductCategoryDe prodcat = new ProductCategoryDe();
                prodcat.ProductcatID = item.ProductcatID;
                prodcat.ProDesc = form["CategoryDescription"];
                db.ProductCategoryDes.Add(prodcat);
                db.SaveChanges();
            TempData["Done"] = "Your Data Has Been Successfully Saved";
            return RedirectToAction("ProductCategoryDescription");
             }
            else
            {
                TempData["Error"] = "Page already exists";
                return RedirectToAction("ProductCategoryDescription");
            }

         }

        public ActionResult EditProductCategoryDescrip(int Id)
        {
            ViewBag.ProductList = new SelectList(db.ProductCategories.Where(x => x.InActive == true).Select(x => new { Value = x.ID, Text = x.CategoryName }), "Value", "Text");
            var edt = db.ProductCategoryDes.Where(x => x.ID == Id).FirstOrDefault();
            return View(edt);

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProductCategoryDescrip(ProductCategoryDe prodes, FormCollection form)
        {

            if (ModelState.IsValid)
            {
                int Id = Convert.ToInt32(form["ID"]);
                var edt = db.ProductCategoryDes.Where(x => x.ID == Id).FirstOrDefault();
                if (edt != null)
                {
                    edt.ProductcatID = prodes.ProductcatID;
                    edt.ProDesc = form["ProdCatDescription"]; 
                    db.SaveChanges();
                    edt = prodes;
                    TempData["Done"] = "Your Data Has Been Successfully Updated";
                    return RedirectToAction("ProductCategoryDescription");
                }
            }
            return View(prodes);
        }
        public JsonResult DeleteProdcatDescription(int CID)
        {
            ProductCategoryDe product = db.ProductCategoryDes.Where(x => x.ID == CID).FirstOrDefault();
            db.ProductCategoryDes.Remove(product);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}