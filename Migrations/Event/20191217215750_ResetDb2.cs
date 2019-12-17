using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsHang.Migrations.Event
{
    public partial class ResetDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Invites",
                table: "Invites");

            migrationBuilder.RenameTable(
                name: "Invites",
                newName: "Invited");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invited",
                table: "Invited",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 17, 14, 57, 49, 653, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 17, 14, 57, 49, 658, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 17, 14, 57, 49, 658, DateTimeKind.Local).AddTicks(9210));

            migrationBuilder.InsertData(
                table: "Invited",
                columns: new[] { "Id", "EventId", "FriendId", "InviteStatus", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, 2L, 1, 1L },
                    { 2L, 1L, 3L, 1, 1L },
                    { 3L, 1L, 4L, 2, 1L },
                    { 4L, 2L, 1L, 1, 2L },
                    { 5L, 3L, 1L, 1, 3L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Invited",
                table: "Invited");

            migrationBuilder.DeleteData(
                table: "Invited",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Invited",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Invited",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Invited",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Invited",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.RenameTable(
                name: "Invited",
                newName: "Invites");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invites",
                table: "Invites",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 17, 14, 55, 56, 519, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 17, 14, 55, 56, 524, DateTimeKind.Local).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2019, 12, 17, 14, 55, 56, 524, DateTimeKind.Local).AddTicks(9650));
        }
    }
}
