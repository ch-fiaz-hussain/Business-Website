using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParaTech_Energy.Models;

namespace ParaTech_Energy.Models
{
    public class AllProducts
    {
        public List<ProductCategory> Newproductcategory  { get; set; }
        public List<Product> Newproduct  { get; set; }
        public List<ProductCategoryDe> Newprodcaregorydesc  { get; set; }
    }
}