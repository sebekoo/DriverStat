﻿namespace DriverStat
{
    public class Driver : DriverBase
    {
        private const string fileName = "driver.txt";

        public List<int> listStat = new();

        public Driver()
            : base()
        {
        }

        public Driver(string name, string surname, int idDriver)
            : base()
        {
            Name = name;
            Surname = surname;
            IdDriver = idDriver;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdDriver { get; set; }
        public int PunktyKarne { get; set; }

        public int Result
        {
            get
            {
                return listStat.Sum();
            }
        }

        public override void AddGrade(string grade)
        {
            if (grade.Length > 2)
            {
                Console.WriteLine("Max rating is 99");
            }
            else if (int.TryParse(grade, out int result))
            {
                AddGrade(result);
            }
            else
            {
                Console.WriteLine("You must enter the rating in numerical form");
            }
        }

        public override void AddGrade(int grade)
        {
            listStat.Add(grade);
        }

        public void ReadGradesFromFile()
        {
            Name = "Adam";
            Surname = "Kowalski";
            IdDriver = 2;

            var grades = new List<int>();
            if (File.Exists($"{fileName}"))
            {
                using var reader = File.OpenText(fileName);
                var line = reader.ReadLine();
                while (line != null)
                {
                    var nember = int.Parse(line);
                    grades.Add(nember);
                    line = reader.ReadLine();
                }
            }
            listStat = grades;
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach (var grade in listStat)
            {
                statistics.AddGrade(grade);
            }

            return statistics;
        }

        public void PrintStatistics()
        {
            if (Name == null)
            {
                Console.WriteLine("Please first create driver and grade ");
                Console.WriteLine();
                return;
            }

            if (listStat.Count == 0)
            {
                Console.WriteLine("Driver is not grade. Please grade Driver");
                Console.WriteLine();
                return;
            }
            var driverStats = GetStatistics();
            Console.WriteLine($"Min - {driverStats.Min}");
            Console.WriteLine($"Max - {driverStats.Max}");
            Console.WriteLine($"Avg - {driverStats.Avg:N0}");

        }
    }
}
