﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasteFoodit.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Görsel { get; set; }
        
    }
}