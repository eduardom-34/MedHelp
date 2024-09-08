using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedHelpApi.Migrations
{
    /// <inheritdoc />
    public partial class ModelsNamesAndPropertiesNamesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecialtyName",
                table: "Specialty",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SpecialtyDescription",
                table: "Specialty",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryDescription",
                table: "Category",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Specialty",
                newName: "SpecialtyName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Specialty",
                newName: "SpecialtyDescription");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Category",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Category",
                newName: "CategoryDescription");
        }
    }
}
