using TestPackPlanner.InputData;

namespace TestPackPlanner.Data {
    public class InputValidator {

        public bool IsConfigurationValid(ConfigurationPack configurationPack) {
            if (configurationPack.MaxWeight <= 0f || configurationPack.MaxNumberOfItems <= 0)
                return false;
            if(configurationPack.Items.Count == 0)
                return false;
            foreach (var item in configurationPack.Items) {
                if (item.Weight > configurationPack.MaxWeight)
                    return false;
                if (item.Weight <= 0f)
                    return false;
            }
            return true;
        }
    }
}
