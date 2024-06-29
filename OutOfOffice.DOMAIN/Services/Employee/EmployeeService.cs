using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class EmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesListAsync()
        {
            var employees = await _context.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Position)
                .Include(e => e.EmployeeStatus)
                .Include(e => e.PeoplePartner)
                .ToListAsync();

            if (employees == null)
                throw new CustomException(CustomExceptionType.NotFound, "No employees found");

            var employeeDTOs = new List<EmployeeDTO>();

            foreach (var employee in employees)
            {
                var employeeDTO = EmployeeDTO.EmployeeToEmployeeDTO(employee);
                employeeDTOs.Add(employeeDTO);
            }

            return employeeDTOs;
        }

        public async Task<EmployeeByIdDTO> GetEmployeeByIdAsync(Guid id)
        {
            var employeeById = await _context.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Position)
                .Include(e => e.EmployeeStatus)
                .Include(e => e.PeoplePartner)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employeeById == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No employee found with id {id}");

            var employeeByIdDTO = EmployeeByIdDTO.EmployeeToEmployeeDTO(employeeById);

            return employeeByIdDTO;
        }

        public async Task<EmployeeDTO> CreateEmployeeAsync(CreateEmployeeDTO request)
        {
            var employeeByFullName = await _context.Employees.FirstOrDefaultAsync(e => e.FullName == request.FullName);

            if (employeeByFullName != null)
                throw new CustomException(CustomExceptionType.EmployeeAlreadyExists,
                    $"Employee with full name {request.FullName} already exists.");

            var peoplePartner = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.PeoplePartnerId);

            if (peoplePartner == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"No HR Manager found with id {request.PeoplePartnerId}");

            var positionName = Positions.HRManager.ToString();
            var position = await _context.Positions.FirstOrDefaultAsync(p => p.PositionName == positionName);

            if (peoplePartner.PositionId != position.Id)
                throw new CustomException(CustomExceptionType.NotFound, "PeoplePartner must be an employee with the 'HR Manager' position");

            var employee = CreateEmployeeDTO.CreateEmployeeDTOToEmployee(request);

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            var createdEmployee = await _context.Employees.FindAsync(employee.Id);

            var employeeDTO = EmployeeDTO.EmployeeToEmployeeDTO(createdEmployee);

            return employeeDTO;
        }

        public async Task<EmployeeByIdDTO> UpdateEmployeeAsync(Guid id, UpdateEmployeeDTO request)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                throw new CustomException(CustomExceptionType.NotFound, $"No employee found with id {id}");

            var peoplePartner = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.PeoplePartnerId);

            if (peoplePartner == null)
                throw new CustomException(CustomExceptionType.NotFound,
                    $"No HR Manager found with id {peoplePartner.Id}");

            var positionName = Positions.HRManager.ToString();
            var position = await _context.Positions.FirstOrDefaultAsync(p => p.PositionName == positionName);

            if (peoplePartner.PositionId != position.Id)
                throw new CustomException(CustomExceptionType.NotFound, "PeoplePartner must be an employee with the 'HR Manager' position");


            UpdateEmployeeDTO.UpdateEmployee(employee, request);

            await _context.SaveChangesAsync();

            var updatedEmployeeDTO = EmployeeByIdDTO.EmployeeToEmployeeDTO(employee);

            return updatedEmployeeDTO;
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                throw new CustomException(CustomExceptionType.NotFound, $"Employee with id {id} wasn't found.");

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}