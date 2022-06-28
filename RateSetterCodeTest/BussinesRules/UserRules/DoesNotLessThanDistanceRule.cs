using RateSetterCodeTest.Common;
using RateSetterCodeTest.Models;
using System;

namespace RateSetterCodeTest.BussinesRules.UserRules
{
    public class DoesNotLessThanDistanceRule
    {
        public static bool IsTrue(Address newUserAddress, Address existingUserAddress)
        {
            double latitude1 = ConvertToRadians(newUserAddress.Latitude);
            double latitude2 = ConvertToRadians(existingUserAddress.Latitude);
            double longitude1 = ConvertToRadians(newUserAddress.Longitude);
            double longitude2 = ConvertToRadians(existingUserAddress.Longitude);

            double dlon = longitude2 - longitude1;
            double dlat = latitude2 - latitude1;
            double calculate = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(latitude1) * Math.Cos(latitude2) *
                        Math.Pow(Math.Sin(dlon / 2), 2);
            double distanceInKM = 2 * Math.Asin(Math.Sqrt(calculate)) * DistanceConstants.RADIUS_OF_EARTH_IN_KM;

            if (distanceInKM <= DistanceConstants.MINIMUM_DISTANCE_IN_KM_RULE) return false;
            else return true;
        }

        private static double ConvertToRadians(decimal value)
        {
            return (double)value * Math.PI / 180;
        }
    }
}
