namespace DriverStat
{
    public class Statistics
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public int Sum { get; private set; }
        public int Count { get; private set; }
        public float Avg 
        { 
            get 
            {  
                return Sum / Count; 
            } 
        }

        public Statistics()
        {
            Count = 0;
            Sum = 0;
            Max = int.MinValue;
            Min = int.MaxValue;
        }

        public void AddGrade(int grade)
        {
            Count++;
            Sum += grade;
            Min = Math.Min(grade, Min);
            Max = Math.Max(grade, Max);
        }
    }
}
