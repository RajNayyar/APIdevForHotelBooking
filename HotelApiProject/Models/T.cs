using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApiProject.Models
{
    public class T
    {
        public List <Prediction> prediction { get; set; }
        public string status { get; set;  }
   
    }

    public class nestedT
    {
        public string name { get; set; }
        public string formatted_address { get; set; }
    }

    public class Prediction
    {
        public string description { get; set; }

    }

    public class T2
    {
        public List<nestedT> Results { get; set; }

        public string status { get; set; }
    }
}