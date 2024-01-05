using DriverStat;
namespace Driver.Tests
{
    public class DriverStatTests
    {
        [Test]
        public void Add_WhenDriverCollectStories_ShouldReturnSum()
        {
            var driver = new DriverMemory("Jan", "Nowak", 1);
            driver.AddGrade(5);
            driver.AddGrade(6);

            var result = driver.Result;

            Assert.AreEqual(11, result);
        }
        [Test]
        public void Add_whenDriverCollcteStories_ShouldReturnAvg()
        {
            var driver = new DriverMemory("Jan", "Nowak", 1);
            driver.AddGrade(8);
            driver.AddGrade(6);

            var result = driver.Avg;

            Assert.AreEqual(7, result);
        }
        [Test]
        public void Creaded_WhenCreatedDriver_ShouldReturnDriverFile()
        {
            var driver = new DriverFile("Jan", "Nowak", 1);

            var driverType = driver.GetType();
            var driverProperties = driverType.GetProperties();
            Assert.AreEqual(3, driverProperties.Length);

            var driverFileName = new DriverFile(driver.Name, driver.Surname, driver.IdDriver);
            Assert.AreEqual(driver.Name, driverFileName.Name);
            Assert.AreEqual(driver.Surname, driverFileName.Surname);
            Assert.AreEqual(driver.IdDriver, driverFileName.IdDriver);
        }
    }
}