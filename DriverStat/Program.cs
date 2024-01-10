using DriverStat;

Title();
MenuProgram();

void MenuProgram()
{
    Console.WriteLine();

    Console.WriteLine("Enter driver details.");
    string name = ReadName();
    string surname = ReadSurname();
    int idDriver = ReadIdDriver();
    string fileName = name + "_" + surname + "_" + idDriver;
    CheckFileExists(fileName);

    IDriver driver = null;

    var exitProgram = true;

    while (exitProgram)
    {
        PrintMenu();
        var optionMenu = Console.ReadLine();

        switch (optionMenu)
        {
            case "1":
                driver = NewDriverInMemory(name, surname, idDriver);
                GradeDriver(driver, fileName);
                PrintStatistics(driver);
                Pause();
                break;

            case "2":
                string path = Directory.GetCurrentDirectory();
                ListFilesTXT(path);
                break;

            case "3":
                driver = NewDriverInFile(name, surname, idDriver);
                if (driver != null)
                {
                    GradeDriver(driver, fileName);
                    PrintStatistics(driver);
                    Pause();
                }
                break;

            case "4":
                driver = NewDriverInFile(name, surname, idDriver);
                try
                {
                    PrintStatistics(driver!);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    if (driver != null)
                    {
                        GradeDriver(driver, fileName);
                        PrintStatistics(driver);
                    }
                }
                Pause();
                break;

            case "5":
                Console.Clear();
                Title();
                MenuProgram();
                break;

            case "6":
                Console.WriteLine("***  Are you sure want to close program y/n ? ***");
                var confirmExit = Console.ReadLine();
                Console.Clear();
                if (confirmExit!.Equals("y"))
                {
                    exitProgram = false;
                }
                break;

            default:
                Console.WriteLine("Thanks for using program");
                exitProgram = false;
                break;
        }
    }
}

string ReadName()
{
    Console.Write("     name: ");
    var name = Console.ReadLine();
    while (name == null || name == "")
    {
        Console.Write("     name: ");
        name = Console.ReadLine();
    }
    return name;
}

string ReadSurname()
{
    Console.Write("  surname: ");
    var surname = Console.ReadLine();
    while (surname == null || surname == "")
    {
        Console.Write("  surname: ");
        surname = Console.ReadLine();
    }
    return surname;
}

int ReadIdDriver()
{
    Console.Write(" idDriver: ");
    var idDriver = 0;
    idDriver = int.Parse(Console.ReadLine()!);
    while (idDriver == null)
    {
        Console.Write(" idDriver: ");
        idDriver = int.Parse(Console.ReadLine()!);
    }
    return idDriver;
}

DriverBase NewDriverInMemory(string name, string surname, int idDriver)
{
    return new DriverMemory(name, surname, idDriver);
}

DriverBase NewDriverInFile(string name, string surname, int idDriver)
{
    return new DriverFile(name, surname, idDriver);
}

static void ListFilesTXT(string path)
{
    try
    {
        string[] files = Directory.GetFiles(path, "*.txt");
        Console.WriteLine("Saved file names: ");
        if (files != null && files.Length > 0)
        {
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
        else
        {
            Console.WriteLine("No stored files.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        throw;
    }
}

void CheckFileExists(string fileName)
{
    if (File.Exists($"{fileName}.txt"))
    {
        Console.WriteLine($"File named '{fileName}.txt' already exists in the default folder.");
    }
    else
    {
        Console.WriteLine($"File named '{fileName}.txt' does not exist in the default folder.");
    }
}

void GradeDriver(IDriver driver, string fileName)
{
    Console.WriteLine("\nFor exit press \"q\"");

    for (int i = 0; i < 7; i++)
    {
        Console.Write("Give the driver a rating: ");
        var inDrv = Console.ReadLine();

        if (inDrv == "q" || inDrv == "Q")
        {
            Console.WriteLine("Exit");
            break;
        }
        else if (inDrv == "")
        {
            Console.WriteLine("No rating provided");
        }
        else
        {
            try
            {
                driver.GradeAdded += DriverGradeAdded;
                driver.AddGrade(inDrv!);
                driver.GradeAdded -= DriverGradeAdded;
                var count = driver.GetStatistics();
                i = count.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception catched: {e.Message}");
                i--;
            }
        }
    }
}

void DriverGradeAdded(object sender, EventArgs args)
{
    Console.WriteLine("Added grade.");
}

void Pause()
{
    Console.WriteLine("Press any key");
    Console.ReadKey();
    Console.Clear();
}

void Title()
{
    Console.WriteLine("Hello driver! \nThe program will calculate your driving statistics.\n");
}

static void PrintMenu()
{
    Console.WriteLine("\n1. Create temprary grade and show statistics");
    Console.WriteLine("2. Show saved files:");
    Console.WriteLine("3. Create new file or update exist file");
    Console.WriteLine("4. Show statistics");
    Console.WriteLine("5. Create new Driver ");
    Console.WriteLine("6. Exit program");
}

void PrintStatistics(IDriver driver)
{
    var statistics = driver.GetStatistics();
    if (statistics.Count == 0 || statistics == null)
    {
        throw new Exception("Driver is not grade. Please grade Driver");
    }
    else
    {
        Console.WriteLine($"\nStatistics for driver: ({driver.Name} {driver.Surname} {driver.IdDriver}) is: ");
        Console.WriteLine($"Min - {statistics.Min}");
        Console.WriteLine($"Max - {statistics.Max}");
        Console.WriteLine($"Avg - {statistics.Avg:N0}\n");
    }
}