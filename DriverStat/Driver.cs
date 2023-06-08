using System.Data;

namespace DriverStat
{
    public class Driver : IDriver
    {
        public List<int> listStat = new();
        
        public Driver(string name, string surname, int idDriver)
        {
            Name = name;
            Surname = surname;
            IdDriver = idDriver;
        }

        public Driver()
        {

        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdDriver { get; set; }
        public int PunktyKarne { get; set; }

        public int Result
        {
            get
            {
                return listStat.Sum();
            }
        }

        public int DlListy()
        {
            var a = listStat.Count;
            return a;
        }
        public void AddGrade(string grade)
        {
            if(grade.Length > 2)
            {
                Console.WriteLine("Max rating is 99");
            }
            else if (int.TryParse(grade, out int result))
            {
                AddGrade(result);
            }
            else
            {
                Console.WriteLine("You must enter the rating in numerical form");
            }
        }

        public void AddGrade(int grade)
        {
            listStat.Add(grade);
        }
        public Statistisc GetStatistisc()
        {
            var statistisc = new Statistisc();
            statistisc.Avg = 0;
            statistisc.Max = int.MinValue;
            statistisc.Min = int.MaxValue;

            foreach
                (var item in listStat)
            {
                statistisc.Max = Math.Max(statistisc.Max, item);
                statistisc.Min = Math.Min(statistisc.Min, item);
                statistisc.Avg += item;
            }
            statistisc.Avg /= listStat.Count;

            return statistisc;
        }

        public void PrintStatistics()
        {
            if (Name == null)
            {
                Console.WriteLine("Please first create driver and grade ");
                Console.WriteLine();
                return;
            }

            if (listStat.Count == 0)
            {
                Console.WriteLine("Driver is not grade. Please grade Driver");
                Console.WriteLine();
                return;
            }
            var driverStats = GetStatistisc();
            Console.WriteLine("Min - ", driverStats.Min);
            Console.WriteLine("Max - ", driverStats.Max);
            Console.WriteLine("Avg - ", driverStats.Avg);

        }
    }
}
