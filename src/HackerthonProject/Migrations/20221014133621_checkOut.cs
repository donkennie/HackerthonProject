using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackerthonProject.Migrations
{
    public partial class checkOut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Advocates",
                columns: table => new
                {
                    AdvocateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Short_bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Long_bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profile_pic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Advocate_years_exp = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advocates", x => x.AdvocateId);
                    table.ForeignKey(
                        name: "FK_Advocates_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Github = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvocateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Advocates_AdvocateId",
                        column: x => x.AdvocateId,
                        principalTable: "Advocates",
                        principalColumn: "AdvocateId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advocates_CompanyId",
                table: "Advocates",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_AdvocateId",
                table: "Links",
                column: "AdvocateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Advocates");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
