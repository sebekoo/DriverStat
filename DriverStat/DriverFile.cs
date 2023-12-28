using System.Xml.Linq;

namespace DriverStat
{
    public class DriverFile : DriverBase
    {
        private string fileName;

        public override event GradeAddedDelegate GradeAdded;

        public DriverFile(string name, string surname, int idDriver)
            : base(name, surname, idDriver)
        {
            fileName = $"{name + "_" + surname + "_" + idDriver}.txt";

            while (!File.Exists($"{fileName}"))
            {
                using var writer = new StreamWriter(fileName, true);
                {
                    if (File.Exists($"{fileName}"))
                    {
                        Console.WriteLine($"New file \"{fileName}\",  has been created");
                    }
                    else
                    {
                        throw new Exception("File has not been created because of unknown error. Try again");
                    }
                }
            }
        }

        public override void AddGrade(int grade)
        {
            if (grade < 0)
            {
                throw new Exception("The rating can't be negative \n");
            }
            else if (grade > 99)
            {
                throw new Exception("Max rating is 99 \n");
            }
            else
            {
                using var writer = File.AppendText(fileName);
                {
                    writer.WriteLine(grade);
                }
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            if (File.Exists(fileName))
            {
                using var reader = File.OpenText(fileName);
                {
                    string line = reader.ReadLine()!;
                    while (line is not null)
                    {
                        int.TryParse(line, out int number);
                        if (number > 0)
                        {
                            statistics.CalculateStatistics(number);
                        }
                        line = reader.ReadLine()!;
                    }
                }
            }
            return statistics;
        }
    }
}