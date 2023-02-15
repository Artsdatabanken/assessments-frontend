using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessments.Data.Migrations
{
    public partial class AddLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logged = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Exception = table.Column<string>(type: "nvarchar(max)", maxLength: 8192, nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Action = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Method = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    QueryString = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Referrer = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Hostname = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Environment = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");
        }
    }
}
