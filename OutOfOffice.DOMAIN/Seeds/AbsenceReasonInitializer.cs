using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class AbsenceReasonInitializer
    {
        private readonly AppDbContext _context;

        public AbsenceReasonInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeAbsenceReasons()
        {

            var absenceReasonNames = Enum.GetNames(typeof(AbsenceReasons));

            var existingAbsenceReasons = _context.AbsenceReasons.Select(r => r.AbsenceReasonName).ToList();

            foreach (var absenceReasonName in absenceReasonNames)
            {
                if (!existingAbsenceReasons.Contains(absenceReasonName))
                {
                    _context.AbsenceReasons.Add(new AbsenceReason
                    {
                        Id = Guid.NewGuid(),
                        AbsenceReasonName = absenceReasonName
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}
