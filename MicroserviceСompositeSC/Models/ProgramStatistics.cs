namespace MicroserviceCompositeSC.Models
{
    public class ProgramStatistics
    {
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        public int UsersCount { get; set; }
        public double UsersPercentage { get; set; }
    }
}