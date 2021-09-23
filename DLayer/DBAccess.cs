using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
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

        //static string cs = ConfigurationManager.ConnectionStrings["tripsConnector"].ConnectionString;
        //static SqlConnection conn = new SqlConnection(cs);

        //static string cs = "Data Source=20.86.154.86;User ID=sa;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string cs = "Data Source = 20.86.154.86; Initial Catalog = TripsDB; User ID = sa; Password=********;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string psw;

        static SqlConnection conn;
        public static int init()
        {
            //Create file input reader and create stream
            using (Stream fileStream = new FileStream(@"C:\Users\Marta\Desktop\Folders\Software Development\Advance Programming\CA\TripsApi\DLayer\.psw", FileMode.Open))
            {
                StreamReader r = new StreamReader(fileStream);

                string psw = r.ReadToEnd();

                cs = cs.Replace("********", psw);
            }
            
            conn = new SqlConnection(cs);

            return 1;
        }

        static int fake = init();

        //Remember to call init at the start of the app

        public static int saveTrip(Trip t)
        {
            int id = 0;
            string name = t.Name;
            string activity = t.Activity;
            DateTime tripDate = t.TripDate;
            int spotsAvailable = t.SpotsAvailable;
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Trip " +
                "(TripName,Activity,TripDate,SpotsAvailable) VALUES(" +
                "@name,@activity,@date,@spots);", conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@activity", activity);
            cmd.Parameters.AddWithValue("@date", tripDate);
            cmd.Parameters.AddWithValue("@spots", spotsAvailable);
            try
            {

                conn.Open();
                cmd.ExecuteNonQuery();
                SqlCommand c2 = new SqlCommand("SELECT IDENT_CURRENT('dbo.Trip')", conn);
                object o1 = c2.ExecuteScalar();
                id = int.Parse(o1.ToString());
            }
            finally
            {
                conn.Close();
            }

            return id;
        }

        public static string updateTrip(Trip t)
        {
            int id = t.Id;
            string name = t.Name;
            string activity = t.Activity;
            DateTime tripDate = t.TripDate;
            int spotsAvailable = t.SpotsAvailable;
            SqlCommand cmd = new SqlCommand("EXEC ups_UpdateTrip" +
                "@TripId,@TripName,@Activity,@TripDate,@SpotsAvailable", conn);
            cmd.Parameters.AddWithValue("@TripId", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@activity", activity);
            cmd.Parameters.AddWithValue("@date", tripDate);
            cmd.Parameters.AddWithValue("@spots", spotsAvailable);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

            return "Updated trip ID: " + id;
        }

        public static string deleteTrip(int id)
        {
            SqlCommand cmd = new SqlCommand("EXEC ups_DeleteMembers" +
                "@TripId", conn);
            cmd.Parameters.AddWithValue("@TripId", id);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

            return "Removed trip ID: " + id;
        }
    }
}
