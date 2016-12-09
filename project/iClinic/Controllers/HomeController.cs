﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iClinic.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        [ActionName("abc")]
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString("T");
        }
    }
}
