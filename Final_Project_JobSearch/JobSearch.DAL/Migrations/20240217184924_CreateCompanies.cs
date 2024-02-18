using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobSearch.DAL.Migrations
{
    public partial class CreateCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_AspNetUsers_UserId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Email_EmailId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_Company_Phone_PhoneId",
                table: "Company");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Company_UserId",
                table: "Companies",
                newName: "IX_Companies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_PhoneId",
                table: "Companies",
                newName: "IX_Companies_PhoneId");

            migrationBuilder.RenameIndex(
                name: "IX_Company_EmailId",
                table: "Companies",
                newName: "IX_Companies_EmailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_AspNetUsers_UserId",
                table: "Companies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Email_EmailId",
                table: "Companies",
                column: "EmailId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Phone_PhoneId",
                table: "Companies",
                column: "PhoneId",
                principalTable: "Phone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_AspNetUsers_UserId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Email_EmailId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Phone_PhoneId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_UserId",
                table: "Company",
                newName: "IX_Company_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_PhoneId",
                table: "Company",
                newName: "IX_Company_PhoneId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_EmailId",
                table: "Company",
                newName: "IX_Company_EmailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_AspNetUsers_UserId",
                table: "Company",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Email_EmailId",
                table: "Company",
                column: "EmailId",
                principalTable: "Email",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Phone_PhoneId",
                table: "Company",
                column: "PhoneId",
                principalTable: "Phone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
