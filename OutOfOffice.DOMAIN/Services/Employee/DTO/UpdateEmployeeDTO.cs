namespace OutOfOffice.DOMAIN
{
    public class UpdateEmployeeDTO
    {
        public string? FullName { get; set; }
        public Guid SubdivisionId { get; set; }
        public Guid PositionId { get; set; }
        public Guid EmployeeStatusId { get; set; }
        public Guid PeoplePartnerId { get; set; }
        public int OutOfOfficeBalance { get; set; }

        public static void UpdateEmployee(Employee employee, UpdateEmployeeDTO updateEmployeeDTO)
        {
            employee.FullName = updateEmployeeDTO.FullName;
            employee.SubdivisionId = updateEmployeeDTO.SubdivisionId;
            employee.PositionId = updateEmployeeDTO.PositionId;
            employee.EmployeeStatusId = updateEmployeeDTO.EmployeeStatusId;
            employee.PeoplePartnerId = updateEmployeeDTO.PeoplePartnerId;
            employee.OutOfOfficeBalance = updateEmployeeDTO.OutOfOfficeBalance;
        }
    }
}