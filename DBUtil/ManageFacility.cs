using System.Collections.Generic;
using System.Data.SqlClient;
using HotelModels;

namespace HotelRestService2.DBUtil
{
    public class ManageFacility : IManageFacility
    {
        private string connectionString =
            "Data Source=simonshndbserver.database.windows.net;Initial Catalog=SimonSHN;User ID=simo35c9;Password=Simon1234;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Facility> GetAllFacilities()
        {
            List<Facility> facilityList = new List<Facility>();
            string queryString = "SELECT * FROM Facilitet";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Facility facility = new Facility();
                        facility.FacilityNo = reader.GetInt32(0);
                        facility.HotelNo = reader.GetInt32(1);
                        facility.Name = reader.GetString(2);
                        facilityList.Add(facility);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return facilityList;
        }

        public Facility GetFacilityFromId(int facilityNr)
        {
            Facility facility = new Facility();
            string queryString = "SELECT * FROM Facilitet WHERE Facilitet_Nr="+facilityNr;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        facility.FacilityNo = reader.GetInt32(0);
                        facility.HotelNo = reader.GetInt32(1);
                        facility.Name = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return facility;
        }

        public bool CreateFacility(Facility facility)
        {
            int noRows;
            string queryString = "INSERT INTO Facilitet (Facilitet_Nr,Hotel_Nr,Navn) VALUES (@id, @hotel, @name)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", facility.FacilityNo);
                    command.Parameters.AddWithValue("@hotel", facility.HotelNo);
                    command.Parameters.AddWithValue("@name", facility.Name);
                    command.Connection.Open();
                    noRows = command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                catch (SqlException)
                {
                    return false;
                }
            }

            return noRows == 1;
        }

        public bool UpdateFacility(Facility facility, int facilityNr)
        {
            string queryString = "UPDATE Facilitet SET Hotel_Nr=@hotel,Navn=@name WHERE Facilitet_Nr=@id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@id", facilityNr);
                    command.Parameters.AddWithValue("@hotel", facility.HotelNo);
                    command.Parameters.AddWithValue("@name", facility.Name);
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

        public Facility DeleteFacility(int facilityNr)
        {
            Facility facility = new Facility();
            string queryString = "DELETE FROM Facilitet WHERE Facilitet_Nr=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@id", facilityNr);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        facility.FacilityNo = reader.GetInt32(0);
                        facility.HotelNo = reader.GetInt32(1);
                        facility.Name = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return facility;
        }
    }
}