using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackerthonProject.Migrations
{
    public partial class initialCreateError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advocates_Links_LinkId",
                table: "Advocates");

            migrationBuilder.DropIndex(
                name: "IX_Advocates_LinkId",
                table: "Advocates");

            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "Advocates");

            migrationBuilder.AddColumn<int>(
                name: "AdvocateId",
                table: "Links",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Links_AdvocateId",
                table: "Links",
                column: "AdvocateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Advocates_AdvocateId",
                table: "Links",
                column: "AdvocateId",
                principalTable: "Advocates",
                principalColumn: "AdvocateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Advocates_AdvocateId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_AdvocateId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "AdvocateId",
                table: "Links");

            migrationBuilder.AddColumn<int>(
                name: "LinkId",
                table: "Advocates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Advocates_LinkId",
                table: "Advocates",
                column: "LinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advocates_Links_LinkId",
                table: "Advocates",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "LinkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
