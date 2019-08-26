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
    public class BookingController : ApiController
    {
        // GET: api/Booking
        public IEnumerable<Booking> Get()
        {
            ManageBooking mngBooking = new ManageBooking();
            return mngBooking.GetAllBookings();
        }

        // GET: api/Booking/5
        public Booking Get(int id)
        {
            ManageBooking mngBooking = new ManageBooking();
            return mngBooking.GetBookingFromId(id);
        }

        // POST: api/Booking
        public void Post([FromBody]Booking value)
        {
            ManageBooking mngBooking = new ManageBooking();
            mngBooking.CreateBooking(value);
        }

        // PUT: api/Booking/5
        public void Put(int id, [FromBody]Booking value)
        {
            ManageBooking mngBooking = new ManageBooking();
            mngBooking.UpdateBooking(value, id);
        }

        // DELETE: api/Booking/5
        public void Delete(int id)
        {
            ManageBooking mngBooking = new ManageBooking();
            mngBooking.DeleteBooking(id);
        }
    }
}
