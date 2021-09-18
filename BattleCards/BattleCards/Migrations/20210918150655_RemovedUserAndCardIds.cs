using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleCards.Migrations
{
    public partial class RemovedUserAndCardIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Cards");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
