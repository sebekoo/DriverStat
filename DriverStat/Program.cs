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
        Console.WriteLine("{0}. Create Driver", index++);
        Console.WriteLine("{0}. Add grade", index++);
        Console.WriteLine("{0}. Save grade from file", index++);
        Console.WriteLine("{0}. Read grade from file", index++);
        Console.WriteLine("{0}. Show statistics", index++);
        Console.WriteLine("{0}. Exit program", index++);
        
        string optionMenu = Console.ReadLine();
        Console.Clear();
        
        switch (optionMenu)
        {
            case "1":
                if (!string.IsNullOrEmpty(driver.Name))
                {
                    driver.PrintDriver();
                    Console.WriteLine("Do You want create new Driver ? y/n :");
                    var yesNo = Console.ReadLine();

                    if (!yesNo.Equals("y"))
                    {
                        break;
                    }
                }
               driver = CreateDriver();
                break;
            case "2":
                while (driver.grades.Count < 6)
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
                    driver.AddGrade(inDrv);
                }
                break;
            case "3":
                if (driver.grades.Count == 0)
                {
                    Console.WriteLine("Brak ocen do zapisania");
                    break;
                }
                DriverFile.SaveToFile(driver.grades);
                break;
            case "4":
                driver.grades = DriverFile.ReadGradesFromFile();
                if (driver.grades.Count == 0)
                {
                    Console.WriteLine("No yet ratings");
                    Console.ReadKey();
                }
                break;
            case "5":
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
