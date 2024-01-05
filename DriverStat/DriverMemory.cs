namespace DriverStat
{
    public class DriverMemory : DriverBase
    {
        public new delegate void GradeAddedDelegate(object sender, EventArgs args);

        public override event DriverBase.GradeAddedDelegate GradeAdded;

        private List<int> grades = new();


        public DriverMemory(string name, string surname, int idDriver)
            : base(name, surname, idDriver)
        {
        }

        public int Result
        {
            get
            {
                return grades.Sum();
            }
        }

        public int Avg
        {
            get
            {
                return (int)grades.Average();
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
                grades.Add(grade);
                
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in grades)
            {
                statistics.CalculateStatistics(grade);
            }
            return statistics;
        }
    }
}