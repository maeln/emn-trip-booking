using FlightWS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace FlightWS.Controllers
{
    public class FlightController : ApiController
    {
        [Route("get_cities/")]
        public IEnumerable<string> getCities()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=localhost;Database=VOL;User Id=ext;Password = commodore64; ";
            connection.Open();

            SqlCommand command = new SqlCommand("dbo.sp_getVilles", connection);
            command.CommandType = CommandType.StoredProcedure;

            List<string> res = new List<string>();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                res.Add((string)reader[0]);
            }

            return res;
        }

        [Route("get_flights/{departure}/{arrival}")]
        public IEnumerable<Flight> getFlights(string departure, string arrival)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=localhost;Database=VOL;User Id=ext;Password = commodore64; ";
            connection.Open();

            SqlCommand command = new SqlCommand("dbo.sp_getVolsLibres", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@villeDepart", departure);
            command.Parameters.AddWithValue("@villeArrivee", arrival);

            List<Flight> res = new List<Flight>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Flight tmp = new Flight();
                tmp.id = reader.GetInt32(0);
                tmp.heure_depart = reader.GetDateTime(1);
                tmp.heure_arrivee = reader.GetDateTime(2);
                tmp.ville_depart = reader.GetString(3);
                tmp.ville_arrive = reader.GetString(4);
                res.Add(tmp);
            }

            return res;
        }
    }
}
