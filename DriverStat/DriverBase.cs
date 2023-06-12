namespace DriverStat
{
    public abstract class DriverBase
    {
        public DriverBase()
        {
        }
        public abstract void AddGrade(string grade);
        public abstract void AddGrade(int grade);
        public abstract Statistics GetStatistics();
    }
}
