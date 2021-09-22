﻿using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLayer
{
    public class DBAccess
    {
        //SqlConnection conn;
        //public DBAccess()
        //{
        //    conn = new SqlConnection("Data Source = 20.86.154.86; User ID = sa; Password = ********; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        //}

        static string cs = ConfigurationManager.ConnectionStrings["tripsConnector"].ConnectionString;
        static SqlConnection conn = new SqlConnection(cs);

        public static string saveTrip(Trip t)
        {
            long id = t.Id;
            string name = t.Name;
            string activity = t.Activity;
            DateTime tripDate = t.TripDate;
            int spotsAvailable = t.SpotsAvailable;
            SqlCommand cmd = new SqlCommand("INSERT INTO Trip" +
                "tripId,TripName,Activity,TripDate,SpotsAvailable) VALUES(" +
                "@id,@name,@activity,@date,@spots);", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@activity", activity);
            cmd.Parameters.AddWithValue("@date", tripDate);
            cmd.Parameters.AddWithValue("@spots", spotsAvailable);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery
            }

            return "Saved";
        }
    }
}
