using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectThomas.Data.Migrations
{
    public partial class AddedPending : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Pending",
                table: "Book",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pending",
                table: "Book");
        }
    }
}
