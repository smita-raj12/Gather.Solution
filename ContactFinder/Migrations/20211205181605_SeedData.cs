using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactFinder.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "CompanyName", "Department", "Email", "FirstName", "LastName", "Location" },
                values: new object[,]
                {
                    { 1, "Intel.com", "HR", "leena.mammoth@gmail.com", "Leena", "Mammoth", "US" },
                    { 2, "Infosys.com", "HR", "jerry.kej@gmail.com", "Jerry", "Kej", "IND" },
                    { 3, "Nike.com", "HR", "erik.debil@gmail.com", "Erik", "Debil", "US" },
                    { 4, "Synopys.com", "HR", "shiny.lee@gmail.com", "Shiny", "Lee", "UK" },
                    { 5, "Intel.com", "HR", "dev.addi@gmail.com", "Dev", "Addi", "Uk" },
                    { 7, "Jamasoftware.com", "HR", "mwigen@jamasoftware.com", "Madeline", "Wigen", "US" },
                    { 8, "Puppet.com", "HR", "claire.hernandez@puppet.com", "Claire", "Hernandez", "US" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 8);
        }
    }
}
