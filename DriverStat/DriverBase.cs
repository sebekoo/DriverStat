namespace DriverStat
{
    public abstract class DriverBase : IDriver
    {
        public DriverBase()
        {
        }

        protected DriverBase(string name, string surname, int idDriver)
        {
            Name = name;
            Surname = surname;
            IdDriver = idDriver;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int IdDriver { get; private set; }

        public abstract void AddGrade(string grade);
        public abstract void AddGrade(int grade);
        public abstract Statistics GetStatistics();
    }
}