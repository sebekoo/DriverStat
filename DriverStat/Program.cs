namespace DriverStat
{
    class Program
    {
        private static string name;
        private static string surname;
        private static int idDriver;
        
        static void Main(string[] args)
        {
            ShowMenu();

            #region ocena
            //for (int i = 0; i < 7; i++)
            //{
            //    Console.WriteLine($"Day {i+1}");
            //    Console.Write("How many kilometers have you driven : ");
            //    int distance = int.Parse(Console.ReadLine());
            //    Console.Write("How much fuel did I use?");
            //    int fuel = int.Parse(Console.ReadLine());
            //}
            #endregion

            #region ShowStatistics
            var driver = new Driver(name, surname, idDriver);
            driver.AddGrade(3);
            driver.AddGrade(4);
            driver.AddGrade(5);
            var statistics = driver.GetStatistisc();
            Console.WriteLine($"{statistics.Min}");
            Console.WriteLine();
            Console.WriteLine($"{statistics.Max}");
            Console.WriteLine();
            Console.WriteLine($"{statistics.Avg}");
            #endregion

        }

        static void ShowMenu()
        {
            PrintMenu();

            string optionMenu = Console.ReadLine();

            if (optionMenu == "1")
            {
                CreateDriver();
            }
            else if (optionMenu == "2")
            {
                ReadFromFile();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Thanks for using the program");
                return;
            }

            DriverGrade();
        }
        private static void PrintMenu()
        {
            Console.WriteLine("Hello driver! \nThe program will calculate your driving statistics.");
            Console.WriteLine();
            Console.WriteLine("1. Driver rating");
            Console.WriteLine("2. Show statistics");
            Console.WriteLine("3. Exit program");
        }
        private static void CreateDriver()
        {
            Console.Clear();
            Console.WriteLine("Enter driver details.");
            Console.Write("name: ");
            name = Console.ReadLine();
            Console.Write("surname: ");
            surname = Console.ReadLine();
            Console.Write("ID driver: ");
            idDriver = int.Parse(Console.ReadLine());
        }
        private static void DriverGrade()
        {
            Console.Clear();
            Console.WriteLine("1. Calculate statistics");
            Console.WriteLine("2. Calculate statistics and save grade to file");
            Console.WriteLine("3. Back to previous menu");

            string optionGrade = Console.ReadLine();

            if (optionGrade == "1")
            {
                AddGradeToMemory();
            }
            else if (optionGrade == "2")
            {
                AddGradeToFile();
            }
            else
            {
                Console.Clear();
                ShowMenu();
            }
        }
        private static void AddGradeToMemory()
        {
            driver.AddGrade(optionGrade);
        }
        private static void AddGradeToFile()
        {

        }
        private static void ReadFromFile()
        {

        }
    }
}