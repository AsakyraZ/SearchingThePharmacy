using SearchingThePharmacy.Models;
using System.Collections.Generic;

namespace SearchingThePharmacy
{
    public interface IPharmacyDiscover
    {
        List<Pharmacy> GetNearbyFor(GeoPosition position);
    }
}
