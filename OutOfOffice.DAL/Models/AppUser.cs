namespace OutOfOffice.DAL.Models
{
    public class AppUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FullName
        {
            get
            {
                return $"{Name.Trim()} {Surname.Trim()}";
            }
            set
            {

            }
        }

        public Employee? Employee { get; set; }
    }
}