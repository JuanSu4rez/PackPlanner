using TestPackPlanner.InputData;

namespace TestPackPlanner.nUnitTests {
    public class InputReaderTests {

        InputReader inputReader = new InputReader();

        string folderName;
        string fileName;

        [SetUp]
        public void Setup() {
            inputReader = new InputReader();
            folderName = "Testing";            
        }

        [Test]
        public void MissingFileThrowsNotFoundException() {
            fileName = "FILENotFound.txt";
            Assert.Throws<FileNotFoundException>(() => inputReader.ReadInputFile(folderName, fileName));
        }

        [Test]
        public void WrongInputDataThrowsException() {
            fileName = "WrongFormat.txt";
            Assert.Throws<Exception>(() => inputReader.ReadInputFile(folderName, fileName));
        }

        [Test]
        public void WrongSortingOrderThrowsException() {
            fileName = "WrongPackConfiguration.txt";
            Assert.Throws<Exception>(() => inputReader.ReadInputFile(folderName, fileName));
        }

        [Test]
        public void WrongItemDataThrowsException() {
            fileName = "WrongItem.txt";
            Assert.Throws<Exception>(() => inputReader.ReadInputFile(folderName, fileName));
        }

        [Test]
        public void ValidCase() {
            fileName = "ValidCase.txt";
            var result = inputReader.ReadInputFile(folderName, fileName);
            Assert.IsNotNull(result);
        }
    }
}
