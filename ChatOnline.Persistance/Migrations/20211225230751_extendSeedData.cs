using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatOnline.Persistance.Migrations
{
    public partial class extendSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "Id", "Content", "Created", "CreatedBy", "Date", "FriendId", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId", "UserId" },
                values: new object[] { 1, "Hi, what's up?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 12, 26, 0, 7, 50, 563, DateTimeKind.Local).AddTicks(7950), 2, null, null, null, null, 0, 1 });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "Id", "Content", "Created", "CreatedBy", "Date", "FriendId", "Inactivated", "InactivatedBy", "Modified", "ModifiedBy", "StatusId", "UserId" },
                values: new object[] { 2, "I'm fine! And you?", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 12, 27, 0, 7, 50, 566, DateTimeKind.Local).AddTicks(7244), 1, null, null, null, null, 0, 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[] { 4, "Adam", "Malisz" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Message",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
