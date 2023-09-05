using System.Numerics;
using TestPackPlanner.Model;

namespace TestPackPlanner.InputData {
    public class InputReader
    {
        public ConfigurationPack ReadInputFile(string folderName, string fileName)  {

            string filePath = Path.Combine(folderName, fileName);
            ConfigurationPack? packConfiguration = null;

            if (File.Exists(filePath)) {
                using (StreamReader streamReader = new StreamReader(filePath)) {
                    string line = "";
                    bool headerInIputCase = true;
                    bool fileIsEmpty = true;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                            break;
                        var lineData = line.Split(",");
                        if (headerInIputCase) {
                            if (TryGetConfigurationPack(lineData, out packConfiguration)) {
                                headerInIputCase = !headerInIputCase;
                                fileIsEmpty = false;
                            }                            
                            else
                                throw new Exception($"Wrong data in input file (Pack): [{line}]");
                        }
                        else {
                            ItemSet? items;
                            if (TryGetItem(lineData, out items)) {
                                packConfiguration.Items.Add(items);
                                fileIsEmpty = false;
                            }   
                            else
                                throw new Exception($"Wrong data in iput file (Item): [{line}]");
                        }
                    }
                    if(fileIsEmpty)
                        throw new Exception($"The file is empty!");
                    return packConfiguration;
                }
            }
            else {
                throw new FileNotFoundException("Input file not found");
            }
        }


        private bool TryGetConfigurationPack(string[] data, out ConfigurationPack? pack)
        {
            pack = null;
            string order = data[0];
            SortOrder sortOrder;
            if (SortOrder.NATURAL.ToString() == order) {
                sortOrder = SortOrder.NATURAL;
            }
            else if (SortOrder.LONG_TO_SHORT.ToString() == order) {
                sortOrder = SortOrder.LONG_TO_SHORT;
            }
            else if (SortOrder.SHORT_TO_LONG.ToString() == order) {
                sortOrder = SortOrder.SHORT_TO_LONG;
            }
            else
                return false;

            int maxItems;
            double maxWeight;

            if (int.TryParse(data[1], out maxItems) && double.TryParse(data[2], out maxWeight)) {
                pack = new ConfigurationPack(sortOrder, maxItems, maxWeight);
                return true;
            }
            return false;
        }

        private bool TryGetItem(string[] data, out ItemSet? item) {
            item = null;
            BigInteger itemId;
            float itemLenght;
            int itemQuantity;
            double itemWeight;

            if (BigInteger.TryParse(data[0], out itemId) && float.TryParse(data[1], out itemLenght) && int.TryParse(data[2], out itemQuantity) && double.TryParse(data[3], out itemWeight)) {
                item = new ItemSet(itemId, itemLenght, itemQuantity, itemWeight);
                return true;
            }
            return false;
        }
    }
}
