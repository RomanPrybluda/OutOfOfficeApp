using OutOfOffice.DAL;

public class CreateAppUserDTO
{

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public Guid RoleId { get; set; }

    public static AppUser CreateAppUserDTOToAppUser(CreateAppUserDTO createAppUserDTO)
    {
        return new AppUser
        {
            Id = Guid.NewGuid(),
            FirstName = createAppUserDTO.FirstName,
            LastName = createAppUserDTO.LastName,
            Email = createAppUserDTO.Email,
            RoleId = createAppUserDTO.RoleId
        };
    }
}