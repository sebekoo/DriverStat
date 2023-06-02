namespace DriverStat
{
    public class Driver
    {
        private List<int> listStat = new();
        public Driver(string name, string surname, int idDriver)
        {
            Name = name;
            Surname = surname;
            IdDriver = idDriver;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int IdDriver { get; private set; }

        public int Result
        {
            get
            {
                return listStat.Sum();
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
    }
}
