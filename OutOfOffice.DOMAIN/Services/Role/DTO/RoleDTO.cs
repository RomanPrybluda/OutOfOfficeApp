using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class RoleDTO
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }

        public static RoleDTO RoleToRoleDTO(Role role)
        {
            return new RoleDTO
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }
    }
}