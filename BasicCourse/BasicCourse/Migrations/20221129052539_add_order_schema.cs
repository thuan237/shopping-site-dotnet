using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicCourse.Migrations
{
    /// <inheritdoc />
    public partial class addorderschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    orderid = table.Column<Guid>(name: "order_id", type: "uniqueidentifier", nullable: false),
                    orderdate = table.Column<DateTime>(name: "order_date", type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    deliverydate = table.Column<DateTime>(name: "delivery_date", type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    receiver = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    deliveryaddress = table.Column<string>(name: "delivery_address", type: "nvarchar(max)", nullable: false),
                    phonenumber = table.Column<string>(name: "phone_number", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.orderid);
                });

            migrationBuilder.CreateTable(
                name: "order_details",
                columns: table => new
                {
                    productid = table.Column<Guid>(name: "product_id", type: "uniqueidentifier", nullable: false),
                    orderid = table.Column<Guid>(name: "order_id", type: "uniqueidentifier", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    totalmoney = table.Column<double>(name: "total_money", type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_details", x => new { x.productid, x.orderid });
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order",
                        column: x => x.orderid,
                        principalTable: "order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_details_order_id",
                table: "order_details",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_details");

            migrationBuilder.DropTable(
                name: "order");
        }
    }
}
