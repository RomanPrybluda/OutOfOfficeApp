namespace OutOfOffice.DOMAIN
{
    public class EmployeeByIdDTO
    {
        public Guid Id { get; set; }

        public string? FullName { get; set; }

        public string SubdivisionName { get; set; } = string.Empty;

        public string PositionName { get; set; } = string.Empty;

        public string EmployeeStatusName { get; set; } = string.Empty;

        public string? PeoplePartnerName { get; set; }

        public int OutOfOfficeBalance { get; set; }

        public static EmployeeByIdDTO EmployeeToEmployeeDTO(Employee employee)
        {
            return new EmployeeByIdDTO
            {
                Id = employee.Id,
                FullName = employee.FullName,
                SubdivisionName = employee.Subdivision?.SubdivisionName ?? string.Empty,
                PositionName = employee.Position?.PositionName ?? string.Empty,
                EmployeeStatusName = employee.EmployeeStatus?.EmployeeStatusName ?? string.Empty,
                PeoplePartnerName = employee.PeoplePartner?.FullName,
                OutOfOfficeBalance = employee.OutOfOfficeBalance
            };
        }
    }
}