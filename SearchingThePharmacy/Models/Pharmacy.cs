namespace SearchingThePharmacy.Models
{
    using System;

    public class Pharmacy
    {
        public Pharmacy(string name, string address, GeoPosition position)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name of pharmacy is required.");
            }

            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentException("Address of pharmacy is required.");
            }

            if (position == null)
            {
                throw new ArgumentNullException("position", "Geo position of pharmacy is required.");
            }

            this.Name = name;
            this.Address = address;
            this.Position = position;
        }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public GeoPosition Position { get; private set; }
    }
}
