using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JwtUser.Repository.Migrations
{
    /// <inheritdoc />
    public partial class transport_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "packageCount",
                table: "Transports",
                newName: "smallitemCount");

            migrationBuilder.RenameColumn(
                name: "itemCount",
                table: "Transports",
                newName: "miditemCount");

            migrationBuilder.AddColumn<int>(
                name: "bigitemCount",
                table: "Transports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bigitemCount",
                table: "Transports");

            migrationBuilder.RenameColumn(
                name: "smallitemCount",
                table: "Transports",
                newName: "packageCount");

            migrationBuilder.RenameColumn(
                name: "miditemCount",
                table: "Transports",
                newName: "itemCount");
        }
    }
}
