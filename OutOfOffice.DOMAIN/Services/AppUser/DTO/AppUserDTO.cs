using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class AppUserDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Guid RoleId { get; set; }

        public static AppUserDTO AppUserToAppUserDTO(AppUser appUser)
        {
            return new AppUserDTO
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                Email = appUser.Email,
                RoleId = appUser.RoleId
            };
        }
    }

}