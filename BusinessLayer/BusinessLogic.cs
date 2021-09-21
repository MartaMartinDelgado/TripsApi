using System;
using TripsApi.Models;

namespace BusinessLayer
{
    public class BusinessLogic
    {
        static Trip currentTrip;

        public static void createTrip(long id, string name, string activity, DateTime tripDate, int spotsAvailable)
        {
            currentTrip = new Trip(id, name, activity, tripDate, spotsAvailable);
            DBAccess.
        }
    }
}
