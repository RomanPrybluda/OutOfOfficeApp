using Microsoft.EntityFrameworkCore;

namespace OutOfOffice.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<AbsenceReason> AbsenceReasons { get; set; }

        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Subdivision> Subdivisions { get; set; }

        public DbSet<ProjectType> ProjectTypes { get; set; }

        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

        public DbSet<ProjectStatus> ProjectStatuses { get; set; }

        public DbSet<LeaveRequestStatus> RequestStatuses { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AbsenceReasonConfiguration().Configure(modelBuilder.Entity<AbsenceReason>());

            new ApprovalRequestConfiguration().Configure(modelBuilder.Entity<ApprovalRequest>());

            new EmployeeConfiguration().Configure(modelBuilder.Entity<Employee>());

            new LeaveRequestConfiguration().Configure(modelBuilder.Entity<LeaveRequest>());

            new PositionConfiguration().Configure(modelBuilder.Entity<Position>());

            new ProjectConfiguration().Configure(modelBuilder.Entity<Project>());

            new ProjectTypeConfiguration().Configure(modelBuilder.Entity<ProjectType>());

            new SubdivisionConfiguration().Configure(modelBuilder.Entity<Subdivision>());

            new EmployeeStatusConfiguration().Configure(modelBuilder.Entity<EmployeeStatus>());

            new ProjectStatusConfiguration().Configure(modelBuilder.Entity<ProjectStatus>());

            new LeaveRequestStatusConfiguration().Configure(modelBuilder.Entity<LeaveRequestStatus>());

            base.OnModelCreating(modelBuilder);

        }

    }
}