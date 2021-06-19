using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectThomas.Data.Migrations
{
    public partial class AddedReadItToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReadIt",
                table: "Book",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReadIt",
                table: "Book");
        }
    }
}
