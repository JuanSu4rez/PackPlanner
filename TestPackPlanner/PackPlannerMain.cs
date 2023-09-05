using TestPackPlanner.Data;
using TestPackPlanner.InputData;
using TestPackPlanner.Model;

namespace PackPlanner
{
    public class PackPlannerMain {

        static void Main() {

            ConfigurationPack config = null;
            InputReader inputReader = new InputReader();
            InputValidator validator = new InputValidator();
            try {                
                config = inputReader.ReadInputFile();
            }
            catch (Exception e) {
                Console.WriteLine($"There was an error while reading the input file. \n{e.Message}");
            }
            if (config != null) {
                if (validator.IsConfigurationValid(config)) {
                    PackGenerator generator = new PackGenerator();
                    var packs = generator.GeneratePackages(config);

                    PackPrinter packPrinter = new PackPrinter();
                    packPrinter.Print(packs);
                    return;
                }
                Console.WriteLine("Packages cannot be created for the given input.");
            }
        }
    }
}