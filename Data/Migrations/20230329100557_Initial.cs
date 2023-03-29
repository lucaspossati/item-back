using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemcode = table.Column<string>(name: "item_code", type: "nvarchar(25)", maxLength: 25, nullable: false),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    customerdescription = table.Column<string>(name: "customer_description", type: "nvarchar(300)", maxLength: 300, nullable: true),
                    salesitem = table.Column<bool>(name: "sales_item", type: "bit", nullable: false),
                    stockitem = table.Column<bool>(name: "stock_item", type: "bit", nullable: false),
                    purchaseditem = table.Column<bool>(name: "purchased_item", type: "bit", nullable: false),
                    barcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    manageitemby = table.Column<int>(name: "manage_item_by", type: "int", nullable: false),
                    minimuminventory = table.Column<decimal>(name: "minimum_inventory", type: "decimal(18,2)", nullable: false),
                    maximuminventory = table.Column<decimal>(name: "maximum_inventory", type: "decimal(18,2)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    imagepath = table.Column<string>(name: "image_path", type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemcode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
