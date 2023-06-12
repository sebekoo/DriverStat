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
                driver.ReadGradesFromFile();
                break;
            case "3":
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
    Console.WriteLine("Hello driver! \nThe program will calculate your driving statistics.");
    Console.WriteLine();
    Console.WriteLine("{0}. Create Driver and add grade", index++);
    //Console.WriteLine("{0}. Save stat to file", index++);
    Console.WriteLine("{0}. Read stat from file", index++);
    Console.WriteLine("{0}. Print driver ratings", index++);
    Console.WriteLine("{0}. Exit program", index++);

}
Driver CreateDriver()
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
bool CheckStringIsEmpty(string msg, string value)
{
    if (string.IsNullOrEmpty(value))
    {
        Console.WriteLine("{0} Cannot be empty or null", msg);
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
    if (optionGrade == "1")
    {
        while (grade.listStat.Count < 7)
        {
            Console.Write("Give the driver a rating: ");
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
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception Catched: {e.Message}");
            }
        }
    }
    else if (optionGrade == "2")
    {
        var file = new DriverFile();
        while (grade.listStat.Count < 7)
        {
            Console.Write("Give the driver a rating: ");
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
                file.AddGrade(inDrv);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception Catched: {e.Message}");
            }
        }
    }
    else
    {
        Console.Clear();
    }
}

void ReadFromFile()
{
    DriverFile driverFile = new DriverFile();
    driverFile.GetStatistics();
}
