using System.Collections.Generic;
using System.Data.SqlClient;
using HotelModels;

namespace HotelRestService2.DBUtil
{
    public class ManageHotel : IManageHotel
    {
        string connectionString = "Data Source=simonshndbserver.database.windows.net;Initial Catalog=SimonSHN;User ID=simo35c9;Password=Simon1234;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; 

        public List<Hotel> GetAllHotels()
        {
            List<Hotel> hotelList = new List<Hotel>();
            string queryString = "SELECT * FROM Hotel";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Hotel hotel = new Hotel();
                        hotel.hotelNo = reader.GetInt32(0);
                        hotel.name = reader.GetString(1);
                        hotel.address = reader.GetString(2);
                        hotelList.Add(hotel);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return hotelList;
        }

        public Hotel GetHotelFromId(int hotelNr)
        {
            Hotel singleHotel = new Hotel();
            string queryString = "SELECT * FROM Hotel WHERE Hotel_Nr=" + hotelNr;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        singleHotel.hotelNo = reader.GetInt32(0);
                        singleHotel.name = reader.GetString(1);
                        singleHotel.address = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return singleHotel;
        }

        public bool Createhotel(Hotel hotel)
        {
            string queryString = "INSERT INTO Hotel (Hotel_Nr,Navn,Adresse) VALUES (@Number, @Name, @Address)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Number", hotel.hotelNo);
                    command.Parameters.AddWithValue("@Name", hotel.name);
                    command.Parameters.AddWithValue("@Address", hotel.address);
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

        public bool Updatehotel(Hotel hotel, int hotelNr)
        {
            string queryString = "UPDATE Hotel SET Navn=@Name,Adresse=@Address WHERE Hotel_Nr=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Name", hotel.name);
                    command.Parameters.AddWithValue("@Address", hotel.address);
                    command.Parameters.AddWithValue("@id", hotelNr);
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

        public Hotel Deletehotel(int hotelNr)
        {
            Hotel hotel = new Hotel();
            string queryString = "DELETE FROM Hotel WHERE Hotel_Nr=@Number";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Number", hotelNr);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (SqlException)
                {
                    return hotel;
                }
            }
            return hotel;
        }
    }
}