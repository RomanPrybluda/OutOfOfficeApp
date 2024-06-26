﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutOfOffice.DAL;

#nullable disable

namespace OutOfOffice.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OutOfOfficeBalance")
                        .HasColumnType("int");

                    b.Property<Guid?>("PeoplePartnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubdivisionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique()
                        .HasFilter("[AppUserId] IS NOT NULL");

                    b.HasIndex("EmployeeStatusId");

                    b.HasIndex("PeoplePartnerId");

                    b.HasIndex("PositionId");

                    b.HasIndex("SubdivisionId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.AbsenceReason", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("AbsenceReasonName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AbsenceReason", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AppUser", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.ApprovalRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("ApproverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("LeaveRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RequestStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("LeaveRequestId")
                        .IsUnique();

                    b.HasIndex("RequestStatusId");

                    b.ToTable("ApprovalRequests", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.EmployeeStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("EmployeeStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeStatus", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.LeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("AbsenceReasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RequestStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AbsenceReasonId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RequestStatusId");

                    b.ToTable("LeaveRequest", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Permission", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Position", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid>("ProjectStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectManagerId")
                        .IsUnique();

                    b.HasIndex("ProjectStatusId");

                    b.HasIndex("ProjectTypeId");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.ProjectEmployee", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ProjectEmployee", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.ProjectStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ProjectStatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ProjectStatus", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.ProjectType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ProjectTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ProjectType", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.RequestStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("RequestStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RequestStatus", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("OutOfOffice.DAL.Subdivision", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("SubdivisionName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Subdivision", (string)null);
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.HasOne("OutOfOffice.DAL.AppUser", "AppUser")
                        .WithOne("CurrentEmployee")
                        .HasForeignKey("Employee", "AppUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("OutOfOffice.DAL.EmployeeStatus", "EmployeeStatus")
                        .WithMany("Employees")
                        .HasForeignKey("EmployeeStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Employee", "PeoplePartner")
                        .WithMany()
                        .HasForeignKey("PeoplePartnerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("OutOfOffice.DAL.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OutOfOffice.DAL.Subdivision", "Subdivision")
                        .WithMany("Employees")
                        .HasForeignKey("SubdivisionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("EmployeeStatus");

                    b.Navigation("PeoplePartner");

                    b.Navigation("Position");

                    b.Navigation("Subdivision");
                });

            modelBuilder.Entity("OutOfOffice.DAL.AppUser", b =>
                {
                    b.HasOne("OutOfOffice.DAL.Role", "Role")
                        .WithMany("AppUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OutOfOffice.DAL.ApprovalRequest", b =>
                {
                    b.HasOne("Employee", "Approver")
                        .WithMany("ApprovalRequests")
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OutOfOffice.DAL.LeaveRequest", "LeaveRequest")
                        .WithOne("ApprovalRequest")
                        .HasForeignKey("OutOfOffice.DAL.ApprovalRequest", "LeaveRequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("OutOfOffice.DAL.RequestStatus", "RequestStatus")
                        .WithMany()
                        .HasForeignKey("RequestStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("LeaveRequest");

                    b.Navigation("RequestStatus");
                });

            modelBuilder.Entity("OutOfOffice.DAL.LeaveRequest", b =>
                {
                    b.HasOne("OutOfOffice.DAL.AbsenceReason", "AbsenceReason")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("AbsenceReasonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Employee", "Employee")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OutOfOffice.DAL.RequestStatus", "RequestStatus")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("RequestStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AbsenceReason");

                    b.Navigation("Employee");

                    b.Navigation("RequestStatus");
                });

            modelBuilder.Entity("OutOfOffice.DAL.Project", b =>
                {
                    b.HasOne("Employee", "ProjectManager")
                        .WithOne("ManagedProject")
                        .HasForeignKey("OutOfOffice.DAL.Project", "ProjectManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OutOfOffice.DAL.ProjectStatus", "ProjectStatus")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("OutOfOffice.DAL.ProjectType", "ProjectType")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProjectManager");

                    b.Navigation("ProjectStatus");

                    b.Navigation("ProjectType");
                });

            modelBuilder.Entity("OutOfOffice.DAL.ProjectEmployee", b =>
                {
                    b.HasOne("Employee", "Employee")
                        .WithMany("Projects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OutOfOffice.DAL.Project", "Project")
                        .WithMany("Employees")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("OutOfOffice.DAL.Role", b =>
                {
                    b.HasOne("OutOfOffice.DAL.Permission", null)
                        .WithMany("Roles")
                        .HasForeignKey("PermissionId");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Navigation("ApprovalRequests");

                    b.Navigation("LeaveRequests");

                    b.Navigation("ManagedProject")
                        .IsRequired();

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("OutOfOffice.DAL.AbsenceReason", b =>
                {
                    b.Navigation("LeaveRequests");
                });

            modelBuilder.Entity("OutOfOffice.DAL.AppUser", b =>
                {
                    b.Navigation("CurrentEmployee");
                });

            modelBuilder.Entity("OutOfOffice.DAL.EmployeeStatus", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("OutOfOffice.DAL.LeaveRequest", b =>
                {
                    b.Navigation("ApprovalRequest")
                        .IsRequired();
                });

            modelBuilder.Entity("OutOfOffice.DAL.Permission", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("OutOfOffice.DAL.Position", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("OutOfOffice.DAL.Project", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("OutOfOffice.DAL.ProjectStatus", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("OutOfOffice.DAL.ProjectType", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("OutOfOffice.DAL.RequestStatus", b =>
                {
                    b.Navigation("LeaveRequests");
                });

            modelBuilder.Entity("OutOfOffice.DAL.Role", b =>
                {
                    b.Navigation("AppUsers");
                });

            modelBuilder.Entity("OutOfOffice.DAL.Subdivision", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
