namespace Driver.Tests
{
    public class DriverStatTests
    {
        [Test]
        public void Add_WhenDriverCollectStories_ShouldReturnSum()
        {
            var driver = new DriverStat.DriverMemory("Jan", "Nowak", 1);
            driver.AddGrade(5);
            driver.AddGrade(6);

            var result = driver.Result;

            Assert.AreEqual(11, result);
        }
        [Test]
        public void Add_whenDriverCollcteStories_ShouldReturnAvg()
        {
            var driver = new DriverStat.DriverMemory();
            driver.AddGrade(8);
            driver.AddGrade(6);

            var result = driver.Avg; 
            
            Assert.AreEqual(7, result);
        }
    }
}