using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corbet.Persistence.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderManagements");

            migrationBuilder.CreateTable(
                name: "AddCarts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddCarts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_AddCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 9, 24, 7, 20, 12, 916, DateTimeKind.Utc).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 8, 24, 7, 20, 12, 915, DateTimeKind.Utc).AddTicks(9969));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 3, 24, 7, 20, 12, 916, DateTimeKind.Utc).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 7, 24, 7, 20, 12, 916, DateTimeKind.Utc).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 3, 24, 7, 20, 12, 916, DateTimeKind.Utc).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 5, 24, 7, 20, 12, 915, DateTimeKind.Utc).AddTicks(9912));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 24, 7, 20, 12, 916, DateTimeKind.Utc).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 24, 7, 20, 12, 916, DateTimeKind.Utc).AddTicks(267));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 24, 7, 20, 12, 916, DateTimeKind.Utc).AddTicks(199));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 24, 7, 20, 12, 916, DateTimeKind.Utc).AddTicks(232));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 24, 7, 20, 12, 916, DateTimeKind.Utc).AddTicks(407));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 24, 7, 20, 12, 916, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 24, 7, 20, 12, 916, DateTimeKind.Utc).AddTicks(374));

            migrationBuilder.CreateIndex(
                name: "IX_AddCarts_ProductId",
                table: "AddCarts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddCarts");

            migrationBuilder.CreateTable(
                name: "OrderManagements",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MailThumb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POThumb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderManagements", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderManagements_Products_OrderProductId",
                        column: x => x.OrderProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 9, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 8, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9566));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 3, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9615));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 7, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 3, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9591));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 5, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9699));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9794));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 13, 15, 52, 684, DateTimeKind.Utc).AddTicks(9821));

            migrationBuilder.CreateIndex(
                name: "IX_OrderManagements_OrderProductId",
                table: "OrderManagements",
                column: "OrderProductId");
        }
    }
}
