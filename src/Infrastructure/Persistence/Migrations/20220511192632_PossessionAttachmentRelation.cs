using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class PossessionAttachmentRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Possessions_Attachments_AttachmentId",
                table: "Possessions");

            migrationBuilder.DropIndex(
                name: "IX_Possessions_AttachmentId",
                table: "Possessions");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "Possessions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttachmentId",
                table: "Possessions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Possessions_AttachmentId",
                table: "Possessions",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Possessions_Attachments_AttachmentId",
                table: "Possessions",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id");
        }
    }
}
