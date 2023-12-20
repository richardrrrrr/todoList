using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoList.Migrations
{
    /// <inheritdoc />
    public partial class version1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todolists _Accounts_AccountId",
                table: "Todolists ");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Todolists ",
                newName: "Account_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Todolists _AccountId",
                table: "Todolists ",
                newName: "IX_Todolists _Account_ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Accounts",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "PrimaryKey",
                table: "Accounts",
                newName: "Account_ID");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Account_ID",
                keyValue: 1,
                columns: new[] { "Password", "UserName" },
                values: new object[] { "password1", "user1" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Account_ID",
                keyValue: 2,
                columns: new[] { "Password", "UserName" },
                values: new object[] { "password2", "user2" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Account_ID",
                keyValue: 3,
                columns: new[] { "Password", "Role", "UserName" },
                values: new object[] { "password3", 2, "user3" });

            migrationBuilder.UpdateData(
                table: "Todolists ",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "TodoItem1");

            migrationBuilder.UpdateData(
                table: "Todolists ",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Complete_at", "IsComplete", "Name" },
                values: new object[] { new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "TodoItem2" });

            migrationBuilder.UpdateData(
                table: "Todolists ",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Complete_at", "Created_at", "IsComplete", "Name", "Priority" },
                values: new object[] { null, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "TodoItem3", 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_Todolists _Accounts_Account_ID",
                table: "Todolists ",
                column: "Account_ID",
                principalTable: "Accounts",
                principalColumn: "Account_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todolists _Accounts_Account_ID",
                table: "Todolists ");

            migrationBuilder.RenameColumn(
                name: "Account_ID",
                table: "Todolists ",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Todolists _Account_ID",
                table: "Todolists ",
                newName: "IX_Todolists _AccountId");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Accounts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Account_ID",
                table: "Accounts",
                newName: "PrimaryKey");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Accounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "PrimaryKey",
                keyValue: 1,
                columns: new[] { "Id", "Name", "Password", "Status" },
                values: new object[] { "user001", "User One", "password001", "V" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "PrimaryKey",
                keyValue: 2,
                columns: new[] { "Id", "Name", "Password", "Status" },
                values: new object[] { "user002", "User Two", "password002", "V" });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "PrimaryKey",
                keyValue: 3,
                columns: new[] { "Id", "Name", "Password", "Role", "Status" },
                values: new object[] { "user003", "User Three", "password003", 1, "X" });

            migrationBuilder.UpdateData(
                table: "Todolists ",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Task 1 for User One");

            migrationBuilder.UpdateData(
                table: "Todolists ",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Complete_at", "IsComplete", "Name" },
                values: new object[] { null, false, "Task 2 for User One" });

            migrationBuilder.UpdateData(
                table: "Todolists ",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Complete_at", "Created_at", "IsComplete", "Name", "Priority" },
                values: new object[] { new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Task 1 for User Two", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Todolists _Accounts_AccountId",
                table: "Todolists ",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "PrimaryKey",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
