//namespace DriverStat
//{
//    public class DriverFile : DriverBase
//    {
//        private const string fileName = "driver.txt";
//        public DriverFile()
//            : base()
//        {
//        }
//        public DriverFile(string name, string surname, int idDriver)
//           : base()
//        {
//            Name = name;
//            Surname = surname;
//            IdDriver = idDriver;
//        }
//        public string Name { get; set; }
//        public string Surname { get; set; }
//        public int IdDriver { get; set; }

//        public override void AddGrade(string grade)
//        {
//            if (grade.Length > 2)
//            {
//                Console.WriteLine("Max rating is 99 file");
//            }
//            else if (int.TryParse(grade, out int result))
//            {
//                AddGrade(result);
//            }
//            else
//            {
//                Console.WriteLine("You must enter the rating in numerical form");
//            }
//        }

//        public override void AddGrade(int grade)
//        {
//            using var writer = File.AppendText(fileName);
//            writer.WriteLine(grade);
//        }

//        public override Statistics GetStatistics()
//        {
//            var gradesFromFile = ReadGradesFromFile();
//            var result = CountStatistics(gradesFromFile);
//            return result;
//        }

//        public List<int> ReadGradesFromFile()
//        {
//            var grades = new List<int>();
//            if (File.Exists($"{fileName}"))
//            {
//                using var reader = File.OpenText(fileName);
//                var line = reader.ReadLine();
//                while (line != null)
//                {
//                    var nember = int.Parse(line);
//                    grades.Add(nember);
//                    line = reader.ReadLine();
//                }
//            }
//            return grades;
//        }
//        private Statistics CountStatistics(List<int> grades)
//        {
//            var statistics = new Statistics();
//            foreach (var grade in grades)
//            {
//                statistics.AddGrade(grade);
//            }

//            return statistics;
//        }

//        public void PrintStatistics()
//        {
//            if (Name == null)
//            {
//                Console.WriteLine("Please first create driver and grade ");
//                Console.WriteLine();
//                return;
//            }

//            if (!File.Exists(fileName))
//            {
//                Console.WriteLine("Driver is not grade. Please grade Driver");
//                Console.WriteLine();
//                return;
//            }
//            var driverStats = GetStatistics();
//            Console.WriteLine($"Min - {driverStats.Min}");
//            Console.WriteLine($"Max - {driverStats.Max}");
//            Console.WriteLine($"Avg - {driverStats.Avg:N0}");
//        }
//    }
//}
