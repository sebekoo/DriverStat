using DriverStat;

Menu();

void Menu()
{
    DriverMemory driver = new();
    var exitProgram = true;

    while (exitProgram)
    {
        var index = 1;
        Console.WriteLine();
        Console.WriteLine("Hello driver! \nThe program will calculate your driving statistics.\n");
        Console.WriteLine("{0}. Create Driver", index++); //1
        Console.WriteLine("{0}. Add grade", index++); //2
        //Console.WriteLine("{0}. Save grade to file", index++);
        Console.WriteLine("{0}. Show statistics", index++); //3
        Console.WriteLine("{0}. Exit program", index++); //4

        string optionMenu = Console.ReadLine();
        Console.Clear();

        switch (optionMenu)
        {
            case "1":
                if (string.IsNullOrEmpty(driver.Name))
                {
                    driver = CreateDriver();
                }
                else
                {
                    Console.WriteLine("Do You want create new Driver ? y/n :");
                    var yesNo = Console.ReadLine();

                    if (yesNo.Equals("y"))
                    {
                        break;
                    }
                }
                driver.PrintDriver();
                break;
            case "2":
                while (driver.GradeContains() < 6)
                {
                    Console.Write("For exit press \"q\". Give the driver a rating: ");
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
                        Console.WriteLine($"Exception catched: {e.Message}");
                    }
                }
                break;
            case "3":
                if (driver.GradeContains() == 0)
                {
                    Console.WriteLine("No ratings to show");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else
                {
                    driver.GetStatistics();
                    PrintStatistics(driver);
                }
                //DriverFile.SaveToFile(driver.grades);
                break;
            case "4":
                Console.WriteLine("***  Are you sure want to close program y/n ? ***");
                var confirmExit = Console.ReadLine();
                Console.Clear();
                if (confirmExit.Equals("y"))
                {
                    Console.WriteLine("Thanks for using the program");
                    exitProgram = false;
                }
                break;
            default:
                Console.WriteLine("Thanks for using program");
                break;
        }
    }
}

DriverMemory CreateDriver()
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
    var driver = new DriverMemory(name, surname, idDriver);

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
void PrintStatistics(IDriver driver)
{
    var statistics = driver.GetStatistics();
    if (statistics.Count == 0 || statistics.Count == null)
    {
        throw new Exception("Driver is not grade. Please grade Driver");
    }
    else
    {
        //var driverStats = GetStatistics();
        Console.WriteLine("Your statistics is: ");
        Console.WriteLine($"Min - {statistics.Min}");
        Console.WriteLine($"Max - {statistics.Max}");
        Console.WriteLine($"Avg - {statistics.Avg:N0}");
    }
}