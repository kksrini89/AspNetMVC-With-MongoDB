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
        public IMongoClient Client;
        public IMongoDatabase Database;
        public CarsController()
        {
            Client = new MongoClient(Settings.Default.SampleConnectionString);
            Database = Client.GetDatabase("sample");
        }
        // GET: Cars
        public ActionResult Index()
        {
            var cars = Database.GetCollection<Car>("car");
            List<Car> lists = new List<Car>();
            using (var documentList = cars.Find(new BsonDocument()).ToCursor()) //Gets all documents
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
            var collection = Database.GetCollection<Car>("car");
            collection.InsertOne(car);
            return RedirectToAction("Index");
        }
    }
}