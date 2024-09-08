using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedHelpApi.Migrations
{
    /// <inheritdoc />
    public partial class CategoryIDMissingFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_Category_CategoriesID",
                table: "Specialty");

            migrationBuilder.RenameColumn(
                name: "CategoriesID",
                table: "Specialty",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Specialty_CategoriesID",
                table: "Specialty",
                newName: "IX_Specialty_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_Category_CategoryID",
                table: "Specialty",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_Category_CategoryID",
                table: "Specialty");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Specialty",
                newName: "CategoriesID");

            migrationBuilder.RenameIndex(
                name: "IX_Specialty_CategoryID",
                table: "Specialty",
                newName: "IX_Specialty_CategoriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_Category_CategoriesID",
                table: "Specialty",
                column: "CategoriesID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
