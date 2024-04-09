using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrickedUpBrickBuyer.Migrations
{
    /// <inheritdoc />
    public partial class FirstOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birth_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_of_residence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    age = table.Column<int>(type: "int", nullable: false),
                    recommendation1 = table.Column<int>(type: "int", nullable: false),
                    recommendation2 = table.Column<int>(type: "int", nullable: false),
                    recommendation3 = table.Column<int>(type: "int", nullable: false),
                    recommendation4 = table.Column<int>(type: "int", nullable: false),
                    recommendation5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_ID);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    line_item_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_ID = table.Column<int>(type: "int", nullable: false),
                    product_ID = table.Column<int>(type: "int", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.line_item_ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    transaction_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_ID = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    day_of_week = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    time = table.Column<int>(type: "int", nullable: false),
                    type_of_card = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    entry_mode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount = table.Column<int>(type: "int", nullable: false),
                    type_of_transaction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country_of_transaction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipping_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fraud = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.transaction_ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<int>(type: "int", nullable: false),
                    num_parts = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    img_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primary_color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    secondary_color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recommendation1 = table.Column<int>(type: "int", nullable: false),
                    recommendation2 = table.Column<int>(type: "int", nullable: false),
                    recommendation3 = table.Column<int>(type: "int", nullable: false),
                    recommendation4 = table.Column<int>(type: "int", nullable: false),
                    recommendation5 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_ID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_ID = table.Column<int>(type: "int", nullable: true),
                    admin_ID = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    access_level = table.Column<int>(type: "int", nullable: false),
                    salt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.customer_ID);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "Customers",
                        principalColumn: "Customer_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Customer_ID",
                table: "Accounts",
                column: "Customer_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
