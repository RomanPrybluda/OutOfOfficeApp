using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class SubdivisionByIdDTO
    {
        public Guid Id { get; set; }

        public string SubdivisionName { get; set; }

        public static SubdivisionByIdDTO SubdivisionToSubdivisionDTO(Subdivision subdivision)
        {
            return new SubdivisionByIdDTO
            {
                Id = subdivision.Id,
                SubdivisionName = subdivision.SubdivisionName
            };
        }
    }
}