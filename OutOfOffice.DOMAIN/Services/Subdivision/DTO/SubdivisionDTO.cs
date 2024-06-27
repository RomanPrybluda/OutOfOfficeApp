using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class SubdivisionDTO
    {
        public Guid Id { get; set; }
        public string SubdivisionName { get; set; }

        public static SubdivisionDTO SubdivisionToSubdivisionDTO(Subdivision subdivision)
        {
            return new SubdivisionDTO
            {
                Id = subdivision.Id,
                SubdivisionName = subdivision.SubdivisionName
            };
        }
    }
}