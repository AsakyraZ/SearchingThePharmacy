namespace SearchingThePharmacy.Models
{
    using System;

    public class GeoPosition
    {
        private const double MinLongitude = -180;
        private const double MaxLongitude = 180;
        private const double MinLatitude = -90;
        private const double MaxLatitude = 90;

        public GeoPosition(double longitude, double latitude)
        {
            if (longitude < MinLongitude || longitude > MaxLongitude)
            {
                throw new ArgumentException("Longitude must be >= -180 and <= 180");
            }

            if (latitude < MinLatitude || latitude > MaxLatitude)
            {
                throw new ArgumentException("Latitude must be >= -90 and <= 90");
            }

            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        public double Longitude { get; private set; }

        public double Latitude { get; private set; }
    }
}
