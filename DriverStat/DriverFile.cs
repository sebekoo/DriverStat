namespace DriverStat
{
    public class DriverFile : DriverBase
    {
        private const string fileName = "driver.txt";

        //public static void FileExist()
        //{
        //    if (!File.Exists(fileName))
        //    {
        //        Console.WriteLine("File doesn't exist");
        //        File.Create(fileName);
        //    }

        //}
        public static void SaveToFile(List<int> grade)
        {
            using var writer = File.AppendText(fileName);
            if (File.Exists(fileName))
            {
                for (int i = 0; i < grade.Count; i++)
                {
                    writer.WriteLine(grade[i]);
                }
                Console.WriteLine("Grade saved");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            if (File.Exists(fileName))
            {
                using var reader = File.OpenText(fileName);
                var line = reader.ReadLine();
                while (line is not null)
                {
                    var number = -1;
                    int.TryParse(line, out number);
                    if (number > 0)
                    {
                        grades.Add(number);
                    }
                    line = reader.ReadLine();
                }
            }
            return statistics;
        }
    }
}