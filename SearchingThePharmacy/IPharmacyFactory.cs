using SearchingThePharmacy.Models;
using System.Collections.Generic;

namespace SearchingThePharmacy
{
    public interface IPharmacyFactory
    {
        IEnumerable<Pharmacy> ReadFromFile(string path);
    }
}
