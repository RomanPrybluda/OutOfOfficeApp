using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutOfOffice.DAL.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_Employees_EmployeeStatuses_EmployeeStatusId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_PeoplePartnerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ProjectManagerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Subdivisions_SubdivisionId",
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

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subdivisions",
                table: "Subdivisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTypes",
                table: "ProjectTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStatuses",
                table: "ProjectStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveRequests",
                table: "LeaveRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeStatuses",
                table: "EmployeeStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AppUserId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProjectId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProjectManagerId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApprovalRequests",
                table: "ApprovalRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbsenceReasons",
                table: "AbsenceReasons");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProjectManagerId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "Subdivisions",
                newName: "Subdivision");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "RequestStatuses",
                newName: "RequestStatus");

            migrationBuilder.RenameTable(
                name: "ProjectTypes",
                newName: "ProjectType");

            migrationBuilder.RenameTable(
                name: "ProjectStatuses",
                newName: "ProjectStatus");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permission");

            migrationBuilder.RenameTable(
                name: "LeaveRequests",
                newName: "LeaveRequest");

            migrationBuilder.RenameTable(
                name: "EmployeeStatuses",
                newName: "EmployeeStatus");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "aupUser");

            migrationBuilder.RenameTable(
                name: "ApprovalRequests",
                newName: "ApprovalRequest");

            migrationBuilder.RenameTable(
                name: "AbsenceReasons",
                newName: "AbsenceReason");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_PermissionId",
                table: "Role",
                newName: "IX_Role_PermissionId");

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
                name: "IX_Employees_SubdivisionId",
                table: "Employee",
                newName: "IX_Employee_SubdivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RoleId",
                table: "Employee",
                newName: "IX_Employee_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PositionId",
                table: "Employee",
                newName: "IX_Employee_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PeoplePartnerId",
                table: "Employee",
                newName: "IX_Employee_PeoplePartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employee",
                newName: "IX_Employee_EmployeeStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalRequests_RequestStatusId",
                table: "ApprovalRequest",
                newName: "IX_ApprovalRequest_RequestStatusId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectManagerId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubdivisionName",
                table: "Subdivision",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Role",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectTypeName",
                table: "ProjectType",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectStatusName",
                table: "ProjectStatus",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PositionName",
                table: "Position",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PermissionName",
                table: "Permission",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeStatusName",
                table: "EmployeeStatus",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "Employee",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PeoplePartnerId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "aupUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "aupUser",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestStatusId",
                table: "ApprovalRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AbsenceReasonName",
                table: "AbsenceReason",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subdivision",
                table: "Subdivision",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestStatus",
                table: "RequestStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStatus",
                table: "ProjectStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveRequest",
                table: "LeaveRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeStatus",
                table: "EmployeeStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_aupUser",
                table: "aupUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalRequest",
                table: "ApprovalRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbsenceReason",
                table: "AbsenceReason",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProjectEmployee",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployee", x => new { x.ProjectId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ProjectEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectEmployee_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AppUserId",
                table: "Employee",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_ApproverId",
                table: "ApprovalRequest",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequest_LeaveRequestId",
                table: "ApprovalRequest",
                column: "LeaveRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployee_EmployeeId",
                table: "ProjectEmployee",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequest_Employee_ApproverId",
                table: "ApprovalRequest",
                column: "ApproverId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequest_LeaveRequest_LeaveRequestId",
                table: "ApprovalRequest",
                column: "LeaveRequestId",
                principalTable: "LeaveRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequest_RequestStatus_RequestStatusId",
                table: "ApprovalRequest",
                column: "RequestStatusId",
                principalTable: "RequestStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeStatus_EmployeeStatusId",
                table: "Employee",
                column: "EmployeeStatusId",
                principalTable: "EmployeeStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_PeoplePartnerId",
                table: "Employee",
                column: "PeoplePartnerId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Position_PositionId",
                table: "Employee",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Role_RoleId",
                table: "Employee",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Subdivision_SubdivisionId",
                table: "Employee",
                column: "SubdivisionId",
                principalTable: "Subdivision",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_aupUser_AppUserId",
                table: "Employee",
                column: "AppUserId",
                principalTable: "aupUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_AbsenceReason_AbsenceReasonId",
                table: "LeaveRequest",
                column: "AbsenceReasonId",
                principalTable: "AbsenceReason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_Employee_EmployeeId",
                table: "LeaveRequest",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveRequest_RequestStatus_RequestStatusId",
                table: "LeaveRequest",
                column: "RequestStatusId",
                principalTable: "RequestStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employee_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectStatus_ProjectStatusId",
                table: "Projects",
                column: "ProjectStatusId",
                principalTable: "ProjectStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ProjectType_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId",
                principalTable: "ProjectType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Permission_PermissionId",
                table: "Role",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequest_Employee_ApproverId",
                table: "ApprovalRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequest_LeaveRequest_LeaveRequestId",
                table: "ApprovalRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequest_RequestStatus_RequestStatusId",
                table: "ApprovalRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeStatus_EmployeeStatusId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_PeoplePartnerId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Position_PositionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Role_RoleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Subdivision_SubdivisionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_aupUser_AppUserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_AbsenceReason_AbsenceReasonId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_Employee_EmployeeId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveRequest_RequestStatus_RequestStatusId",
                table: "LeaveRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employee_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectStatus_ProjectStatusId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ProjectType_ProjectTypeId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Permission_PermissionId",
                table: "Role");

            migrationBuilder.DropTable(
                name: "ProjectEmployee");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subdivision",
                table: "Subdivision");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestStatus",
                table: "RequestStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStatus",
                table: "ProjectStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveRequest",
                table: "LeaveRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeStatus",
                table: "EmployeeStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AppUserId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_aupUser",
                table: "aupUser");

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
                name: "Subdivision",
                newName: "Subdivisions");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "RequestStatus",
                newName: "RequestStatuses");

            migrationBuilder.RenameTable(
                name: "ProjectType",
                newName: "ProjectTypes");

            migrationBuilder.RenameTable(
                name: "ProjectStatus",
                newName: "ProjectStatuses");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permissions");

            migrationBuilder.RenameTable(
                name: "LeaveRequest",
                newName: "LeaveRequests");

            migrationBuilder.RenameTable(
                name: "EmployeeStatus",
                newName: "EmployeeStatuses");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "aupUser",
                newName: "AppUsers");

            migrationBuilder.RenameTable(
                name: "ApprovalRequest",
                newName: "ApprovalRequests");

            migrationBuilder.RenameTable(
                name: "AbsenceReason",
                newName: "AbsenceReasons");

            migrationBuilder.RenameIndex(
                name: "IX_Role_PermissionId",
                table: "Roles",
                newName: "IX_Roles_PermissionId");

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
                name: "IX_Employee_SubdivisionId",
                table: "Employees",
                newName: "IX_Employees_SubdivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_RoleId",
                table: "Employees",
                newName: "IX_Employees_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_PositionId",
                table: "Employees",
                newName: "IX_Employees_PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_PeoplePartnerId",
                table: "Employees",
                newName: "IX_Employees_PeoplePartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_EmployeeStatusId",
                table: "Employees",
                newName: "IX_Employees_EmployeeStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalRequest_RequestStatusId",
                table: "ApprovalRequests",
                newName: "IX_ApprovalRequests_RequestStatusId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectManagerId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "SubdivisionName",
                table: "Subdivisions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectTypeName",
                table: "ProjectTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectStatusName",
                table: "ProjectStatuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PositionName",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PermissionName",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeStatusName",
                table: "EmployeeStatuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "PeoplePartnerId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectManagerId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestStatusId",
                table: "ApprovalRequests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "AbsenceReasonName",
                table: "AbsenceReasons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subdivisions",
                table: "Subdivisions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestStatuses",
                table: "RequestStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTypes",
                table: "ProjectTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStatuses",
                table: "ProjectStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permissions",
                table: "Permissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveRequests",
                table: "LeaveRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeStatuses",
                table: "EmployeeStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalRequests",
                table: "ApprovalRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbsenceReasons",
                table: "AbsenceReasons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AppUserId",
                table: "Employees",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectId",
                table: "Employees",
                column: "ProjectId");

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
                name: "FK_Employees_EmployeeStatuses_EmployeeStatusId",
                table: "Employees",
                column: "EmployeeStatusId",
                principalTable: "EmployeeStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_PeoplePartnerId",
                table: "Employees",
                column: "PeoplePartnerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ProjectManagerId",
                table: "Employees",
                column: "ProjectManagerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionId",
                table: "Employees",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Subdivisions_SubdivisionId",
                table: "Employees",
                column: "SubdivisionId",
                principalTable: "Subdivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
