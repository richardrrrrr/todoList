using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace todoList.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    PrimaryKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.PrimaryKey);
                });

            migrationBuilder.CreateTable(
                name: "Todolists ",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Complete_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todolists ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todolists _Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "PrimaryKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "PrimaryKey", "Id", "Name", "Password", "Role", "Status" },
                values: new object[,]
                {
                    { 1, "user001", "User One", "password001", 1, "V" },
                    { 2, "user002", "User Two", "password002", 2, "V" },
                    { 3, "user003", "User Three", "password003", 1, "X" }
                });

            migrationBuilder.InsertData(
                table: "Todolists ",
                columns: new[] { "Id", "AccountId", "Complete_at", "Created_at", "IsComplete", "Name", "Priority" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Task 1 for User One", 1 },
                    { 2, 1, null, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Task 2 for User One", 2 },
                    { 3, 2, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Task 1 for User Two", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todolists _AccountId",
                table: "Todolists ",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todolists ");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
