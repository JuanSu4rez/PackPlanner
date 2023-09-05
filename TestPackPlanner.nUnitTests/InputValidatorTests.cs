using TestPackPlanner.Data;
using TestPackPlanner.InputData;

namespace TestPackPlanner.nUnitTests {
    public class InputValidatorTests {

        InputValidator validator { get; set; }

        [SetUp]
        public void Setup() {
            validator = new InputValidator();
        }

        [Test]
        public void WeightCapacityOfPackIsZero() {

            int itemsCapacity = 30;
            int weightCapacty = 0;

            ConfigurationPack invalidConfiguration = new ConfigurationPack(Model.SortOrder.NATURAL, itemsCapacity, weightCapacty);

            var validationResult = validator.IsConfigurationValid(invalidConfiguration);
            Assert.False(validationResult);
        }

        [Test]
        public void ItemsCapacityOfPackIsZero() {

            int itemsCapacity = 0;
            int weightCapacty = 2000;

            ConfigurationPack invalidConfiguration = new ConfigurationPack(Model.SortOrder.NATURAL, itemsCapacity, weightCapacty);

            var validationResult = validator.IsConfigurationValid(invalidConfiguration);
            Assert.False(validationResult);
        }

        [Test]
        public void ConfigurationPackWitNoItems() {

            int itemsCapacity = 0;
            int weightCapacty = 2000;

            ConfigurationPack invalidConfiguration = new ConfigurationPack(Model.SortOrder.NATURAL, itemsCapacity, weightCapacty);

            var validationResult = validator.IsConfigurationValid(invalidConfiguration);
            Assert.False(validationResult);
        }
    }
}