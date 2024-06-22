using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }

        public string? FullName { get; set; }

        public Guid SubdivisionId { get; set; }

        public Guid PositionId { get; set; }

        public Guid EmployeeStatusId { get; set; }

        public Guid? PeoplePartnerId { get; set; }

        public int OutOfOfficeBalance { get; set; }

        public static EmployeeDTO EmployeeToEmployeeDTO(Employee employee)
        {
            return new EmployeeDTO
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