using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class UpdateRoleDTO
    {
        public string RoleName { get; set; }

        public static void UpdateRole(Role role, UpdateRoleDTO updateRoleDTO)
        {
            role.RoleName = updateRoleDTO.RoleName;
        }
    }
}