using SearchingThePharmacy.Models;
using System.Collections.Generic;
using System.Linq;

namespace SearchingThePharmacy
{
    /// <summary>
    /// Штука, хранящая в себе 3 минимальных значения  поля "value", отсортированные по возрастанию поля "sortedValue".
    /// </summary>
    public class ThreeNearbyHelper
    {
        private readonly List<Pair> sortedList;

        public ThreeNearbyHelper(double value1, double value2, double value3)
        {
            this.sortedList = new List<Pair>();
            this.sortedList.Add(new Pair(0, value1));

            var value2Position = value2 < value1 ? 0 : 1;
            this.sortedList.Insert(value2Position, new Pair(1, value2));

            var value3Pair = new Pair(2, value3);
            this.InsertThirdPair(value3Pair);
        }

        public void TryAdd(int value, double sortedValue)
        {
            if (this.sortedList.Last().SortedValue < sortedValue)
            {
                return;
            }

            var newPair = new Pair(value, sortedValue);
            this.InsertThirdPair(newPair);
            this.sortedList.RemoveAt(3);
        }

        public IEnumerable<int> GetValues()
        {
            return this.sortedList.Select(x => x.Value);
        }

        private void InsertThirdPair(Pair pair)
        {
            if (pair.SortedValue < this.sortedList[0].SortedValue)
            {
                this.sortedList.Insert(0, pair);
                return;
            }

            if (pair.SortedValue < this.sortedList[1].SortedValue)
            {
                this.sortedList.Insert(1, pair);
                return;
            }

            this.sortedList.Insert(2, pair);
        }
    }
}
