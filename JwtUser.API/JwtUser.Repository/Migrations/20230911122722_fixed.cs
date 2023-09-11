using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtUser.Repository.Migrations
{
    /// <inheritdoc />
    public partial class @fixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppPersonels_ApplicationId",
                table: "AppPersonels",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_AppPersonels_PersonalId",
                table: "AppPersonels",
                column: "PersonalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPersonels_Applications_ApplicationId",
                table: "AppPersonels",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppPersonels_Personals_PersonalId",
                table: "AppPersonels",
                column: "PersonalId",
                principalTable: "Personals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPersonels_Applications_ApplicationId",
                table: "AppPersonels");

            migrationBuilder.DropForeignKey(
                name: "FK_AppPersonels_Personals_PersonalId",
                table: "AppPersonels");

            migrationBuilder.DropIndex(
                name: "IX_AppPersonels_ApplicationId",
                table: "AppPersonels");

            migrationBuilder.DropIndex(
                name: "IX_AppPersonels_PersonalId",
                table: "AppPersonels");
        }
    }
}
