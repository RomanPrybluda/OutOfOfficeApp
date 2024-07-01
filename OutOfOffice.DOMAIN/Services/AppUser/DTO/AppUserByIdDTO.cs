using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class AppUserByIdDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string RoleName { get; set; } = string.Empty;

        public static AppUserByIdDTO AppUserToAppUserByIdDTO(AppUser appUser)
        {
            return new AppUserByIdDTO
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Email = appUser.Email,
                RoleName = appUser.Role.RoleName ?? string.Empty
            };
        }
    }

}
