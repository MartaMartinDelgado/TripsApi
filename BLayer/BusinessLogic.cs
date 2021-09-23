using DLayer;
using Models;
using System;
using System.Collections.Generic;

namespace BLayer
{
    public class BusinessLogic
    {
        public static Trip selectTrip(int id)
        {
            return DBAccess.getTrip(id);
        }

        public static List<Trip> selectAllTrips()
        {
            return DBAccess.getAllTrips();
        }

        public static int createTrip(Trip trip)
        {
            if (string.IsNullOrWhiteSpace(trip.Name))
            {
                throw new Exception("Name is empty");
            }
            else if (string.IsNullOrWhiteSpace(trip.Activity))
            {
                throw new Exception("Activity is empty");
            }
            //else if ("2020-01-01T00:00:00" > trip.TripDate)
            //{
            //    throw new Exception("Invalid date");
            //}
            else if (trip.SpotsAvailable == 0)
            {
                throw new Exception("Invalid number of spots available");
            }
            else
            {
                return DBAccess.saveTrip(trip);
            }
            
        }

        public static void updateTrip(Trip trip)
        {
            if (string.IsNullOrWhiteSpace(trip.Name))
            {
                throw new Exception("Name is empty");
            }
            else if (string.IsNullOrWhiteSpace(trip.Activity))
            {
                throw new Exception("Activity is empty");
            }
            //else if ("2020-01-01T00:00:00" > trip.TripDate)
            //{
            //    throw new Exception("Invalid date");
            //}
            else if (trip.SpotsAvailable == 0)
            {
                throw new Exception("Invalid number of spots available");
            }
            else
            {
                DBAccess.updateTrip(trip);
            }
        }

        public static void removeTrip(int id)
        {
            DBAccess.deleteTrip(id);
        }
    }
}
