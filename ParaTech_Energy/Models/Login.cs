﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParaTech_Energy.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}