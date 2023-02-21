using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessments.Data.Migrations
{
    public partial class AddScientificNameToFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScientificName",
                table: "Feedbacks",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.Sql("UPDATE Feedbacks SET ScientificName = ''");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScientificName",
                table: "Feedbacks");
        }
    }
}
