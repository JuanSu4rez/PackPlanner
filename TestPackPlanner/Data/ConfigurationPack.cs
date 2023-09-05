using TestPackPlanner.Model;

namespace TestPackPlanner.InputData {
    public class ConfigurationPack
    {
        public SortOrder SortOrder { get; set; }
        public List<ItemSet> Items { get; set; }
        public int MaxNumberOfItems { get; set; }
        public double MaxWeight { get; set; }

        public ConfigurationPack(SortOrder order, int maxItems, double maxWeight) {
            SortOrder = order;
            MaxNumberOfItems = maxItems;
            MaxWeight = maxWeight;
            Items = new List<ItemSet>();
        }

        public override string ToString() {
            return $"{SortOrder} {MaxNumberOfItems} {MaxWeight}";
        }
    }
}
