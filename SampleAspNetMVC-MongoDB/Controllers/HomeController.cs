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
        public IMongoClient Client;
        public IMongoDatabase Database;
        //public IMongoCollection<Car> collection;
        public HomeController()
        {
            Client = new MongoClient(Settings.Default.SampleConnectionString);
            Database = Client.GetDatabase(Settings.Default.DataBaseName);
        }

        public ActionResult Index()
        {
            List<Car> lists = new List<Car>();

            //Reading available documents from the MongoDB collection
            var collection = Database.GetCollection<Car>("car"); // Get the collection reference
            var filter = new BsonDocument(); // Pass the empty filter to get all the available documents from the car collection
            using (var documentList = collection.Find(filter).ToCursor()) //Gets all documents
            {
                while (documentList.MoveNext()) 
                {
                    foreach (var item in documentList.Current)
                    {                        
                        lists.Add(item);
                    }
                }
            }

            var count = collection.Count(new BsonDocument()); //Shows count of documents for a particular collection                      
            return Json(lists, JsonRequestBehavior.AllowGet);
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