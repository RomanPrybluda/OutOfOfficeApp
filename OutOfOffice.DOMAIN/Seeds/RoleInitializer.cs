using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class RoleInitializer
    {
        private readonly AppDbContext _context;

        public RoleInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeRoles()
        {

            var roleNames = Enum.GetNames(typeof(RoleNames));

            var existingRoles = _context.Roles.Select(r => r.RoleName).ToList();

            foreach (var roleName in roleNames)
            {
                if (!existingRoles.Contains(roleName))
                {
                    _context.Roles.Add(new Role
                    {
                        Id = Guid.NewGuid(),
                        RoleName = roleName
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}
