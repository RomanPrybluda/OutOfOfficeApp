using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class AppUserInitializer
    {
        private readonly AppDbContext _context;

        public AppUserInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeAppUsers()
        {
            var appUserNames = new List<(string Name, string Surname)>
            {
                ("John", "Doe"), ("Jane", "Smith"), ("Michael", "Johnson"), ("Emily", "Brown"),
                ("Daniel", "Williams"), ("Olivia", "Jones"), ("David", "Garcia"), ("Sophia", "Davis"),
                ("James", "Miller"), ("Isabella", "Martinez"), ("Benjamin", "Lopez"), ("Emma", "Wilson"),
                ("William", "Moore"), ("Mia", "Taylor"), ("Alexander", "Anderson"), ("Ava", "Thomas"),
                ("Elijah", "Harris"), ("Charlotte", "Clark"), ("Gabriel", "Lewis"), ("Grace", "Walker"),
                ("Samuel", "Young"), ("Lily", "Rodriguez"), ("Nathan", "White"), ("Ella", "Hall"),
                ("Christopher", "King"), ("Madison", "Scott"), ("Joshua", "Green"), ("Amelia", "Adams"),
                ("Andrew", "Baker"), ("Abigail", "Campbell"), ("Joseph", "Martinez"), ("Samantha", "Nelson"),
                ("Logan", "Mitchell"), ("Hannah", "Carter"), ("Matthew", "Perez"), ("Avery", "Roberts"),
                ("Ryan", "Turner"), ("Victoria", "Hill"), ("Dylan", "Phillips"), ("Chloe", "Evans"),
                ("Luke", "Foster"), ("Zoe", "Murphy"), ("Carter", "Howard"), ("Evelyn", "Sanchez"),
                ("Isaac", "Torres"), ("Grace", "Rivera"), ("Jackson", "Cooper"), ("Audrey", "Brooks"),
                ("Jack", "Reed"), ("Penelope", "Perry"), ("Owen", "Ward"), ("Nora", "Bell"),
                ("Caleb", "Coleman"), ("Hazel", "Bailey"), ("Wyatt", "Barnes"), ("Ellie", "Price"),
                ("Julian", "Peterson"), ("Sofia", "Long"), ("Grayson", "Jenkins"), ("Scarlett", "Foster"),
                ("Liam", "Stewart"), ("Ruby", "Watson"), ("Connor", "Hughes"), ("Mila", "Sanders"),
                ("Jayden", "Gray"), ("Luna", "Gonzales"), ("Christian", "Ramirez"), ("Lillian", "Russell"),
                ("Isaiah", "Diaz"), ("Willow", "Hughes"), ("Charles", "Kelly"), ("Eleanor", "Powell"),
                ("Hunter", "Roberts"), ("Aria", "Murphy"), ("Thomas", "Gonzales"), ("Nova", "Richardson"),
                ("Aaron", "Nelson"), ("Emilia", "Young"), ("Adrian", "Cook"), ("Aurora", "Parker"),
                ("Evan", "Coleman"), ("Leah", "Brooks"), ("Jason", "Flores"), ("Haley", "Peterson"),
                ("Nolan", "Torres"), ("Anna", "Bennett"), ("Colton", "Washington"), ("Elizabeth", "Foster"),
                ("Gavin", "Jenkins"), ("Layla", "Butler"), ("Nicholas", "Price"), ("Aria", "Hughes"),
                ("Jordan", "Ward"), ("Addison", "Carter"), ("Tyler", "Ramirez"), ("Brooklyn", "Morris"),
                ("Jordan", "Long"), ("Addison", "Reed"), ("Tyler", "Perry"), ("Brooklyn", "Sanders")
            };

            var existingAppUserCount = _context.AppUsers.Count();

            // Ensure we don't consider Admin role
            var existingNonAdminAppUserCount = _context.AppUsers.Count(u => u.Role.RoleName != "Admin");
            var usersToAdd = SeedConstants.NUMBER_OF_APP_USERS - existingNonAdminAppUserCount;

            if (usersToAdd > 0)
            {
                var existingAppUserEmails = _context.AppUsers.Select(u => u.Email).ToList();
                int index = 0;

                // Add HR Managers
                for (int i = 0; i < Math.Min(SeedConstants.NUMBER_OF_HR_MANAGERS, usersToAdd); i++)
                {
                    var (Name, Surname) = appUserNames[index % appUserNames.Count];
                    var email = $"{Name.ToLower()}.{Surname.ToLower()}@gmail.com";

                    if (!existingAppUserEmails.Contains(email))
                    {
                        var role = _context.Roles.FirstOrDefault(r => r.RoleName == RoleNames.HRManager.ToString());

                        if (role == null)
                        {
                            throw new Exception("Role 'HRManager' not found in the database.");
                        }

                        var appUser = new AppUser
                        {
                            Id = Guid.NewGuid(),
                            FirstName = Name,
                            LastName = Surname,
                            Email = email,
                            Password = email,
                            RoleId = role.Id,
                            CurrentEmployee = null
                        };

                        _context.AppUsers.Add(appUser);
                        existingAppUserEmails.Add(email);
                        usersToAdd--;
                    }

                    index++;
                }

                // Add Project Managers
                for (int i = 0; i < Math.Min(SeedConstants.NUMBER_OF_PROJECT_MANAGERS, usersToAdd); i++)
                {
                    var (Name, Surname) = appUserNames[index % appUserNames.Count];
                    var email = $"{Name.ToLower()}.{Surname.ToLower()}@gmail.com";

                    if (!existingAppUserEmails.Contains(email))
                    {
                        var role = _context.Roles.FirstOrDefault(r => r.RoleName == RoleNames.ProjectManager.ToString());

                        if (role == null)
                        {
                            throw new Exception("Role 'ProjectManager' not found in the database.");
                        }

                        var appUser = new AppUser
                        {
                            Id = Guid.NewGuid(),
                            FirstName = Name,
                            LastName = Surname,
                            Email = email,
                            Password = email,
                            RoleId = role.Id,
                            CurrentEmployee = null
                        };

                        _context.AppUsers.Add(appUser);
                        existingAppUserEmails.Add(email);
                        usersToAdd--;
                    }

                    index++;
                }

                // Add remaining users as Employees
                for (int i = 0; i < usersToAdd; i++)
                {
                    var (Name, Surname) = appUserNames[index % appUserNames.Count];
                    var email = $"{Name.ToLower()}.{Surname.ToLower()}@gmail.com";

                    if (!existingAppUserEmails.Contains(email))
                    {
                        var role = _context.Roles.FirstOrDefault(r => r.RoleName == RoleNames.Employee.ToString());

                        if (role == null)
                        {
                            throw new Exception("Role 'Employee' not found in the database.");
                        }

                        var appUser = new AppUser
                        {
                            Id = Guid.NewGuid(),
                            FirstName = Name,
                            LastName = Surname,
                            Email = email,
                            Password = email,
                            RoleId = role.Id,
                            CurrentEmployee = null
                        };

                        _context.AppUsers.Add(appUser);
                        existingAppUserEmails.Add(email);
                    }

                    index++;
                }

                _context.SaveChanges();
            }
        }
    }
}