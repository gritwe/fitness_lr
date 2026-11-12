
using Microsoft.EntityFrameworkCore;
using WorkoutProgram.Models;

namespace WorkoutProgram
{
    public class WorkoutProgramContext : DbContext
    {
        public WorkoutProgramContext(
            DbContextOptions<WorkoutProgramContext> options)
            : base(options)
        {
        }

        public DbSet<WorkoutProgram.Models.WorkoutProgram> WorkoutPrograms
        { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutProgram.Models.WorkoutProgram>(entity =>
            {
                entity
                    .ToTable("workout_programs")
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name");

                entity.Property(e => e.Goal)
                    .HasColumnName("goal");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("timestamp without time zone");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("timestamp without time zone");

                entity.Property(e => e.WorkoutsPerWeek)
                    .HasColumnName("workouts_per_week");

                entity.Property(e => e.Status)
                    .HasColumnName("status");
            });
        }
    }
}
