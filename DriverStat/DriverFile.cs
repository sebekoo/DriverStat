namespace DriverStat
{
    public static class DriverFile
    {
        private const string fileName = "driver.txt";

        public static List<int> ReadGradesFromFile()
        {
            var grades = new List<int>();
            if (File.Exists($"{fileName}"))
            {
                using var reader = File.OpenText(fileName);
                var line = reader.ReadLine();
                while (line != null)
                {
                    var nember = int.Parse(line);
                    grades.Add(nember);
                    line = reader.ReadLine();
                }
            }
            return grades;
        }

        public static void SaveToFile(List<int> grade)
        {
            using var writer = File.AppendText(fileName);
            if (File.Exists(fileName))
            {
                writer.WriteLine(grade);
                Console.WriteLine("Add grade");
            }
        }
    }
}