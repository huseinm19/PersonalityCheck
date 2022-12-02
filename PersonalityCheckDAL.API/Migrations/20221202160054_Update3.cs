using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalityCheckDAL.API.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfAnsweredQuestions",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Retaken",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "ResultPercentage");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ResultPercentage",
                table: "Users",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfAnsweredQuestions",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Retaken",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
