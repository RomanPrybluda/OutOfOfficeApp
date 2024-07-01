using Microsoft.AspNetCore.Mvc;
using OutOfOffice.DOMAIN;

namespace OutOfOffice.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("project")]

    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjects()
        {
            var projects = await _projectService.GetProjectsListAsync();
            return Ok(projects);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ProjectDTO>> GetProjectById(Guid id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDTO>> CreateProject(CreateProjectDTO createProjectDTO)
        {
            var project = await _projectService.CreateProjectAsync(createProjectDTO);
            return Ok(project);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<ProjectDTO>> UpdateProject(Guid id, UpdateProjectDTO updateProjectDTO)
        {
            var project = await _projectService.UpdateProjectAsync(id, updateProjectDTO);
            return Ok(project);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _projectService.DeleteProjectAsync(id);
            return NoContent();
        }
    }
}