using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corbet.Persistence.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddCarts_Products_ProductId",
                table: "AddCarts");

            migrationBuilder.DropIndex(
                name: "IX_AddCarts_ProductId",
                table: "AddCarts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "AddCarts",
                newName: "StockingId");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "AddCarts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 9, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6795));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 8, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 3, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6771));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 7, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6827));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 3, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 5, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6909));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6887));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 30, 15, 39, 19, 929, DateTimeKind.Utc).AddTicks(6978));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockingId",
                table: "AddCarts",
                newName: "ProductId");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "AddCarts",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 9, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 8, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 3, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9849));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 7, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9889));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 3, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 5, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9943));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9928));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 28, 9, 13, 17, 774, DateTimeKind.Utc).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9972));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 28, 9, 13, 17, 773, DateTimeKind.Utc).AddTicks(9989));

            migrationBuilder.CreateIndex(
                name: "IX_AddCarts_ProductId",
                table: "AddCarts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddCarts_Products_ProductId",
                table: "AddCarts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
