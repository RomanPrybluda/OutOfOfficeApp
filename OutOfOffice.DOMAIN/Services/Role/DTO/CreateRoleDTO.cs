using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class CreateRoleDTO
    {
        public string RoleName { get; set; }

        public static Role CreateRoleFromDTO(CreateRoleDTO createRoleDTO)
        {
            return new Role
            {
                RoleName = createRoleDTO.RoleName
            };
        }
    }
}