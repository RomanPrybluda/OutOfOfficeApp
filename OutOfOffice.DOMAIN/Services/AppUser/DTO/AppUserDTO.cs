using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class AppUserDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string RoleName { get; set; } = string.Empty;

        public static AppUserDTO AppUserToAppUserDTO(AppUser appUser, Role role)
        {
            return new AppUserDTO
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Email = appUser.Email,
                RoleName = role.RoleName
            };
        }
    }

}