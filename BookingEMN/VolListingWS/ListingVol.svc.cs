using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace VolListingWS
{
    public class ListingVol : IListingService
    {
        public string[] getCities()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=MAEL-PC\\SQLEXPRESS;Initial Catalog=CMDVOL;Persist Security Info=True;User ID=ext;Password=commodor64";
            connection.Open();

            SqlCommand command = new SqlCommand("sp_getVilles", connection);
            command.CommandType = CommandType.StoredProcedure;

            List<string> res = new List<string>();

            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                res.Add((string) reader[0]);
            }

            return res.ToArray();
        }

        public Flight[] getFlight(string departure, string arrival)
        {
            throw new NotImplementedException();
        }
    }
}
