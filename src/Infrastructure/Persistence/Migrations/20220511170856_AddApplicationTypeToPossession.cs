using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class AddApplicationTypeToPossession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PossessionAttachments_Attachment_AttachmentId",
                table: "PossessionAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Possessions_Attachment_AttachmentId",
                table: "Possessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment");

            migrationBuilder.RenameTable(
                name: "Attachment",
                newName: "Attachments");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationType",
                table: "Possessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PossessionAttachments_Attachments_AttachmentId",
                table: "PossessionAttachments",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Possessions_Attachments_AttachmentId",
                table: "Possessions",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PossessionAttachments_Attachments_AttachmentId",
                table: "PossessionAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Possessions_Attachments_AttachmentId",
                table: "Possessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attachments",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "ApplicationType",
                table: "Possessions");

            migrationBuilder.RenameTable(
                name: "Attachments",
                newName: "Attachment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attachment",
                table: "Attachment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PossessionAttachments_Attachment_AttachmentId",
                table: "PossessionAttachments",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Possessions_Attachment_AttachmentId",
                table: "Possessions",
                column: "AttachmentId",
                principalTable: "Attachment",
                principalColumn: "Id");
        }
    }
}
