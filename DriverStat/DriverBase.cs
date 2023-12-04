namespace DriverStat
{
    public abstract class DriverBase : IDriver
    {
        public List<int> grades = new(); // ??? Zapytać o tworzenie obiektu tu i w DriverMemory

        public DriverBase()
        {
        }

        protected DriverBase(string name, string surname, int idDriver)
        {
            Name = name;
            Surname = surname;
            IdDriver = idDriver;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int IdDriver { get; private set; }

        public abstract Statistics GetStatistics();

        public void AddGrade(string grade)
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

        public void AddGrade(int grade)
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

        public void PrintDriver()
        {
            Console.WriteLine($"Actual Driver is : {Name}, {Surname}, {IdDriver}");
        }
        public void PrintStatistics()
        {
            if (grades.Count == 0 || grades.Count == null)
            {
                throw new Exception("Driver is not grade. Please grade Driver");
            }
            else
            {
                var driverStats = GetStatistics();
                Console.WriteLine("Your statistics is: ");
                Console.WriteLine($"Min - {driverStats.Min}");
                Console.WriteLine($"Max - {driverStats.Max}");
                Console.WriteLine($"Avg - {driverStats.Avg:N0}");
            }
        }
    }
}