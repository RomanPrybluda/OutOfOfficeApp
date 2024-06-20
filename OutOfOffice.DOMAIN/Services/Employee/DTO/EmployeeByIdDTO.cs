using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class EmployeeByIdDTO
    {
        public Guid Id { get; set; }

        public string? FullName { get; set; }

        public Guid SubdivisionId { get; set; }

        public Guid PositionId { get; set; }

        public Guid EmployeeStatusId { get; set; }

        public Guid? PeoplePartnerId { get; set; }

        public int OutOfOfficeBalance { get; set; }

        public static EmployeeByIdDTO EmployeeToEmployeeDTO(Employee employee)
        {
            return new EmployeeByIdDTO
            {
                Id = employee.Id,
                FullName = employee.FullName,
                SubdivisionId = employee.SubdivisionId,
                PositionId = employee.PositionId,
                EmployeeStatusId = employee.EmployeeStatusId,
                PeoplePartnerId = employee.PeoplePartnerId,
                OutOfOfficeBalance = employee.OutOfOfficeBalance
            };
        }
    }
}