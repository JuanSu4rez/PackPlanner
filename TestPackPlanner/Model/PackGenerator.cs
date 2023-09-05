using TestPackPlanner.InputData;

namespace TestPackPlanner.Model {
    public class PackGenerator {

        const int PACK_ID_INCREMENT = 1;

        public List<Pack> GeneratePackages(ConfigurationPack Configuration) {

            List<ItemSet> sortedItems = GetSortedItems(Configuration.SortOrder, Configuration.Items.ToList());
           
            List<Pack> packs = new List<Pack>();
            packs.Add(new Pack(PACK_ID_INCREMENT, Configuration.MaxNumberOfItems, Configuration.MaxWeight));
            for (int itemIndex = 0;   itemIndex < sortedItems.Count; itemIndex++) {
                PackItems(Configuration, packs[packs.Count - 1], sortedItems[itemIndex], packs);
            }
            return packs;
        }

        private void PackItems(ConfigurationPack config, Pack currentPack, ItemSet rowItem, List<Pack> packs) {
  
            if (rowItem.Quantity <= 0)
                return;
            int maxNumberOfItemsToAdd = (int)Math.Floor(currentPack.MaxWeight / rowItem.Weight);

            if (maxNumberOfItemsToAdd == 0 || currentPack.MaxNumberOfItems == 0) { 
                Pack newPack = new Pack(packs.Count + PACK_ID_INCREMENT, config.MaxNumberOfItems, config.MaxWeight);
                packs.Add(newPack);
                currentPack = newPack;
                maxNumberOfItemsToAdd = (int)Math.Floor(currentPack.MaxWeight / rowItem.Weight);                
            }

            if ((maxNumberOfItemsToAdd >= currentPack.MaxNumberOfItems) || (maxNumberOfItemsToAdd >= rowItem.Quantity)) {
                int actualNumberOfItemsToAdd = Math.Min(currentPack.MaxNumberOfItems, rowItem.Quantity);
                MoveItemsToPack(currentPack, actualNumberOfItemsToAdd, rowItem);               
            }
            else {
                MoveItemsToPack(currentPack, maxNumberOfItemsToAdd, rowItem);
            }
            PackItems(config, currentPack, rowItem, packs);
        }

        private void MoveItemsToPack(Pack pack, int quantity, ItemSet item) {
            double weightItems = quantity * item.Weight;
            item.Quantity -= quantity;
            pack.Items.Add(new ItemSet(item.ItemId, item.Lenght, quantity, item.Weight));
            pack.MaxNumberOfItems -= quantity;
            pack.MaxWeight -= weightItems;
            pack.CurrentWeight += weightItems;
            pack.Length = Math.Max(item.Lenght, pack.Length);
        }

        private List<ItemSet> GetSortedItems(SortOrder sortOrder, List<ItemSet> items) {
            if(sortOrder == SortOrder.NATURAL)
                return items;
            List<ItemSet> itemsSortedShortToLong = SortItemsShortToLong(items);
            if(sortOrder == SortOrder.SHORT_TO_LONG)
                return itemsSortedShortToLong;
            itemsSortedShortToLong.Reverse();
            return itemsSortedShortToLong;
        }

        private List<ItemSet> SortItemsShortToLong(List<ItemSet> items) {
            return items.OrderBy(item => item.Lenght).ToList();
        }
    }
}
