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

            Assert.That(result, Is.EqualTo(11));
        }
        [Test]
        public void Add_whenDriverCollcteStories_ShouldReturnAvg()
        {
            var driver = new DriverMemory("Jan", "Nowak", 1);
            driver.AddGrade(8);
            driver.AddGrade(6);

            var result = driver.Avg;

            Assert.That(result, Is.EqualTo(7));
        }
        [Test]
        public void Creaded_WhenCreatedDriver_ShouldReturnDriverFile()
        {
            var driver = new DriverFile("Jan", "Nowak", 1);

            var driverFileName = new DriverFile(driver.Name, driver.Surname, driver.IdDriver);
            Assert.That(driverFileName.Name, Is.EqualTo(driver.Name));
            Assert.That(driverFileName.Surname, Is.EqualTo(driver.Surname));
            Assert.That(driverFileName.IdDriver, Is.EqualTo(driver.IdDriver));
        }
        [Test]
        public void CheckingThatThereAreOnlyThreeProperties()
        {
            var driver = new DriverFile("Jan", "Nowak", 1);

            var driverType = driver.GetType();
            var driverProperties = driverType.GetProperties();
            Assert.That(driverProperties.Length, Is.EqualTo(3));
        }
    }
}