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
    public class RoomController : ApiController
    {
        // GET: api/Room
        public IEnumerable<Room> Get()
        {
            ManageRoom mngRoom = new ManageRoom();
            return mngRoom.GetAllRooms();
        }

        // GET: api/Room/5
        [Route("API/Room/{roomId},{hotelId}")]
        public Room Get(int roomId, int hotelId)
        {
            ManageRoom mngRoom = new ManageRoom();
            return mngRoom.GetRoomFromId(roomId, hotelId);
        }

        // POST: api/Room
        public void Post([FromBody]Room value)
        {
            ManageRoom mngRoom = new ManageRoom();
            mngRoom.CreateRoom(value);
        }

        // PUT: api/Room/5
        [Route("API/Room/{roomId},{hotelId}")]
        public void Put(int roomId, int hotelId, [FromBody]Room value)
        {
            ManageRoom mngRoom = new ManageRoom();
            mngRoom.UpdateRoom(value, roomId, hotelId);
        }

        // DELETE: api/Room/5
        [Route("API/Room/{roomId},{hotelId}")]
        public void Delete(int roomId, int hotelId)
        {
            ManageRoom mngRoom = new ManageRoom();
            mngRoom.DeleteRoom(roomId, hotelId);
        }
    }
}
