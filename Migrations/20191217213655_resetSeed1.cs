using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsHang.Migrations
{
    public partial class resetSeed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "Friend");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friend",
                table: "Friend",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Friend",
                columns: new[] { "Id", "FriendId", "RequestStatus", "UserId" },
                values: new object[,]
                {
                    { 1L, 2L, 2, 1L },
                    { 2L, 3L, 2, 1L },
                    { 3L, 4L, 2, 1L },
                    { 4L, 3L, 2, 2L },
                    { 5L, 3L, 2, 2L },
                    { 6L, 4L, 2, 3L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Friend",
                table: "Friend");

            migrationBuilder.DeleteData(
                table: "Friend",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Friend",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Friend",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Friend",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Friend",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Friend",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.RenameTable(
                name: "Friend",
                newName: "Friends");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");
        }
    }
}
