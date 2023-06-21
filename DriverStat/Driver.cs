namespace DriverStat
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
            if(grade < 0)
            {
                Console.WriteLine("The rating can't be negative \n");
            }
            else if (grade > 99)
            {
                Console.WriteLine("Max rating is 99 \n");
            }
            else
            {
                listStat.Add(grade);
            }
        }

        public void ReadGradesFromFile()
        {
            var grades = new List<int>();
            if (File.Exists(fileName))
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
            else
            {
                Console.WriteLine("File does not exist.");
                Console.WriteLine("First must create and grade driver");
                Console.ReadKey();
                listStat = grades;
            }
        }
        public void CalculateAndSave()
        {
            //string[] lines = File.ReadAllLines(fileName);

            // Sprawdzamy zawartość ostatniej linii
            //if (lines.Length > 0)
            //{
            //    string lastLine = lines[lines.Length - 1];
            //    Console.WriteLine("Ostatnia linia w pliku: " + lastLine);
            //}
            //if (!string.IsNullOrEmpty(lines.Last()))
            //{
            //    var x = lines.Last();
            //    File.AppendAllText(fileName, Environment.NewLine);
            //}
            using var writer = File.AppendText(fileName);
            if (File.Exists(fileName))
            {
                //using var sw = new StreamWriter(fileName, true);
                for (int i = 0; i < listStat.Count; i++)
                {
                    writer.WriteLine(listStat[i]);
                }
            }
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
                Console.ReadKey();
                return;
            }

            if (listStat.Count == 0)
            {
                Console.WriteLine("Driver is not grade. Please grade Driver");
                Console.ReadKey();
                return;
            }
            var driverStats = GetStatistics();
            Console.WriteLine($"Min - {driverStats.Min}");
            Console.WriteLine($"Max - {driverStats.Max}");
            Console.WriteLine($"Avg - {driverStats.Avg:N0}");

        }
    }
}
