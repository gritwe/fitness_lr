namespace WorkoutProgram.Models
{
    public class WorkoutProgram
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Goal { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkoutsPerWeek { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}