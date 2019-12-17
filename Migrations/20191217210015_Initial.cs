using Microsoft.EntityFrameworkCore.Migrations;

namespace LetsHang.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "ApiKey", "Email", "Name", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1L, "A93reRTUJHsCuQSHRAL3GxqOJyDmQpCgps102ciuabcA", "user@email.com", "Ryan Flachman", "password", "1111111111", "Flachman03" },
                    { 2L, "B93reRTUJHsCuQSHRCL3GxqOJyDmQpCgps102ciuabc", "user1@email.com", "Garrett Flachman", "password", "2222222222", "Garrett03" },
                    { 3L, "C93reRTUJHsCuQSHRXL3GxqOJyDmQpCgps102ciuabc", "user2@email.com", "Jacqui Long", "password", "3333333333", "Jacqui03" },
                    { 4L, "D93reRTUJHsCuQSHRXL3GxqOJyDmQpCgps102ciuabc", "user3@email.com", "Steve Rumizen", "password", "5555555555", "Steve03" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 4L);

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");
        }
    }
}
