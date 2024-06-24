using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL.Configurations;

namespace OutOfOffice.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<AbsenceReason> AbsenceReasons { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Subdivision> Subdivisions { get; set; }

        public DbSet<ProjectType> ProjectTypes { get; set; }

        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

        public DbSet<ProjectStatus> ProjectStatuses { get; set; }

        public DbSet<RequestStatus> RequestStatuses { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AbsenceReasonConfiguration().Configure(modelBuilder.Entity<AbsenceReason>());

            new AppUserConfiguration().Configure(modelBuilder.Entity<AppUser>());

            new EmployeeConfiguration().Configure(modelBuilder.Entity<Employee>());

            new LeaveRequestConfiguration().Configure(modelBuilder.Entity<LeaveRequest>());

            new PositionConfiguration().Configure(modelBuilder.Entity<Position>());

            new ProjectConfiguration().Configure(modelBuilder.Entity<Project>());

            new SubdivisionConfiguration().Configure(modelBuilder.Entity<Subdivision>());

            new ProjectTypeConfiguration().Configure(modelBuilder.Entity<ProjectType>());

            new EmployeeStatusConfiguration().Configure(modelBuilder.Entity<EmployeeStatus>());

            new ProjectStatusConfiguration().Configure(modelBuilder.Entity<ProjectStatus>());

            new RequestStatusConfiguration().Configure(modelBuilder.Entity<RequestStatus>());

            new RoleConfiguration().Configure(modelBuilder.Entity<Role>());

            new PermissionConfiguration().Configure(modelBuilder.Entity<Permission>());

            new ProjectEmployeeConfiguration().Configure(modelBuilder.Entity<ProjectEmployee>());

            new ApprovalRequestConfiguration().Configure(modelBuilder.Entity<ApprovalRequest>());

            base.OnModelCreating(modelBuilder);

        }

    }
}