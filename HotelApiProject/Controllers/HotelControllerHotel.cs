using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using HotelApiProject.Models;
using Newtonsoft.Json;
namespace HotelApiProject.Controllers
{
    class HotelController : ApiController
    {
        public JsonResult<List<nestedT>> GEt([FromUri]string inputString)

        {
            string autoComplete = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + inputString + "&types=geocode&language=en&key=AIzaSyAFAfIYYn-j8qsBgk8j4f3RWXEvlJZIhvI";
            var result = new WebClient().DownloadString(autoComplete);
            var Jsonobject = JsonConvert.DeserializeObject<T>(result);
            List<Prediction> autocomplete = Jsonobject.prediction;
            string place = autocomplete[0].description;
            var result2 = new WebClient().DownloadString("https://maps.googleapis.com/maps/api/place/textsearch/json?query=hotels+in+" + place + "&radius=10000&key=AIzaSyAFAfIYYn-j8qsBgk8j4f3RWXEvlJZIhvI");
            var Jsonobject1 = JsonConvert.DeserializeObject<T2>(result2);
            List<nestedT> HotelList = Jsonobject1.Results;

            return Json(HotelList);
        }
    }
}
