namespace Driver.Tests
{
    public class Tests
    {
        [Test]
        public void Test()
        {
            var driver = new DriverStat.Driver();
            driver.AddGrade(5);
            driver.AddGrade(6);

            var result = driver.Result;

            Assert.AreEqual(11, result);
        }
    }
}