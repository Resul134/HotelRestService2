using System.Collections.Generic;
using System.Data.SqlClient;
using HotelModels;
using HotelRestService2.DBUtil;

namespace HotelRestService2.DBUtil
{
    public class ManageRoom : IManageRoom
    {
        string connectionString = "Data Source=simonshndbserver.database.windows.net;Initial Catalog=SimonSHN;User ID=simo35c9;Password=Simon1234;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Room> GetAllRooms()
        {
            List<Room> roomList = new List<Room>();
            string queryString = "SELECT * FROM Rum";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Room room = new Room();
                        room.roomNo = reader.GetInt32(0);
                        room.hotelNo = reader.GetInt32(1);
                        room.type = reader.GetString(2);
                        room.price = reader.GetDouble(3);
                        roomList.Add(room);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return roomList;
        }

        public Room GetRoomFromId(int roomNr, int hotelNr)
        {
            Room singleRoom = new Room();
            string queryString = "SELECT * FROM Rum WHERE Rum_Nr=@room AND Hotel_Nr=@hotel";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("room", roomNr);
                command.Parameters.AddWithValue("@hotel", hotelNr);

                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        singleRoom.roomNo = reader.GetInt32(0);
                        singleRoom.hotelNo = reader.GetInt32(1);
                        singleRoom.type = reader.GetString(2);
                        singleRoom.price = reader.GetDouble(3);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return singleRoom;
        }

        public bool CreateRoom(Room room)
        {
            string queryString = "INSERT INTO Rum (Rum_Nr,Hotel_Nr,Types,Pris) VALUES (@room, @hotel, @type, @price)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@room", room.roomNo);
                    command.Parameters.AddWithValue("@hotel", room.hotelNo);
                    command.Parameters.AddWithValue("@type", room.type);
                    command.Parameters.AddWithValue("@price", room.price);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (SqlException)
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateRoom(Room room, int roomNr, int hotelNr)
        {
            string queryString = "UPDATE Rum SET Types=@type,Pris=@price WHERE Rum_Nr=@room AND Hotel_Nr=@hotel";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@type", room.type);
                    command.Parameters.AddWithValue("@price", room.price);
                    command.Parameters.AddWithValue("@room", roomNr);
                    command.Parameters.AddWithValue("@hotel", hotelNr);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (SqlException)
                {
                    return false;
                }
            }
            return true;
        }

        public Room DeleteRoom(int roomNr, int hotelNr)
        {
            Room room = new Room();
            string queryString = "DELETE FROM Rum WHERE Rum_Nr=@room AND Hotel_Nr=@hotel";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@room", roomNr);
                    command.Parameters.AddWithValue("@hotel", hotelNr);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (SqlException)
                {
                    return room;
                }
            }
            return room;
        }
    }
}