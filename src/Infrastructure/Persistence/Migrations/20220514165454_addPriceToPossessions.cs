using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class addPriceToPossessions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Mortgage",
                table: "Possessions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "Possessions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Rent",
                table: "Possessions",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mortgage",
                table: "Possessions");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Possessions");

            migrationBuilder.DropColumn(
                name: "Rent",
                table: "Possessions");
        }
    }
}
