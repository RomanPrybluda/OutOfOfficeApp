namespace OutOfOffice.DOMAIN
{
    public class CreateEmployeeDTO
    {
        public string? FullName { get; set; }

        public Guid SubdivisionId { get; set; }

        public Guid PositionId { get; set; }

        public Guid EmployeeStatusId { get; set; }

        public Guid PeoplePartnerId { get; set; }

        public int OutOfOfficeBalance { get; set; }

        public static Employee CreateEmployeeDTOToEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            var employee = new Employee(null, createEmployeeDTO.FullName)
            {
                SubdivisionId = createEmployeeDTO.SubdivisionId,
                PositionId = createEmployeeDTO.PositionId,
                EmployeeStatusId = createEmployeeDTO.EmployeeStatusId,
                PeoplePartnerId = createEmployeeDTO.PeoplePartnerId,
                OutOfOfficeBalance = createEmployeeDTO.OutOfOfficeBalance
            };

            return employee;
        }
    }
}