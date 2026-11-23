using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RozetkaClone.Modules.Catalog.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCatalogSitemapFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                schema: "catalog",
                table: "Categories");

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                schema: "catalog",
                table: "Products",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                schema: "catalog",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                schema: "catalog",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                schema: "catalog",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewsCount",
                schema: "catalog",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalesCount",
                schema: "catalog",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "catalog",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                schema: "catalog",
                table: "Categories",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                schema: "catalog",
                table: "Categories",
                column: "ParentCategoryId",
                principalSchema: "catalog",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                schema: "catalog",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameEn",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReviewsCount",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalesCount",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameEn",
                schema: "catalog",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "catalog",
                table: "Categories",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                schema: "catalog",
                table: "Categories",
                column: "ParentCategoryId",
                principalSchema: "catalog",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
