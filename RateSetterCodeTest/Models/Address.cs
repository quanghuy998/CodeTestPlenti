using System;
using System.IO;

namespace RateSetterCodeTest.Models
{
    public class Address
    {
        public string StreetAddress { get; }
        public string Suburb { get; }
        public string State { get; }
        public int PostCode { get; }
        public decimal Latitude { get; }
        public decimal Longitude { get; }

        public Address(string streetAddress, string suburb, string state, int postcode, decimal latitude, decimal longitude)
        {
            StreetAddress = streetAddress ?? throw new ArgumentNullException(nameof(StreetAddress));
            Suburb = suburb ?? throw new ArgumentNullException(nameof(Suburb));
            State = state ?? throw new ArgumentNullException(nameof(State));
            PostCode = postcode;

            if (latitude < -90 && latitude > 90)  throw new InvalidDataException("The value of latitude is from -90 degree to 90 degree");
            else Latitude = latitude;

            if (longitude < -180 && longitude > 180) throw new InvalidDataException("The value of longitude is from -180 degree to 180 degree");
            else Longitude = longitude;
        }

        public string GetAddress()
        {
            return StreetAddress.Trim() + ", " + Suburb.Trim() + ", " + State.Trim() + " " + PostCode;
        }
    }
}
