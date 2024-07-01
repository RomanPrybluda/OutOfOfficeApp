using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class ProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjectsListAsync()
        {
            var projects = await _context.Projects
                .Include(p => p.ProjectType)
                .Include(p => p.ProjectManager)
                .Include(p => p.ProjectStatus)
                .ToListAsync();

            var projectDTOs = projects.Select(p => new ProjectDTO
            {
                Id = p.Id,
                ProjectName = p.ProjectName,
                ProjectTypeName = p.ProjectType?.ProjectTypeName ?? string.Empty,
                ProjectManagerFullName = p.ProjectManager?.FullName ?? string.Empty,
                ProjectStatusName = p.ProjectStatus?.ProjectStatusName ?? string.Empty,
                Comment = p.Comment
            }).ToList();

            return projectDTOs;
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(Guid id)
        {
            var project = await _context.Projects
                .Include(p => p.ProjectType)
                .Include(p => p.ProjectManager)
                .Include(p => p.ProjectStatus)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No project found with id {id}");

            var projectDTO = new ProjectDTO
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                ProjectTypeName = project.ProjectType?.ProjectTypeName ?? string.Empty,
                ProjectManagerFullName = project.ProjectManager?.FullName ?? string.Empty,
                ProjectStatusName = project.ProjectStatus?.ProjectStatusName ?? string.Empty,
                Comment = project.Comment
            };

            return projectDTO;
        }

        public async Task<ProjectDTO> CreateProjectAsync(CreateProjectDTO request)
        {
            var project = new Project
            {
                ProjectName = request.ProjectName,
                ProjectTypeId = request.ProjectTypeId,
                ProjectManagerId = request.ProjectManagerId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                ProjectStatusId = request.ProjectStatusId,
                Comment = request.Comment
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            var createdProject = await _context.Projects.FindAsync(project.Id);
            var projectDTO = new ProjectDTO
            {
                Id = createdProject.Id,
                ProjectName = createdProject.ProjectName,
                ProjectTypeName = createdProject.ProjectType?.ProjectTypeName ?? string.Empty,
                ProjectManagerFullName = createdProject.ProjectManager?.FullName ?? string.Empty,
                ProjectStatusName = createdProject.ProjectStatus?.ProjectStatusName ?? string.Empty,
                Comment = createdProject.Comment
            };

            return projectDTO;
        }

        public async Task<ProjectDTO> UpdateProjectAsync(Guid id, UpdateProjectDTO request)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No project found with id {id}");

            project.ProjectName = request.ProjectName;
            project.ProjectTypeId = request.ProjectTypeId;
            project.ProjectManagerId = request.ProjectManagerId;
            project.StartDate = request.StartDate;
            project.EndDate = request.EndDate;
            project.ProjectStatusId = request.ProjectStatusId;
            project.Comment = request.Comment;

            await _context.SaveChangesAsync();

            var updatedProjectDTO = new ProjectDTO
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                ProjectTypeName = project.ProjectType?.ProjectTypeName ?? string.Empty,
                ProjectManagerFullName = project.ProjectManager?.FullName ?? string.Empty,
                ProjectStatusName = project.ProjectStatus?.ProjectStatusName ?? string.Empty,
                Comment = project.Comment
            };

            return updatedProjectDTO;
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
                throw new CustomException(CustomExceptionType.NotFound, $"Project with id {id} wasn't found.");

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
