using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsHang.Migrations.Event
{
    public partial class ResetDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventId");

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "EventId", "CreatedAt", "Creator", "Description", "EventLocation", "EventTime", "Title" },
                values: new object[,]
                {
                    { 1L, new DateTime(2019, 12, 17, 14, 55, 56, 519, DateTimeKind.Local).AddTicks(6750), "Flachman03", "Drink our faces off.", "The Pub on Penn", "Right Meow", "Hang at Pub" },
                    { 2L, new DateTime(2019, 12, 17, 14, 55, 56, 524, DateTimeKind.Local).AddTicks(9610), "Garrett03", "Watch tv and chill", "My House", "Later Tonight", "Hang out at Home" },
                    { 3L, new DateTime(2019, 12, 17, 14, 55, 56, 524, DateTimeKind.Local).AddTicks(9650), "Jacqui03", "Home Alone and Home Alone 2!", "Hollywood", "Tonight", "Watch christmas movies and get krunk" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "EventId",
                keyValue: 3L);

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventId");
        }
    }
}
