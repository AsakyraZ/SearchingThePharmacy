namespace SearchingThePharmacy.Models
{
    public class Pair
    {
        public Pair(int value, double sortedValue)
        {
            this.Value = value;
            this.SortedValue = sortedValue;
        }

        public int Value { get; private set; }

        public double SortedValue { get; private set; }
    }
}
