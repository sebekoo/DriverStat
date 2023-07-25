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
                    var number = -1;
                    int.TryParse(line, out number);
                    if (number > 0)
                    {
                        grades.Add(number);
                    }
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
                for (int i = 0; i < grade.Count; i++)
                {
                    writer.WriteLine(grade[i]);
                }
                Console.WriteLine("Grade saved");
            }
        }
    }
}