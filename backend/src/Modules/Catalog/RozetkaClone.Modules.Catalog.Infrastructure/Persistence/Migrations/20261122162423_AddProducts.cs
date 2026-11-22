using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RozetkaClone.Modules.Catalog.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Brand",
                schema: "catalog",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                schema: "catalog",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                schema: "catalog",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "catalog",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "catalog",
                table: "Products",
                column: "BrandId",
                principalSchema: "catalog",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Sku",
                schema: "catalog",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "catalog",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                schema: "catalog",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                schema: "catalog",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                schema: "catalog",
                table: "Products",
                column: "BrandId",
                principalSchema: "catalog",
                principalTable: "Brands",
                principalColumn: "Id");
        }
    }
}
