using MongoDB.Bson;
using MongoDB.Driver;
using SampleAspNetMVC_MongoDB.Models;
using SampleAspNetMVC_MongoDB.Properties;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SampleAspNetMVC_MongoDB.Controllers
{
    public class HomeController : Controller
    {     
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }    
}