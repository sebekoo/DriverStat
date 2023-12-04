namespace DriverStat
{
    public class DriverMemory : DriverBase
    {
        public List<int> grades = new();

        public DriverMemory()
            : base()
        {
        }
        public DriverMemory(string name, string surname, int idDriver)
            : base(name, surname, idDriver)
        {

        }

        public int Result
        {
            get
            {
                return grades.Sum();
            }
        }

        public int Avg
        {
            get
            {
                return (int)grades.Average();
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}