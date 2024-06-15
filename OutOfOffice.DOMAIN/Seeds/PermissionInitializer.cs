using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class PermissionInitializer
    {
        private readonly AppDbContext _context;

        public PermissionInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializePermissions()
        {

            var permissionNames = Enum.GetNames(typeof(PermissionNames));

            var existingPermissions = _context.Permissions.Select(r => r.PermissionName).ToList();

            foreach (var permissionName in permissionNames)
            {
                if (!existingPermissions.Contains(permissionName))
                {
                    _context.Permissions.Add(new Permission
                    {
                        Id = Guid.NewGuid(),
                        PermissionName = permissionName
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}
