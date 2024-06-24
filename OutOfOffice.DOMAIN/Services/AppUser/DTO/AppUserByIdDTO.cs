using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class AppUserByIdDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Guid RoleId { get; set; }

        public static AppUserByIdDTO AppUserToAppUserDTO(AppUser appUser)
        {
            return new AppUserByIdDTO
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
