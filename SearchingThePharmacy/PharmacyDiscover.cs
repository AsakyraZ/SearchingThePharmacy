using SearchingThePharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchingThePharmacy
{
    public class PharmacyDiscover : IPharmacyDiscover
    {
        private readonly List<Pharmacy> pharmacies;

        public PharmacyDiscover(IEnumerable<Pharmacy> pharmacies)
        {
            if (pharmacies == null)
            {
                throw new ArgumentNullException("pharmacies", "Pharmacies is required for PharmacyDiscover.");
            }

            this.pharmacies = pharmacies.ToList();
        }

        /// <summary>
        /// Получить до 3ех ближайших аптек для указанной точки. Сначала самые близкие.
        /// </summary>
        /// <param name="position">Указанная точка, для которой ищем ближайшие аптеки</param>
        /// <returns>Ближайщие аптеки</returns>
        public List<Pharmacy> GetNearbyFor(GeoPosition position)
        {
            if (position == null)
            {
                throw new ArgumentNullException("position");
            }

            if (this.pharmacies.Count < 2)
            {
                // В справочнике 0 или 1 аптека
                return this.pharmacies;
            }

            var distances = new double[3];

            distances[0] = CalculateDistance(position, this.pharmacies[0].Position);
            distances[1] = CalculateDistance(position, this.pharmacies[1].Position);

            if (this.pharmacies.Count == 2)
            {
                if (distances[0] > distances[1])
                {
                    this.pharmacies.Reverse(); // TODO: проверить...точно ли переворачивает?
                }

                return this.pharmacies;
            }

            distances[2] = CalculateDistance(position, this.pharmacies[2].Position);

            var helper = new ThreeNearbyHelper(distances[0], distances[1], distances[2]);

            for (var i = 3; i < this.pharmacies.Count; i++)
            {
                helper.TryAdd(i, CalculateDistance(position, this.pharmacies[i].Position));
            }

            var nearbyPharmacies = new List<Pharmacy>();
            foreach (var index in helper.GetValues())
            {
                nearbyPharmacies.Add(this.pharmacies[index]);
            }

            return nearbyPharmacies;
        }

        private static double CalculateDistance(GeoPosition x, GeoPosition y)
        {
            return Math.Sqrt((x.Longitude - y.Longitude) * (x.Longitude - y.Longitude)
                + (x.Latitude - y.Latitude) * (x.Latitude - y.Latitude));
        }
    }
}
