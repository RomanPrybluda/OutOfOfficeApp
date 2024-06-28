using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class LeaveRequestInitializer
    {
        private readonly AppDbContext _context;
        private readonly Random _random;

        public LeaveRequestInitializer(AppDbContext context)
        {
            _context = context;
            _random = new Random();
        }

        public void InitializeLeaveRequests()
        {
            var existingLeaveRequestsCount = _context.LeaveRequests.Count();
            if (existingLeaveRequestsCount >= SeedConstants.NUMBER_OF_LEAVE_REQUESTS)
            {
                return;
            }

            var employees = _context.Employees.ToList();
            var absenceReasons = _context.AbsenceReasons.ToList();
            var requestStatuses = _context.RequestStatuses.ToList();

            if (!employees.Any() || !absenceReasons.Any() || !requestStatuses.Any())
            {
                throw new InvalidOperationException("Missing required data for LeaveRequest initialization.");
            }

            var newRequestStatus = requestStatuses.FirstOrDefault(rs => rs.RequestStatusName == Enum.GetName(typeof(LeaveRequestStatuses), LeaveRequestStatuses.New));
            if (newRequestStatus == null)
            {
                throw new InvalidOperationException("RequestStatus with status 'New' not found.");
            }

            var comments = new[]
            {
                "Medical leave",
                "Annual leave",
                "Personal reasons",
                "Family emergency",
                "Sick leave",
                "Conference attendance",
                "Training",
                "Parental leave",
                "Vacation",
                "Study leave"
            };

            for (int i = existingLeaveRequestsCount; i < SeedConstants.NUMBER_OF_LEAVE_REQUESTS; i++)
            {
                var employee = employees[_random.Next(employees.Count)];
                var absenceReason = absenceReasons[_random.Next(absenceReasons.Count)];
                var startDate = DateTime.UtcNow.AddDays(-_random.Next(30));
                var endDate = startDate.AddDays(_random.Next(1, 15));
                var comment = comments[_random.Next(comments.Length)];

                var newLeaveRequest = new LeaveRequest
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = employee.Id,
                    AbsenceReasonId = absenceReason.Id,
                    StartDate = startDate,
                    EndDate = endDate,
                    Comment = comment,
                    RequestStatusId = newRequestStatus.Id
                };

                _context.LeaveRequests.Add(newLeaveRequest);
            }

            _context.SaveChanges();
        }
    }
}
