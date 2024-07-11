using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParaTech_Energy.Models
{
    public class Pictures
    {
        public HttpPostedFileBase File { get; set; }
        public HttpPostedFileBase File2 { get; set; }
        public IEnumerable<HttpPostedFileBase> multiple { get; set; }
    }
}