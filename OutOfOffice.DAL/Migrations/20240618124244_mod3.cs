using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfOffice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mod3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequest_Employees_ApproverId",
                table: "ApprovalRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequest_LeaveRequest_LeaveRequestId",
                table: "ApprovalRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequest_RequestStatuses_RequestStatusId",
                table: "ApprovalRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AppUsers_Id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Project_ProjectId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_AbsenceReason_AbsenceReasonId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_Employees_EmployeeId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_RequestStatuses_RequestStatusId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Employees_ProjectManagerId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectStatuses_ProjectStatusId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectType_ProjectTypeId",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveRequest",
                table: "LeaveRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApprovalRequest",
                table: "ApprovalRequest");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalRequest_ApproverId",
                table: "ApprovalRequest");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalRequest_LeaveRequestId",
                table: "ApprovalRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbsenceReason",
                table: "AbsenceReason");

            migrationBuilder.RenameTable(
                name: "ProjectType",
                newName: "ProjectTypes");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "LeaveRequest",
                newName: "LeaveRequests");

            migrationBuilder.RenameTable(
                name: "ApprovalRequest",
                newName: "ApprovalRequests");

            migrationBuilder.RenameTable(
                name: "AbsenceReason",
                newName: "AbsenceReasons");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ProjectTypeId",
                table: "Projects",
                newName: "IX_Projects_ProjectTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ProjectStatusId",
                table: "Projects",
                newName: "IX_Projects_ProjectStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ProjectManagerId",
                table: "Projects",
                newName: "IX_Projects_ProjectManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequest_RequestStatusId",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_RequestStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequest_EmployeeId",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequest_AbsenceReasonId",
                table: "LeaveRequests",
                newName: "IX_LeaveRequests_AbsenceReasonId");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalRequest_RequestStatusId",
                table: "ApprovalRequests",
                newName: "IX_ApprovalRequests_RequestStatusId");

            migrationBuilder.AddColumn<Guid>(
                name: "PermissionId",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RequestStatusName",
                table: "RequestStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "RequestStatuses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectStatusName",
                table: "ProjectStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProjectStatuses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectManagerId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectTypeName",
                table: "ProjectTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProjectTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "LeaveRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ApprovalRequests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "AbsenceReasonName",
                table: "AbsenceReasons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AbsenceReasons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTypes",
                table: "ProjectTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveRequests",
                table: "LeaveRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalRequests",
                table: "ApprovalRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbsenceReasons",
                table: "AbsenceReasons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_PermissionId",
                table: "Roles",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AppUserId",
                table: "Employees",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectManagerId",
                table: "Employees",
                column: "ProjectManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequests_Employees_Id",
                table: "ApprovalRequests",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequests_RequestStatuses_RequestStatusId",
                table: "ApprovalRequests",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AppUsers_AppUserId",
                table: "Employees",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ProjectManagerId",
                table: "Employees",
                column: "ProjectManagerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_AbsenceReasons_AbsenceReasonId",
                table: "LeaveRequests",
                column: "AbsenceReasonId",
                principalTable: "AbsenceReasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_ApprovalRequests_Id",
                table: "LeaveRequests",
                column: "Id",
                principalTable: "ApprovalRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_Employees_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequests_RequestStatuses_RequestStatusId",
                table: "LeaveRequests",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatuses_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId",
                principalTable: "ProjectStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId",
                principalTable: "ProjectTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Permissions_PermissionId",
                table: "Roles",
                column: "PermissionId",
                principalTable: "Permissions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequests_Employees_Id",
                table: "ApprovalRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequests_RequestStatuses_RequestStatusId",
                table: "ApprovalRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AppUsers_AppUserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ProjectManagerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_AbsenceReasons_AbsenceReasonId",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_ApprovalRequests_Id",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_Employees_EmployeeId",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequests_RequestStatuses_RequestStatusId",
                table: "LeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatuses_ProjectStatusId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectTypes_ProjectTypeId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Permissions_PermissionId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Roles_PermissionId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AppUserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProjectManagerId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTypes",
                table: "ProjectTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveRequests",
                table: "LeaveRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApprovalRequests",
                table: "ApprovalRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbsenceReasons",
                table: "AbsenceReasons");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProjectManagerId",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "ProjectTypes",
                newName: "ProjectType");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "LeaveRequests",
                newName: "LeaveRequest");

            migrationBuilder.RenameTable(
                name: "ApprovalRequests",
                newName: "ApprovalRequest");

            migrationBuilder.RenameTable(
                name: "AbsenceReasons",
                newName: "AbsenceReason");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Project",
                newName: "IX_Project_ProjectTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectStatusId",
                table: "Project",
                newName: "IX_Project_ProjectStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Project",
                newName: "IX_Project_ProjectManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_RequestStatusId",
                table: "LeaveRequest",
                newName: "IX_LeaveRequest_RequestStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequest",
                newName: "IX_LeaveRequest_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveRequests_AbsenceReasonId",
                table: "LeaveRequest",
                newName: "IX_LeaveRequest_AbsenceReasonId");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalRequests_RequestStatusId",
                table: "ApprovalRequest",
                newName: "IX_ApprovalRequest_RequestStatusId");

            migrationBuilder.AlterColumn<string>(
                name: "RequestStatusName",
                table: "RequestStatuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "RequestStatuses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectStatusName",
                table: "ProjectStatuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProjectStatuses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectTypeName",
                table: "ProjectType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProjectType",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Project",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "LeaveRequest",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ApprovalRequest",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<string>(
                name: "AbsenceReasonName",
                table: "AbsenceReason",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AbsenceReason",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveRequest",
                table: "LeaveRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalRequest",
                table: "ApprovalRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbsenceReason",
                table: "AbsenceReason",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_ApproverId",
                table: "ApprovalRequest",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_LeaveRequestId",
                table: "ApprovalRequest",
                column: "LeaveRequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequest_Employees_ApproverId",
                table: "ApprovalRequest",
                column: "ApproverId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequest_LeaveRequest_LeaveRequestId",
                table: "ApprovalRequest",
                column: "LeaveRequestId",
                principalTable: "LeaveRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequest_RequestStatuses_RequestStatusId",
                table: "ApprovalRequest",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AppUsers_Id",
                table: "Employees",
                column: "Id",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Project_ProjectId",
                table: "Employees",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_AbsenceReason_AbsenceReasonId",
                table: "LeaveRequest",
                column: "AbsenceReasonId",
                principalTable: "AbsenceReason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_Employees_EmployeeId",
                table: "LeaveRequest",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_RequestStatuses_RequestStatusId",
                table: "LeaveRequest",
                column: "RequestStatusId",
                principalTable: "RequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Employees_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectStatuses_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId",
                principalTable: "ProjectStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectType_ProjectTypeId",
                table: "Project",
                column: "ProjectTypeId",
                principalTable: "ProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
