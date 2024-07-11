using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParaTech_Energy.Enums
{
    public class Status
    {
        public enum Statues
        {
            [Display(Name = "Active")]
            Active = 1,
            [Display(Name = "InActive")]
            InActive = 2,

        }
    }
}