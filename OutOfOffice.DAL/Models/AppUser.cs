namespace OutOfOffice.DAL.Models
{
    public class AppUser
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName
        {
            get
            {
                return $"{FirstName.Trim()} {LastName.Trim()}";
            }
            set
            {

            }
        }

        public Employee? CurrentEmployee { get; set; }
    }
}