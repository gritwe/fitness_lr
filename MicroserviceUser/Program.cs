
using Microsoft.EntityFrameworkCore;

namespace MicroserviceUser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("UserContext") ?? throw new InvalidOperationException("Connection string 'UserContext' not found.");

            builder.Services.AddControllers();


            builder.Services.AddDbContext<UserContext>(options =>
                options.UseNpgsql(
                    "Host=localhost;Port=5432;Database=UserDB;Username=postgres;Password=2808"));

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
