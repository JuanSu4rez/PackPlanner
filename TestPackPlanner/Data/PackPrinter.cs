
using TestPackPlanner.Model;

namespace TestPackPlanner.Data
{
    public class PackPrinter
    {
        private string packNumber = "Pack Number";
        private string packLength = "Pack Length";
        private string packWeight = "Pack Weight";
        public void Print(List<Pack> packs) {
            foreach (Pack pack in packs) {
                Console.WriteLine($"{packNumber}: {pack.packId}");
                foreach (ItemSet item in pack.Items) {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"{packLength}: {pack.Length}, {packWeight}: {(float)pack.CurrentWeight} \n");
            }
        }
    }
}
