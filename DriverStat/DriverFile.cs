namespace DriverStat
{
    public class DriverFile : DriverBase
    {
        private const string fileName = "driver.txt";

        public override event GradeAddedDelegate GradeAdded;

        //public void SaveToFile(List<int> grade)
        //{
        //    using var writer = File.AppendText(fileName);
        //    if (File.Exists(fileName))
        //    {
        //        for (int i = 0; i < grade.Count; i++)
        //        {
        //            writer.WriteLine(grade[i]);
        //        }
        //        Console.WriteLine("Grade saved");
        //    }
        //}

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            var grades = new List<int>();
            if (File.Exists(fileName))
            {
                using var reader = File.OpenText(fileName);
                {
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
            }
            return statistics;
        }

        public override void AddGrade(string grade)
        {
            if (int.TryParse(grade, out int result))
            {
                AddGrade(result);
            }
            else
            {
                Console.WriteLine("String is not int");
            }
        }

        public override void AddGrade(int grade)
        {
            if (grade > 0)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(grade);
                }
            }
            else
            {
                throw new Exception("Incorrect value");
            }
        }
    }
}