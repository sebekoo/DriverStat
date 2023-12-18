namespace DriverStat
{
    public class DriverMemory : DriverBase
    {

        private List<int> grades = new();

        public override event GradeAddedDelegate GradeAdded;

        public DriverMemory()
            : base()
        {
        }
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

        public int GradeContains()
        {
            return grades.Count;
        }

        public override void AddGrade(string grade)
        {
            if (int.TryParse(grade, out int result))
            {
                AddGrade(result);

                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("You must enter the rating in numerical form \n");
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