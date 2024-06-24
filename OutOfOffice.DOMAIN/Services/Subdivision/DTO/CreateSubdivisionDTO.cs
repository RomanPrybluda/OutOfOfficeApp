using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class CreateSubdivisionDTO
    {
        public string SubdivisionName { get; set; }

        public static Subdivision CreateSubdivisionFromDTO(CreateSubdivisionDTO createSubdivisionDTO)
        {
            return new Subdivision
            {
                SubdivisionName = createSubdivisionDTO.SubdivisionName
            };
        }
    }
}