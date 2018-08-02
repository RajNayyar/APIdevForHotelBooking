using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelApiProject.Models
{
    public class ApiResponse
    {
        public List<HotelWork> HotelInfo;
        public Status Status;
        public int StatusCode;
        public string StatusMessage;


    }

    public enum Status
    {
        Failed,
        Success
    }
}