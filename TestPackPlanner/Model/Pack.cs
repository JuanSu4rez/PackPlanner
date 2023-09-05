
using System.Numerics;

namespace TestPackPlanner.Model
{
    public class Pack {

        public BigInteger packId { get; set; }
        public List<ItemSet> Items { get; set; }
        public int MaxNumberOfItems { get; set; }

        public float Length { get; set; }
        public double MaxWeight { get; set; }
        public double CurrentWeight { get; set; }

        public Pack(BigInteger id, int MaxNumberOfItems, double MaxWeight) {
            packId = id;
            this.MaxNumberOfItems = MaxNumberOfItems;
            this.MaxWeight = MaxWeight;
            Items = new List<ItemSet>();
            CurrentWeight = 0;
            Length = 0;
        }
    }
}
