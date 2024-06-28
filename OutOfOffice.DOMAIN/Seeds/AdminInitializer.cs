using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class AdminInitializer
    {
        private readonly AppDbContext _context;

        public AdminInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeAdmin()
        {
            var roleName = Enum.GetName(typeof(RoleNames), RoleNames.Admin);
            var role = _context.Roles.FirstOrDefault(r => r.RoleName == roleName);

            if (role == null)
            {
                throw new Exception("Role 'Admin' not found in the database.");
            }

            // Step 1: Check the number of existing Admins
            var existingAdminCount = _context.AppUsers.Count(u => u.RoleId == role.Id);

            if (existingAdminCount >= SeedConstants.NUMBER_OF_ADMIN)
            {
                return;
            }

            // Step 2: Check if an Admin with the specific email already exists
            var adminEmail = "admin@gmail.com";
            var existingAdminByEmail = _context.AppUsers.FirstOrDefault(u => u.Email == adminEmail);

            if (existingAdminByEmail != null)
            {
                throw new Exception($"User with email {adminEmail} already exists.");
            }

            // Step 3: Create and add the Admin if none exists
            var admin = new AppUser
            {
                Id = Guid.NewGuid(),
                FirstName = "admin",
                LastName = "admin",
                Email = adminEmail,
                Password = adminEmail, // It is recommended to hash the password in production
                RoleId = role.Id,
                CurrentEmployee = null
            };

            _context.AppUsers.Add(admin);
            _context.SaveChanges();
        }
    }
}