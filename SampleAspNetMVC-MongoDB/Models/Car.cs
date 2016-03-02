using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAspNetMVC_MongoDB.Models
{
    public class Car
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string year { get; set; }
        public string origin { get; set; }
    }
}