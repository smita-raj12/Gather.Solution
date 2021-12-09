using Microsoft.EntityFrameworkCore.Migrations;

namespace Gather.Migrations
{
    public partial class addRoll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES (1,'Job','JOB')");
           migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES (2,'Seeker','SEEKER')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = 1");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = 2");
        }
    }
}
