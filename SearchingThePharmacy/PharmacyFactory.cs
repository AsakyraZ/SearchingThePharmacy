using SearchingThePharmacy.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace SearchingThePharmacy
{
    public class PharmacyFactory : IPharmacyFactory
    {
        private static readonly CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-US");

        public IEnumerable<Pharmacy> ReadFromFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path is required.");
            }

            var pharmacyEntries = File.ReadAllLines(path);
            var pharmacies = new List<Pharmacy>(pharmacyEntries.Length);

            var skipedHeader = false;
            foreach (var pharmacyEntry in pharmacyEntries)
            {
                if (!skipedHeader)
                {
                    skipedHeader = true;
                    continue;
                }

                var parts = pharmacyEntry.Split('|');

                if (parts.Length != 4)
                {
                    throw new Exception(string.Format("Uncorrect format for entry of pharmacy: \"{0}\"", pharmacyEntry));
                }

                // NOTE: Можно делать TryParse() и кидать говорящее исключение о невалидном числе
                var longitude = double.Parse(parts[2], cultureInfo);
                var latitude = double.Parse(parts[3], cultureInfo);

                var position = new GeoPosition(longitude, latitude);
                var pharmacy = new Pharmacy(parts[0], parts[1], position);

                pharmacies.Add(pharmacy);
            }

            return pharmacies;
        }
    }
}
