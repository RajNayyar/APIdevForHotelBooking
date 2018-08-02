
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
namespace HotelApiProject.Models
{
    public class HotelWork
    {
        public int id  { get; set; }
        public String name  { get; set; }
        public String address  { get; set; }
        public int NoOfRooms  { get; set; }
        public int airport { get; set; }
    }
}