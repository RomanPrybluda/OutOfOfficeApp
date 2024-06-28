using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class RequestStatusInitializer
    {
        private readonly AppDbContext _context;

        public RequestStatusInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeRequestStatuses()
        {
            var requestStatusNames = Enum.GetNames(typeof(LeaveRequestStatuses));

            var existingRequestStatuses = _context.RequestStatuses.Select(p => p.RequestStatusName).ToList();

            foreach (var requestStatusName in requestStatusNames)
            {
                if (!existingRequestStatuses.Contains(requestStatusName))
                {
                    _context.RequestStatuses.Add(new RequestStatus
                    {
                        Id = Guid.NewGuid(),
                        RequestStatusName = requestStatusName
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}