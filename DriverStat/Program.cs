namespace DriverStat
{
    class Program
    {
        private static Driver Driver;
        
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

            Driver.AddGrade(3);
            Driver.AddGrade(4);
            Driver.AddGrade(5);
            var statistics = Driver.GetStatistisc();
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
        static void PrintMenu()
        {
            Console.WriteLine("Hello driver! \nThe program will calculate your driving statistics.");
            Console.WriteLine();
            Console.WriteLine("1. Driver rating");
            Console.WriteLine("2. Show statistics");
            Console.WriteLine("3. Exit program");
        }
        static void CreateDriver()
        {
            Console.Clear();
            Console.WriteLine("Enter driver details.");
            Console.Write("name: ");
            Driver = new Driver();


            Driver.Name = Console.ReadLine();
            Console.Write("surname: ");
            Driver.Surname = Console.ReadLine();
            Console.Write("ID driver: ");
            Driver.IdDriver = int.Parse(Console.ReadLine());
        }
        static void DriverGrade()
        {
            Console.Clear();
            Console.WriteLine("1. Calculate statistics");
            Console.WriteLine("2. Calculate statistics and save grade to file");
            Console.WriteLine("3. Back to previous menu");

            string optionGrade = Console.ReadLine();

            

            if (optionGrade == "1")
            {
                while (true)
                {
                    Console.Write("Podaj ocenę pracownika: ");
                    var inEmp = Console.ReadLine();

                    if (inEmp == "q" || inEmp == "Q")
                    {
                        break;
                    }
                    else if (inEmp == "")
                    {
                        Console.WriteLine("Nie podano oceny");
                        continue;

                    }
                    try
                    {
                        Driver.AddGrade(inEmp);
                        //employee.AddGrade(inEmp);
                        //supervisor.AddGrade(inEmp);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Exception Catched: {e.Message}");
                    }
                }
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

        public static void AddGradeToMemory()
        {
            Driver.AddGrade(5);
        }
        static void AddGradeToFile()
        {

        }
        static void ReadFromFile()
        {

        }
    }
}