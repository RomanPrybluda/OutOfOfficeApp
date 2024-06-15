using OutOfOffice.DAL;
using System;
using System.Linq;

namespace OutOfOffice.DOMAIN
{
    public class SubdivisionInitializer
    {
        private readonly AppDbContext _context;

        public SubdivisionInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void InitializeSubdivisions()
        {
            string[] subdivisionNames = Enum.GetNames(typeof(Subdivisions));

            var existingSubdivisions = _context.Subdivisions.Select(s => s.SubdivisionName).ToList();

            foreach (var subdivisionName in subdivisionNames)
            {
                if (!existingSubdivisions.Contains(subdivisionName))
                {
                    _context.Subdivisions.Add(new Subdivision
                    {
                        Id = Guid.NewGuid(),
                        SubdivisionName = subdivisionName
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}
