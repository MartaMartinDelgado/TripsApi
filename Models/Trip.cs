using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Activity { get; set; }
        public DateTime TripDate { get; set; }
        public int SpotsAvailable { get; set; }

        public Trip(int id, string name, string activity, DateTime tripDate, int spotsAvailable)
        {
            this.Id = id;
            this.Name = name;
            this.Activity = activity;
            this.TripDate = tripDate;
            this.SpotsAvailable = spotsAvailable;
        }

    }

    //In case I wanted to hide the available spots from the client

    //public class TripDTO
    //{
    //    public int TripId { get; set; }
    //    public string Name { get; set; }
    //    public string Activity { get; set; }
    //    public DateTime TripDate { get; set; }
    //    public float SpotsAvailable { get; set; }
    //}
}
