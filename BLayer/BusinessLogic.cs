using DLayer;
using Models;
using System;

namespace BLayer
{
    public class BusinessLogic
    {
        
        public static void createTrip(Trip trip)
        {
            if (string.IsNullOrEmpty(trip.Name))
            {
                throw new Exception("Name is empty");
            }

            DBAccess.saveTrip(trip);
        }
    }
}
