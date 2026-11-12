using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using MicroserviceCompositeSC.Models;
using MicroserviceCompositeSC.Services;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void FilterUsersByProgram()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    WorkoutProgramId = 1
                },
                new User
                {
                    Id = 2,
                    WorkoutProgramId = 2
                },
                new User
                {
                    Id = 3,
                    WorkoutProgramId = 1
                },
                new User
                {
                    Id = 4,
                    WorkoutProgramId = 3
                }
            };

            var service = new CompositeQueryService();

            var result = service.FilterUsersByProgram(users, 1);

            Assert.That(result, Has.Count.EqualTo(2));

            Assert.That(
                result.Select(user => user.Id),
                Is.EquivalentTo(new[] { 1, 3 })
            );
        }

        [Test]
        public void FilterProgramsByStatus()
        {
            var programs = new List<WorkoutProgram>
            {
                new WorkoutProgram
                {
                    Id = 1,
                    Status = "Active"
                },
                new WorkoutProgram
                {
                    Id = 2,
                    Status = "Inactive"
                },
                new WorkoutProgram
                {
                    Id = 3,
                    Status = "ACTIVE"
                },
                new WorkoutProgram
                {
                    Id = 4,
                    Status = "Completed"
                }
            };

            var service = new CompositeQueryService();

            var result = service.FilterProgramsByStatus(programs, "Active");

            Assert.That(result, Has.Count.EqualTo(2));

            Assert.That(
                result.Select(program => program.Id),
                Is.EquivalentTo(new[] { 1, 3 })
            );
        }

        [Test]
        public void CountUsersByProgram()
        {
            var users = new List<User>
            {
                new User
                {
                    Id = 1,
                    WorkoutProgramId = 1
                },
                new User
                {
                    Id = 2,
                    WorkoutProgramId = 2
                },
                new User
                {
                    Id = 3,
                    WorkoutProgramId = 1
                },
                new User
                {
                    Id = 4,
                    WorkoutProgramId = 3
                }
            };

            var service = new CompositeQueryService();

            int result = service.CountUsersByProgram(users, 1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void CalculateUsersPercentage()
        {
            var users = new List<User>
            {
                new User { Id = 1, WorkoutProgramId = 1 },
                new User { Id = 2, WorkoutProgramId = 2 },
                new User { Id = 3, WorkoutProgramId = 1 },
                new User { Id = 4, WorkoutProgramId = 3 },
                new User { Id = 5, WorkoutProgramId = 1 },
                new User { Id = 6, WorkoutProgramId = 2 },
                new User { Id = 7, WorkoutProgramId = 3 },
                new User { Id = 8, WorkoutProgramId = 2 },
                new User { Id = 9, WorkoutProgramId = 3 },
                new User { Id = 10, WorkoutProgramId = 2 }
            };

            var service = new CompositeQueryService();

            double result = service.CalculateUsersPercentage(users, 1);

            Assert.That(result, Is.EqualTo(30.0));
        }

        [Test]
        public void CreateProgramStatistics()
        {
            var program = new WorkoutProgram
            {
                Id = 1,
                Name = "Силовая программа"
            };

            var users = new List<User>
            {
                new User { Id = 1, WorkoutProgramId = 1 },
                new User { Id = 2, WorkoutProgramId = 2 },
                new User { Id = 3, WorkoutProgramId = 1 },
                new User { Id = 4, WorkoutProgramId = 3 },
                new User { Id = 5, WorkoutProgramId = 1 },
                new User { Id = 6, WorkoutProgramId = 2 },
                new User { Id = 7, WorkoutProgramId = 3 },
                new User { Id = 8, WorkoutProgramId = 2 },
                new User { Id = 9, WorkoutProgramId = 3 },
                new User { Id = 10, WorkoutProgramId = 2 }
            };

            var service = new CompositeQueryService();

            var result = service.CreateProgramStatistics(program, users);

            Assert.That(result.ProgramId, Is.EqualTo(1));
            Assert.That(result.ProgramName, Is.EqualTo("Силовая программа"));
            Assert.That(result.UsersCount, Is.EqualTo(3));
            Assert.That(result.UsersPercentage, Is.EqualTo(30.0));
        }
    }
}