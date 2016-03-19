using SearchingThePharmacy.Models;
using System;
using System.Globalization;

namespace SearchingThePharmacy
{
    public class Program
    {
        private static readonly CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-US");

        static void Main(string[] args)
        {
            Console.WriteLine("Write file name and your coordinates:");
            var input = Console.ReadLine();

            var parts = input.Split(' ');
            string path = parts[0];
            var longitude = Double.Parse(parts[1], cultureInfo);
            var latitude = Double.Parse(parts[2], cultureInfo);
            var location = new GeoPosition(longitude, latitude);

            var pharmacies = new PharmacyFactory().ReadFromFile(path);
            var nearbyPharmacies = new PharmacyDiscover(pharmacies).GetNearbyFor(location);

            Console.WriteLine("Results:");
            foreach (var nearbyPharmacy in nearbyPharmacies)
            {
                Console.WriteLine(nearbyPharmacy.Name + "\t" + nearbyPharmacy.Address);
            }

            Console.ReadKey();
        }
    }
}
