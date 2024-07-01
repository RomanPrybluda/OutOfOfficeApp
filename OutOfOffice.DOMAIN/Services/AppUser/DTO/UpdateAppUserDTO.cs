using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class UpdateAppUserDTO
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Guid RoleId { get; set; }

        public static void UpdateAppUser(AppUser appUser, UpdateAppUserDTO updateAppUserDTO)
        {
            appUser.FirstName = updateAppUserDTO.FirstName;
            appUser.LastName = updateAppUserDTO.LastName;
            appUser.Email = updateAppUserDTO.Email;
            appUser.RoleId = updateAppUserDTO.RoleId;
        }
    }

}
