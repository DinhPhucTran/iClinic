using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;
using iClinic.Models;
using Microsoft.AspNet.Identity.Owin;

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
