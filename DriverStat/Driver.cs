namespace DriverStat
{
    public class Driver
    {
        private List<int> listStat = new();
        //public Driver(string name, string surname, int idDriver)
        //{
        //    Name = name;
        //    Surname = surname;
        //    IdDriver = idDriver;
        //}
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

        public void AddGrade(string grade)
        {

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
            var driverStats = GetStatistisc();
            Console.WriteLine("Min - ", driverStats.Min);
            Console.WriteLine("Max - ", driverStats.Max);
            Console.WriteLine("Avg - ", driverStats.Avg);

        }
    }
}
