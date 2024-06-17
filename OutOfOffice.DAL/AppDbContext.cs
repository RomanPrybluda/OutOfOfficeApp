using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL.Models;
using System.Data;

namespace OutOfOffice.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        //public DbSet<AbsenceReasonEntity> AbsenceReasons { get; set; }

        //public DbSet<ApprovalRequestEntity> ApprovalRequests { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        //public DbSet<LeaveRequestEntity> LeaveRequests { get; set; }

        public DbSet<Position> Positions { get; set; }

        //public DbSet<ProjectEntity> Projects { get; set; }

        public DbSet<Subdivision> Subdivisions { get; set; }

        //public DbSet<ProjectTypeEntity> ProjectTypes { get; set; }

        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

        //public DbSet<ProjectStatusEntity> ProjectStatuses { get; set; }

        //public DbSet<RequestStatusEntity> RequestStatuses { get; set; }

        public DbSet<Role> Roles { get; set; }

        //public DbSet<PermissionEntity> Permissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new AbsenceReasonConfiguration().Configure(modelBuilder.Entity<AbsenceReasonEntity>());

            //new ApprovalRequestConfiguration().Configure(modelBuilder.Entity<ApprovalRequestEntity>());

            new AppUserConfiguration().Configure(modelBuilder.Entity<AppUser>());

            new EmployeeConfiguration().Configure(modelBuilder.Entity<Employee>());

            //new LeaveRequestConfiguration().Configure(modelBuilder.Entity<LeaveRequestEntity>());

            new PositionConfiguration().Configure(modelBuilder.Entity<Position>());

            //new ProjectConfiguration().Configure(modelBuilder.Entity<ProjectEntity>());

            new SubdivisionConfiguration().Configure(modelBuilder.Entity<Subdivision>());

            //new ProjectTypeConfiguration().Configure(modelBuilder.Entity<ProjectTypeEntity>());


            new EmployeeStatusConfiguration().Configure(modelBuilder.Entity<EmployeeStatus>());

            //new ProjectStatusConfiguration().Configure(modelBuilder.Entity<ProjectStatusEntity>());

            //new LeaveRequestStatusConfiguration().Configure(modelBuilder.Entity<RequestStatusEntity>());

            new RoleConfiguration().Configure(modelBuilder.Entity<Role>());

            //new PermissionConfiguration().Configure(modelBuilder.Entity<PermissionEntity>());

            base.OnModelCreating(modelBuilder);

        }

    }
}