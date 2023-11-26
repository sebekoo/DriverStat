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

        public override void AddGrade(string grade)
        {
            if (int.TryParse(grade, out int result))
            {
                AddGrade(result);
            }
            else
            {
                throw new Exception("You must enter the rating in numerical form \n");
            }
        }

        public override void AddGrade(int grade)
        {
            if (grade < 0)
            {
                throw new Exception("The rating can't be negative \n");
            }
            else if (grade > 99)
            {
                throw new Exception("Max rating is 99 \n");
            }
            else
            {
                grades.Add(grade);
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

        public void PrintStatistics()
        {
            if (grades.Count == 0 || grades.Count == null)
            {
                throw new Exception("Driver is not grade. Please grade Driver");
            }
            var driverStats = GetStatistics();
            Console.WriteLine("Your statistics is: ");
            Console.WriteLine($"Min - {driverStats.Min}");
            Console.WriteLine($"Max - {driverStats.Max}");
            Console.WriteLine($"Avg - {driverStats.Avg:N0}");
        }

        public void PrintDriver()
        {
            Console.WriteLine($"Actual Driver is : {Name}, {Surname}, {IdDriver}");
        }
    }
}