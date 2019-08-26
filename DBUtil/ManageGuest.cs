using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HotelModels;

namespace HotelRestService2.DBUtil
{
    public class ManageGuest : IManageGuest
    {
        string connectionString = "Data Source=simonshndbserver.database.windows.net;Initial Catalog=SimonSHN;User ID=simo35c9;Password=Simon1234;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Guest> GetAllGuest()
        {
            List<Guest> guestList = new List<Guest>();
            string queryString = "SELECT Gæst_Nr,Navn,Adresse FROM Gæst";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Guest guest = new Guest();
                        guest.GuestNr = reader.GetInt32(0);
                        guest.Name = reader.GetString(1);
                        guest.Address = reader.GetString(2);
                        guestList.Add(guest);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return guestList;
        }

        public Guest GetGuestFromId(int guestNr)
        {
            Guest singleGuest = new Guest();
            string queryString = "SELECT Gæst_Nr,Navn,Adresse FROM Gæst WHERE Gæst_Nr="+guestNr;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        singleGuest.GuestNr = reader.GetInt32(0);
                        singleGuest.Name = reader.GetString(1);
                        singleGuest.Address = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return singleGuest;
        }

        public bool CreateGuest(Guest guest)
        {
            string queryString = "INSERT INTO Gæst (Gæst_Nr,Navn,Adresse) VALUES (@Number, @Name, @Address)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Number", guest.GuestNr);
                    command.Parameters.AddWithValue("@Name", guest.Name);
                    command.Parameters.AddWithValue("@Address", guest.Address);
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

        public bool UpdateGuest(Guest guest, int guestNr)
        {
            string queryString = "UPDATE Gæst SET Gæst_Nr=@Number,Navn=@Name,Adresse=@Address WHERE Gæst_Nr=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Number", guest.GuestNr);
                    command.Parameters.AddWithValue("@Name", guest.Name);
                    command.Parameters.AddWithValue("@Address", guest.Address);
                    command.Parameters.AddWithValue("@id", guestNr);
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

        public Guest DeleteGuest(int guestNr)
        {
            Guest guest = new Guest();
            string queryString = "DELETE FROM Gæst WHERE Gæst_Nr=@Number";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@Number", guestNr);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (SqlException)
                {
                    return guest;
                }
            }
            return guest;
            //Guest guestr = new Guest(); string queryString = "DELETE FROM Guest WHERE Gæst_Nr=@IDG";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    command.Parameters.AddWithValue("@IDG", guestNr);
            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    connection.Close();
            //}
            //return guestr;
        }
    }
}