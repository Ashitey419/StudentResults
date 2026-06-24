public class Student
{
    public string FullName { get; set; }
    public string StudentId { get; set; }
    public string Programme { get; set; }
    public string Level { get; set; }

    public int[] Scores { get; set; } = new int[5];

    public int TotalScore { get; set; }
    public double AverageScore { get; set; }
    public string Grade { get; set; }
    public string Status { get; set; }
}