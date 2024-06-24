using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class RoleByIdDTO
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }

        public static RoleByIdDTO RoleToRoleDTO(Role role)
        {
            return new RoleByIdDTO
            {
                Id = role.Id,
                RoleName = role.RoleName
            };
        }
    }
}