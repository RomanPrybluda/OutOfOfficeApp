namespace OutOfOffice.DAL
{
    public class Permission
    {
        public Guid Id { get; set; }

        public string? PermissionName { get; set; }

        public ICollection<Role>? Roles { get; set; } = new List<Role>();
    }
}