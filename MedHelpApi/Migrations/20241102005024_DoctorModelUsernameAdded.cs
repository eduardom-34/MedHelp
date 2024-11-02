using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedHelpApi.Migrations
{
    /// <inheritdoc />
    public partial class DoctorModelUsernameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Doctors");
        }
    }
}
