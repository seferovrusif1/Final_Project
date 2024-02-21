using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.DAL.Migrations
{
    public partial class CreateSMCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialMediasCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialMediaId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediasCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMediasCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialMediasCompanies_SocialMedias_SocialMediaId",
                        column: x => x.SocialMediaId,
                        principalTable: "SocialMedias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediasCompanies_CompanyId",
                table: "SocialMediasCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediasCompanies_SocialMediaId",
                table: "SocialMediasCompanies",
                column: "SocialMediaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMediasCompanies");
        }
    }
}
