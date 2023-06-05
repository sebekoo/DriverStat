namespace DriverStat
{
    class Program
    {
        //private static Driver Driver;
        
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

            //Driver.AddGrade(3);
            //Driver.AddGrade(4);
            //Driver.AddGrade(5);
            //var statistics = Driver.GetStatistisc();
            //Console.WriteLine($"{statistics.Min}");
            //Console.WriteLine();
            //Console.WriteLine($"{statistics.Max}");
            //Console.WriteLine();
            //Console.WriteLine($"{statistics.Avg}");
            #endregion

        }



        static void ShowMenu()
        {
            var driver = new Driver();
            var exitProgram = true;

            while(exitProgram)
            {
                PrintMenu();
                string optionMenu = Console.ReadLine();

                switch (optionMenu)
                {
                    case "1":
                        driver = CreateDriver();
                        break;
                    case "2":
                        ReadFromFile();
                        break;
                    case "3":
                        DriverGrade(driver);
                        break;
                    case "4":
                        driver.PrintStatistics();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Thanks for using the program");
                        break;
                        exitProgram = false;
                }

            }

            //if (optionMenu == "1")
            //{
            //    driver = CreateDriver();
            //}
            //else if (optionMenu == "2")
            //{
            //    ReadFromFile();
            //}
            //else
            //{
            //    Console.Clear();
            //    Console.WriteLine("Thanks for using the program");
            //    return;
            //}

            //DriverGrade(driver);
        }
        static void PrintMenu()
        {
            Console.WriteLine("Hello driver! \nThe program will calculate your driving statistics.");
            Console.WriteLine();
            Console.WriteLine("1. Driver rating");
            Console.WriteLine("2. Show statistics");
            Console.WriteLine("3. Add rating for driver");
            Console.WriteLine("4. Print driver ratings");
            Console.WriteLine("5. Exit program");
        }
        static Driver CreateDriver()
        {
            Console.Clear();
            Console.WriteLine("Enter driver details.");
            Console.Write("name: ");

            var driver = new Driver();
            driver.Name = Console.ReadLine();
            Console.Write("surname: ");
            driver.Surname = Console.ReadLine();
            Console.Write("ID driver: ");
            driver.IdDriver = int.Parse(Console.ReadLine());

            return driver;
        }
        static void DriverGrade(Driver driver)
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
                    Console.Write("Give the driver a rating: ");
                    var inEmp = Console.ReadLine();

                    if (inEmp == "q" || inEmp == "Q")
                    {
                        break;
                    }
                    else if (inEmp == "")
                    {
                        Console.WriteLine("No rating provided");
                        continue;

                    }
                    try
                    {
                        driver.AddGrade(inEmp);
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

        public static void AddGradeToMemory(Driver driver)
        {
            driver.AddGrade(5);
        }
        static void AddGradeToFile()
        {

        }

        static void ReadFromFile()
        {

        }
    }
}