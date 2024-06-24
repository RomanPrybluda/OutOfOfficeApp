using OutOfOffice.DAL;

namespace OutOfOffice.DOMAIN
{
    public class UpdateSubdivisionDTO
    {
        public string SubdivisionName { get; set; }

        public static void UpdateSubdivision(Subdivision subdivision, UpdateSubdivisionDTO updateSubdivisionDTO)
        {
            subdivision.SubdivisionName = updateSubdivisionDTO.SubdivisionName;
        }
    }
}
