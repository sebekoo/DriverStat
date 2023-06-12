namespace DriverStat
{
    public interface IDriver
    {
        string Name { get; }
        string Surname { get; }
        int IdDriver { get; }
        void AddGrade(string grade);
        void AddGrade(int grade);
        Statistics GetStatistics();
    }
}
