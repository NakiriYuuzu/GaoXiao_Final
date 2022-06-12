using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GaoXiao_Final.Models;

namespace GaoXiao_Final.Controllers
{
    public class HomeController : Controller
    {
        private LibraryModels db = new LibraryModels();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}