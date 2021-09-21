using Models;
using System;

namespace BLayer
{
    public class BusinessLogic
    {
        static Trip currentTrip;

        public static void createTrip(long id, string name, string activity, DateTime tripDate, int spotsAvailable)
        {
            currentTrip = new Trip(id, name, activity, tripDate, spotsAvailable);
            //DBAccess.
        }
    }
}
