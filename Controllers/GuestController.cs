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
    public class GuestController : ApiController
    {
        // GET: api/Guest
        public IEnumerable<Guest> Get()
        {
            ManageGuest manageGuest = new ManageGuest();
            return manageGuest.GetAllGuest();
        }

        // GET: api/Guest/5
        public Guest Get(int id)
        {
            ManageGuest manageGuest = new ManageGuest();
            return manageGuest.GetGuestFromId(id);
        }

        // POST: api/Guest
        public void Post([FromBody]Guest value)
        {
            ManageGuest manageGuest = new ManageGuest();
            manageGuest.CreateGuest(value);
        }

        // PUT: api/Guest/5
        public void Put(int id, [FromBody]Guest value)
        {
            ManageGuest manageGuest = new ManageGuest();
            manageGuest.UpdateGuest(value,id);
        }

        // DELETE: api/Guest/5
        public void Delete(int id)
        {
            ManageGuest manageGuest = new ManageGuest();
            manageGuest.DeleteGuest(id);
        }
    }
}
