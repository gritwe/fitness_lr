using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroserviceUser.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkoutProgramIdToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkoutProgramId",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutProgramId",
                table: "Users");
        }
    }
}
