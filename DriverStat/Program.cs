namespace DriverStat
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
            Driver driver = new Driver();
            
            var dl = driver.DlListy();
            Console.WriteLine(dl);

            Console.WriteLine(driver.listStat.Count); ;
            

            //#region ocena
            //for (int i = 0; i < 7; i++)
            //{
            //    Console.WriteLine($"Day {i + 1}");
            //    Console.Write("How many kilometers have you driven : {0,-10}");
            //    int distance = int.Parse(Console.ReadLine());
            //    Console.Write("How much fuel did I use : ");
            //    int fuel = int.Parse(Console.ReadLine());
            //}
            //#endregion
            //Console.WriteLine(driver.listStat.Count); ;

        }

        static void ShowMenu()
        {
            Driver driver = new Driver();
            var exitProgram = true;

            while (exitProgram)
            {
                PrintMenu();

                string optionMenu = Console.ReadLine();
                Console.Clear();

                switch (optionMenu)
                {
                    case "1":
                        driver = CreateDriver();
                        if (driver != null)
                        {
                            DriverGrade(driver);
                        }
                        break;
                    case "2":
                        ReadFromFile();
                        break;
                    case "3":
                        driver.PrintStatistics();
                        break;
                    default:
                        Console.WriteLine("***  Are you sure want to close progream y/n? ***");
                        var confirmExit = Console.ReadLine();
                        Console.Clear();
                        if (confirmExit.Equals("y"))
                        {
                            Console.WriteLine("Thanks for using the program");
                            exitProgram = false;
                        }
                        break;
                }
            }
        }

        public static void PrintMenu()
        {
            var index = 1;
            Console.WriteLine();
            Console.WriteLine("Hello driver! \nThe program will calculate your driving statistics.");
            Console.WriteLine();
            Console.WriteLine("{0}. Create Driver and add grade", index++);
            Console.WriteLine("{0}. Read stat from file", index++);
            Console.WriteLine("{0}. Print driver ratings", index++);
            Console.WriteLine("{0}. Exit program", index++);

        }
        static Driver CreateDriver()
        {
            Console.Clear();
            Console.WriteLine("Enter driver details.");
            Console.Write("name: ");
            var name = Console.ReadLine();
            if (CheckStringIsEmpty("Driver Name", name))
            {
                return null;
            }
            Console.Write("surname: ");
            var surname = Console.ReadLine();
            if (CheckStringIsEmpty("Driver Surname", surname))
            {
                return null;
            }

            Console.Write("ID driver: ");
            var lenght = Console.ReadLine();
            if (lenght.Length > 1 || lenght == "")
            {
                Console.WriteLine();
                Console.WriteLine("ID driver is not be empty or is too long");
                Console.Clear();
                return null;
            }
            var idDriver = int.Parse(lenght);
            var driver = new Driver(name, surname, idDriver);

            return driver;
        }
        static bool CheckStringIsEmpty(string msg, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("{0} Cannot be empty or null", msg);
                return true;
            }
            return false;
        }
        public static void DriverGrade(Driver driver)
        {
            int dlugoscListy = Main(driver.listStat.Count);
            Console.WriteLine();
            Console.WriteLine("1. Calculate statistics");
            Console.WriteLine("2. Calculate statistics and save grade to file");
            Console.WriteLine("3. Back to previous menu");

            string optionGrade = Console.ReadLine();

            if (optionGrade == "1")
            {
                
                while (dlugoscListy < 7)
                {
                    dlugoscListy++;
                    Console.Write("Give the driver a rating: ");
                    var inDrv = Console.ReadLine();

                    if (inDrv == "q" || inDrv == "Q")
                    {
                        break;
                    }
                    else if (inDrv == "")
                    {
                        Console.WriteLine("No rating provided");
                        continue;
                    }
                    try
                    {
                        driver.AddGrade(inDrv);
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
            }
        }

        private static int Main(int count)
        {
            throw new NotImplementedException();
        }

        public static void AddGradeToMemory(Driver driver)
        {
            driver.AddGrade(5);
        }
        public static void AddGradeToFile()
        {

        }

        public static void ReadFromFile()
        {

        }
    }
}