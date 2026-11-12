
namespace MicroserviceUser.Models
{
    public class User
    {
        public long Id { get; set; }
        public int WorkoutProgramId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
