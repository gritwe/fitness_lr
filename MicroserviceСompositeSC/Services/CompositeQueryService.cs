using MicroserviceCompositeSC.Models;

namespace MicroserviceCompositeSC.Services
{
    public class CompositeQueryService
    {
        public List<User> FilterUsersByProgram(
            List<User> users,
            int programId)
        {
            return users.FindAll(user => user.WorkoutProgramId == programId);
        }

        public List<WorkoutProgram> FilterProgramsByStatus(
            List<WorkoutProgram> programs,
            string status)
        {
            return programs.FindAll(program => string.Equals(program.Status, status, StringComparison.OrdinalIgnoreCase));
        }

        public int CountUsersByProgram(
            List<User> users,
            int programId)
        {
            return users.Count(user => user.WorkoutProgramId == programId);
        }


        public double CalculateUsersPercentage(
            List<User> users,
            int programId)
        {
            if (users.Count == 0)
            {
                return 0;
            }

            return (double)CountUsersByProgram(users, programId)
                   / users.Count * 100;
        }


        public ProgramStatistics CreateProgramStatistics(
            WorkoutProgram program,
            List<User> users)
        {
            return new ProgramStatistics
            {
                ProgramId = program.Id,
                ProgramName = program.Name,
                UsersCount = CountUsersByProgram(users, program.Id),
                UsersPercentage = CalculateUsersPercentage(users, program.Id)
            };
        }

    }
}
