using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class ProjectStatusInitializer
    {
        private readonly AppDbContext _context;

        public ProjectStatusInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeProjectStatuses()
        {
            var projectStatusNames = Enum.GetNames(typeof(ProjectStatuses));

            var existingProjectStatuses = _context.ProjectStatuses.Select(p => p.ProjectStatusName).ToList();

            foreach (var projectStatusName in projectStatusNames)
            {
                if (!existingProjectStatuses.Contains(projectStatusName))
                {
                    _context.ProjectStatuses.Add(new ProjectStatus
                    {
                        Id = Guid.NewGuid(),
                        ProjectStatusName = projectStatusName
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}