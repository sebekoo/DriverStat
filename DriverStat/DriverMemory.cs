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
            : base()
        {
            Name = name;
            Surname = surname;
            IdDriver = idDriver;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdDriver { get; set; }
        public int Result
        {
            get
            {
                return grades.Sum();
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
                Console.WriteLine("You must enter the rating in numerical form \n");
            }
        }

        public override void AddGrade(int grade)
        {
            if (grade < 0)
            {
                Console.WriteLine("The rating can't be negative \n");
            }
            else if (grade > 99)
            {
                Console.WriteLine("Max rating is 99 \n");
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
            if (grades.Count == 0)
            {
                Console.WriteLine("Driver is not grade. Please grade Driver");
                Console.ReadKey();
                return;
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