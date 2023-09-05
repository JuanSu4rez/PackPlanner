
using System.Numerics;

namespace TestPackPlanner.Model
{
    public class ItemSet
    {
        public BigInteger ItemId { get; set; }
        public float Lenght { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }

        public ItemSet(BigInteger Id, float Lenght, int Quantity, double Weight)
        {
            this.ItemId = Id;
            this.Lenght = Lenght;
            this.Quantity = Quantity;
            this.Weight = Weight;
        }

        public override string ToString() {
            return $"{this.ItemId},{this.Lenght},{this.Quantity},{this.Weight}";
        }

    }
}
