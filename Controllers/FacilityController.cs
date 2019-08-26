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
    public class FacilityController : ApiController
    {
        // GET: api/Facility
        public IEnumerable<Facility> Get()
        {
            ManageFacility mngFacility = new ManageFacility();
            return mngFacility.GetAllFacilities();
        }

        // GET: api/Facility/5
        public Facility Get(int id)
        {
            ManageFacility mngFacility = new ManageFacility();
            return mngFacility.GetFacilityFromId(id);
        }

        // POST: api/Facility
        public bool Post([FromBody]Facility value)
        {
            ManageFacility mngFacility = new ManageFacility();
            return mngFacility.CreateFacility(value);
        }

        // PUT: api/Facility/5
        public bool Put(int id, [FromBody]Facility value)
        {
            ManageFacility mngFacility = new ManageFacility();
            return mngFacility.UpdateFacility(value, id);
        }

        // DELETE: api/Facility/5
        public Facility Delete(int id)
        {
            ManageFacility mngFacility = new ManageFacility();
            return mngFacility.DeleteFacility(id);
        }
    }
}
