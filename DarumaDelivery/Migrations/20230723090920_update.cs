using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DarumaDelivery.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_Customer_CustomerID1",
                table: "Register");

            migrationBuilder.DropIndex(
                name: "IX_Register_CustomerID1",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "CustomerID1",
                table: "Register");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Product",
                newName: "ProductTitle");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerID",
                table: "Register",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    ProductGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductGroupTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductGroupDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.ProductGroupID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Register_CustomerID",
                table: "Register",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Customer_CustomerID",
                table: "Register",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Register_Customer_CustomerID",
                table: "Register");

            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_Register_CustomerID",
                table: "Register");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "ProductTitle",
                table: "Product",
                newName: "CustomerID");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerID",
                table: "Register",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID1",
                table: "Register",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Register_CustomerID1",
                table: "Register",
                column: "CustomerID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Register_Customer_CustomerID1",
                table: "Register",
                column: "CustomerID1",
                principalTable: "Customer",
                principalColumn: "CustomerID");
        }
    }
}
