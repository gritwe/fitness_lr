
using Microsoft.EntityFrameworkCore;
using WorkoutProgram;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<WorkoutProgramContext>(options =>
    options.UseNpgsql(
        "Host=localhost;Port=5432;Database=workout_program_db;Username=postgres;Password=2808;Include Error Detail=true"));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
