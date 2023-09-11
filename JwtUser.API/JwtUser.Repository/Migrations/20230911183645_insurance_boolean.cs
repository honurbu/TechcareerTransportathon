using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtUser.Repository.Migrations
{
    /// <inheritdoc />
    public partial class insurance_boolean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Insurances");

            migrationBuilder.AddColumn<bool>(
                name: "isWant",
                table: "Insurances",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isWant",
                table: "Insurances");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
