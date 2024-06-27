namespace OutOfOffice.DAL
{
    public class Role
    {
        public Guid Id { get; set; }

        public string RoleName { get; set; } = string.Empty;

        public ICollection<AppUser> AppUsers { get; set; } = new List<AppUser>();
    }
}