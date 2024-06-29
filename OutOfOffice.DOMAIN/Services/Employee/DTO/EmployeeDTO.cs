namespace OutOfOffice.DOMAIN
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }

        public string? FullName { get; set; }

        public string SubdivisionName { get; set; } = string.Empty;

        public string PositionName { get; set; } = string.Empty;

        public string EmployeeStatusName { get; set; } = string.Empty;

        public string PeoplePartnerName { get; set; } = string.Empty;

        public int OutOfOfficeBalance { get; set; }

        public static EmployeeDTO EmployeeToEmployeeDTO(Employee employee)
        {
            return new EmployeeDTO
            {
                Id = employee.Id,
                FullName = employee.FullName,
                SubdivisionName = employee.Subdivision?.SubdivisionName ?? string.Empty,
                PositionName = employee.Position?.PositionName ?? string.Empty,
                EmployeeStatusName = employee.EmployeeStatus?.EmployeeStatusName ?? string.Empty,
                PeoplePartnerName = employee.PeoplePartner?.FullName ?? string.Empty,
                OutOfOfficeBalance = employee.OutOfOfficeBalance
            };
        }
    }
}