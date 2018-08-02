using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApiProject.Models;
namespace HotelApiProject.Controllers
{
    public class HotelController : ApiController
    {
       static List<HotelWork> HotelList = new List<HotelWork>()
        {
            new HotelWork  {id = 1, name = "Cosmos",  address = "Viman Nagar",NoOfRooms = 5 },
            new HotelWork  {id = 2, name = "Oberoi",  address = "Viman Nagar",NoOfRooms = 8 },
            new HotelWork  {id = 3, name = "Mariott",  address = "Viman Nagar",NoOfRooms = 5 },
            new HotelWork  {id = 4, name = "Hyatt",  address = "Viman Nagar",NoOfRooms = 8 },
            new HotelWork  {id = 5, name = "Lalit",  address = "Viman Nagar",NoOfRooms = 5 },
            new HotelWork  {id = 6, name = "Orbit",  address = "Viman Nagar",NoOfRooms = 8 },
            new HotelWork  {id = 7, name = "Taj",  address = "Viman Nagar",NoOfRooms = 5 },
            new HotelWork  {id = 8, name = "Ramada",  address = "Viman Nagar",NoOfRooms = 8 }
        };

        //List<HotelWork> HotelList2 = new List<HotelWork>()
        //{
        //    new HotelWork  {id = 1, name = "Cosmosss",  address = "Viman Nagar",NoOfRooms = 5 },
        //    new HotelWork  {id = 1, name = "Hyatttt",  address = "Viman Nagar",NoOfRooms = 8 }
        //};

        
        [HttpGet]
        public HotelWork GETHotelData(int id)
        {
            return HotelList.Find(x=> x.id==id);
        }

        [HttpGet]
        public ApiResponse GETHotelData()
        {
            try
            {
                return new ApiResponse
                {
                    HotelInfo = HotelList,
                    Status = Status.Success,
                    StatusCode = 200,
                    StatusMessage = "List Of Hotels Successfully Sent"
                };
            }
            catch (Exception e)
            {
                return new ApiResponse
                {
                    Status = Status.Failed,
                    StatusCode = 500,
                    StatusMessage = "Exception : " + e.Message
                };

            }
        }

        //public HotelWork GetHotelData(int id, int NoOfRooms)
        //{
        //    return HotelList[0];
        //}

        [HttpDelete]
        public ApiResponse DeleteHotelData(int id)
        {
            if (HotelList.Remove(HotelList.Find(x => x.id == id)) != false)
            {
                return new ApiResponse
                {
                    Status = Status.Success,
                    StatusCode = 200,
                    StatusMessage = "List Of Hotels Successfully Sent"
                };
            }
            else
            {
                return new ApiResponse
                {
                    Status = Status.Failed,
                    StatusCode = 404,
                    StatusMessage = "Data Not Found"
                };

            }
        }
        [HttpPut]
        public ApiResponse PutHotelData(int id,[FromBody] int booking)
        {
            if (HotelList.Find(x => x.id == id)!=null && HotelList.Find(x => x.id == id).NoOfRooms>=booking && HotelList.Find(x => x.id == id).NoOfRooms!=0)
            {
                HotelList.Find(x => x.id == id).NoOfRooms = HotelList.Find(x => x.id == id).NoOfRooms-booking;
                return new ApiResponse
                {
                   
                    Status = Status.Success,
                    StatusCode = 200,
                    StatusMessage = "Updated"
                };
            }

            else
            {
                return new ApiResponse
                {
                    Status = Status.Failed,
                    StatusCode = 404,
                    StatusMessage = "Data Not Found"
                };
            }
        }

        [HttpPost]
        public ApiResponse PostHotelData(HotelWork addHotel)
        {  
            if(HotelList.Find(x => x.id == addHotel.id) == null)
            { HotelList.Add(addHotel);
                return new ApiResponse
                {
                    Status = Status.Success,
                    StatusCode = 200,
                    StatusMessage = "Updated"

                };
            }
            else
            {
                return new ApiResponse
                {
                    Status = Status.Failed,
                    StatusCode = 404,
                    StatusMessage = "Data Not Found"
                };
            }
        }

    }
}
