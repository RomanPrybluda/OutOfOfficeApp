using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class ProjectTypeInitializer
    {
        private readonly AppDbContext _context;

        public ProjectTypeInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeProjectTypes()
        {
            var projectTypeNames = Enum.GetNames(typeof(ProjectTypes));

            //var existingProjectTypes = _context.ProjectTypes.Select(p => p.ProjectTypeName).ToList();

            //foreach (var projectTypeName in projectTypeNames)
            //{
            //    if (!existingProjectTypes.Contains(projectTypeName))
            //    {
            //        _context.ProjectTypes.Add(new ProjectTypeEntity
            //        {
            //            Id = Guid.NewGuid(),
            //            ProjectTypeName = projectTypeName
            //        });
            //    }
            //}

            _context.SaveChanges();
        }
    }
}