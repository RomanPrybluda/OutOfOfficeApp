using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN.Seeds
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

            var existingAdmin = _context.AppUsers.FirstOrDefault(u => u.RoleId == role.Id);

            if (existingAdmin == null)
            {

                var adminEmail = "admin@gmail.com";
                var existingAdminByEmail = _context.AppUsers.FirstOrDefault(u => u.Email == adminEmail);

                if (existingAdminByEmail != null)
                {
                    throw new Exception($"User with email {adminEmail} already exists.");
                }

                var admin = new AppUser
                {
                    Id = Guid.NewGuid(),
                    FirstName = "admin",
                    LastName = "admin",
                    Email = adminEmail,
                    Password = "admin@gmail.com",
                    RoleId = role.Id,
                    CurrentEmployee = null
                };

                _context.AppUsers.Add(admin);

                _context.SaveChanges();
            }
        }
    }
}
