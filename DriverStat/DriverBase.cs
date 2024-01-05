namespace DriverStat
{
    public abstract class DriverBase : IDriver
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public abstract event GradeAddedDelegate GradeAdded;

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int IdDriver { get; private set; }

        public DriverBase(string name, string surname, int idDriver)
        {
            Name = name;
            Surname = surname;
            IdDriver = idDriver;
        }
        
        public void AddGrade(string grade)
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

        public abstract void AddGrade(int grade);
        public abstract Statistics GetStatistics();
    }
}