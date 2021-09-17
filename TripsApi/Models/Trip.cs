using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripsApi.Models
{
    public class Trip
    {
        public long TripId { get; set; }
        public string Name { get; set; }
        public string Activity { get; set; }
        public DateTime TripDate { get; set; }
    }
}
