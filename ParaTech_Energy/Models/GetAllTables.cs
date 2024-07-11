using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParaTech_Energy.Models
{
    public class GetAllTables
    {
        public List<CalculatorDetail> lstcalculatordetail { get; set; }
        public List<Calculator> lstcalculator { get; set; }
        public List<Project> projects { get; set; }
        public List<ProjectImage> projectImages { get; set; }
        public List<WebImage> img { get; set; }
        public SolarPackageM pkgm { get; set; }
        public List<SolarPackageD> pkgd { get; set; }
        public List<Solution> solution { get; set; }
        public List<FAQ> faqs { get; set; }

    }
} 