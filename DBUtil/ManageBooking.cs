using System.Collections.Generic;
using System.Data.SqlClient;
using HotelModels;

namespace HotelRestService2.DBUtil
{
    public class ManageBooking : IManageBooking
    {
        string connectionString = "Data Source=simonshndbserver.database.windows.net;Initial Catalog=SimonSHN;User ID=simo35c9;Password=*********;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Booking> GetAllBookings()
        {
            List<Booking> bookingList = new List<Booking>();
            string queryString = "SELECT * FROM Reservation";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Booking booking = new Booking();
                        booking.bookingId = reader.GetInt32(0);
                        booking.hotelNo = reader.GetInt32(1);
                        booking.guestNo = reader.GetInt32(2);
                        booking.dateFrom = reader.GetDateTime(3);
                        booking.dateTo = reader.GetDateTime(4);
                        booking.roomNo = reader.GetInt32(5);
                        bookingList.Add(booking);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return bookingList;
        }

        public Booking GetBookingFromId(int bookingNr)
        {
            string queryString = "SELECT * FROM Reservation WHERE Reservation_id="+bookingNr;
            Booking booking = new Booking();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        booking.bookingId = reader.GetInt32(0);
                        booking.hotelNo = reader.GetInt32(1);
                        booking.guestNo = reader.GetInt32(2);
                        booking.dateFrom = reader.GetDateTime(3);
                        booking.dateTo = reader.GetDateTime(4);
                        booking.roomNo = reader.GetInt32(5);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return booking;
        }

        public bool CreateBooking(Booking booking)
        {
            string queryString = "INSERT INTO Reservation (Hotel_Nr,Gæst_Nr,Date_Fra,Date_Til,Rum_Nr) VALUES (@hotel, @guest, @df, @dt, @room)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@hotel", booking.hotelNo);
                    command.Parameters.AddWithValue("@guest", booking.guestNo);
                    command.Parameters.AddWithValue("@df", booking.dateFrom);
                    command.Parameters.AddWithValue("@dt", booking.dateTo);
                    command.Parameters.AddWithValue("@room", booking.roomNo);
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

        public bool UpdateBooking(Booking booking, int bookingNr)
        {
            string queryString = "UPDATE Reservation SET Hotel_Nr=@hotel,Gæst_Nr=@guest,Date_Fra=@df,Date_Til=@dt,Rum_Nr=@room WHERE Reservation_id=@bookingid";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", booking.bookingId);
                    command.Parameters.AddWithValue("@hotel", booking.hotelNo);
                    command.Parameters.AddWithValue("@guest", booking.guestNo);
                    command.Parameters.AddWithValue("@df", booking.dateFrom);
                    command.Parameters.AddWithValue("@dt", booking.dateTo);
                    command.Parameters.AddWithValue("@room", booking.roomNo);
                    command.Parameters.AddWithValue("@bookingid", bookingNr);
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

        public Booking DeleteBooking(int bookingNr)
        {
            Booking booking = new Booking();
            string queryString = "DELETE FROM Reservation WHERE Reservation_id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", bookingNr);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (SqlException)
                {
                    return booking;
                }
            }
            return booking;
        }
    }
}