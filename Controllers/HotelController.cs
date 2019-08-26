using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelModels;
using HotelRestService2.DBUtil;

namespace HotelRestService2.Controllers
{
    public class HotelController : ApiController
    {
        // GET: api/Hotel
        public IEnumerable<Hotel> Get()
        {
            ManageHotel mngHotel = new ManageHotel();
            return mngHotel.GetAllHotels();
        }

        // GET: api/Hotel/5
        public Hotel Get(int id)
        {
            ManageHotel mngHotel = new ManageHotel();
            return mngHotel.GetHotelFromId(id);
        }

        // POST: api/Hotel
        public void Post([FromBody]Hotel value)
        {
            ManageHotel mngHotel = new ManageHotel();
            mngHotel.Createhotel(value);
        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]Hotel value)
        {
            ManageHotel mngHotel = new ManageHotel();
            mngHotel.Updatehotel(value, id);
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
            ManageHotel mngHotel = new ManageHotel();
            mngHotel.Deletehotel(id);
        }
    }
}
