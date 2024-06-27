using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfOffice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class removePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Permission_PermissionId",
                table: "Role");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Role_PermissionId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "Role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PermissionId",
                table: "Role",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PermissionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Role_PermissionId",
                table: "Role",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Permission_PermissionId",
                table: "Role",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id");
        }
    }
}
