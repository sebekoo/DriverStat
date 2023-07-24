using DriverStat;

ShowMenu();

void ShowMenu()
{
    Driver driver = new();
    var exitProgram = true;

    while (exitProgram)
    {
        MainMenu();

        string optionMenu = Console.ReadLine();
        Console.Clear();
        
        switch (optionMenu)
        {
            case "1":
                driver = CreateDriver();
                if (driver != null)
                {
                    MenuGrade(driver);
                }
                break;
            case "2":
                DriverFile.ReadGradesFromFile();
                driver.PrintStatistics();
                break;
            default:
                Console.WriteLine("***  Are you sure want to close program y/n ? ***");
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

void MainMenu()
{
    var index = 1;
    Console.WriteLine();
    Console.WriteLine("Hello driver! \nThe program will calculate your driving statistics.\n");
    Console.WriteLine("{0}. Create Driver and add grade", index++);
    Console.WriteLine("{0}. Show statistics", index++);
    Console.WriteLine("{0}. Exit program", index++);
}

Driver CreateDriver()
{
    Console.Clear();
    Console.WriteLine("Enter driver details.");
    Console.Write("     name: ");
    var name = Console.ReadLine();
    if (CheckStringIsEmpty("Driver Name", name))
    {
        return null;
    }
    Console.Write("  surname: ");
    var surname = Console.ReadLine();
    if (CheckStringIsEmpty("Driver Surname", surname))
    {
        return null;
    }

    Console.Write("ID driver: ");
    var lenght = Console.ReadLine();
    bool isNumber = int.TryParse(lenght, out var number);
    bool isLongerThanOne = lenght.Length > 1;

    if (!isNumber)
    {
        Console.WriteLine("ID driver must be number \n  Press any key to continue");
        Console.ReadKey();
        return null;
    }
    else if (isLongerThanOne)
    {
        Console.WriteLine("ID driver is too long \n  Press any key to continue");
        Console.ReadKey();
        return null;
    }
    else
    {
        CheckStringIsEmpty("ID driver ", name);
    }

    var idDriver = int.Parse(lenght);
    var driver = new Driver(name, surname, idDriver);

    return driver;
}
bool CheckStringIsEmpty(string msg, string value)
{
    if (string.IsNullOrEmpty(value))
    {
        Console.WriteLine("{0} cannot be empty or blank", msg);
        Console.ReadKey();
        return true;
    }
    return false;
}

void MenuGrade(Driver grade)
{
    Console.WriteLine();
    Console.WriteLine("1. Calculate statistics");
    Console.WriteLine("2. Calculate statistics and save grade to file");
    Console.WriteLine("3. Back to previous menu");

    string optionGrade = Console.ReadLine();
    string inDrv;
    var driverFile = new DriverFile();

    if (optionGrade == "1" || optionGrade == "2")
    {
        while (grade.grades.Count < 6)
        {
            Console.Write("For exit press \"q\". Give the driver a rating: ");
            inDrv = Console.ReadLine();

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
                grade.AddGrade(inDrv);
                if (optionGrade == "2")
                {
                    driverFile.SaveToFile(inDrv);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception Catched: {e.Message}");
            }
        }
    }
    else if (optionGrade == "3")
    {
        Console.Clear();
        return;
    }
}
