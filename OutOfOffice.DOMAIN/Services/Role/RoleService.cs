using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class RoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleDTO>> GetRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();

            if (roles == null)
                throw new CustomException(CustomExceptionType.NotFound, "Roles weren't found");

            var roleDTOs = new List<RoleDTO>();

            foreach (var role in roles)
            {
                var roleDTO = RoleDTO.RoleToRoleDTO(role);
                roleDTOs.Add(roleDTO);
            }

            return roleDTOs;
        }

        public async Task<RoleByIdDTO> GetRoleByIdAsync(Guid id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);

            if (role == null)
                throw new CustomException(CustomExceptionType.NotFound, $"Role with id {id} wasn't found.");

            var roleByIdDTO = RoleByIdDTO.RoleToRoleDTO(role);

            return roleByIdDTO;
        }

        public async Task<RoleDTO> CreateRoleAsync(CreateRoleDTO request)
        {
            var existingRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == request.RoleName);

            if (existingRole != null)
                throw new CustomException(CustomExceptionType.RoleAlreadyExists,
                    $"Role with name {request.RoleName} already exists.");

            var role = CreateRoleDTO.CreateRoleFromDTO(request);

            _context.Roles.Add(role);

            await _context.SaveChangesAsync();

            var createdRole = await _context.Roles.FindAsync(role.Id);

            var roleDTO = RoleDTO.RoleToRoleDTO(createdRole);

            return roleDTO;
        }

        public async Task<RoleDTO> UpdateRoleAsync(Guid id, UpdateRoleDTO request)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Role with id {id} wasn't found.");

            UpdateRoleDTO.UpdateRole(role, request);

            await _context.SaveChangesAsync();

            var updatedRoleDTO = RoleDTO.RoleToRoleDTO(role);

            return updatedRoleDTO;
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"Role with id {id} wasn't found.");

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }
}
