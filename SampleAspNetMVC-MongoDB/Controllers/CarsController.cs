using MongoDB.Bson;
using MongoDB.Driver;
using SampleAspNetMVC_MongoDB.Models;
using SampleAspNetMVC_MongoDB.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleAspNetMVC_MongoDB.Controllers
{
    public class CarsController : Controller
    {       
        private readonly MongoDBContext context = new MongoDBContext();
       
        // GET: Cars
        public ActionResult Index()
        {   
            List<Car> lists = new List<Car>();
            using (var documentList = context.Cars.Find(new BsonDocument()).ToCursor()) //Gets all documents
            {
                while (documentList.MoveNext())
                {
                    foreach (var item in documentList.Current)
                    {

                        lists.Add(item);
                    }
                }
            }
            return View(lists);
        }

        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post(Car car)
        {            
            context.Cars.InsertOne(car);
            return RedirectToAction("Index");
        }
    }
}