using MyPharmacyApplication.Common.Interfaces;
using MyPharmacyDomain.Entities;
using MyPharmacyInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPharmacyInfrastructure.Repository
{

    public class LocationRepository : ILocationRepository<Location>
    {

        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Location Get(int? id)
        {
            return _context.Locations.FirstOrDefault(z => z.Id == id);
        }

        public Location GetByLonLat(double longitude, double latitude)
        {
            return _context.Locations.FirstOrDefault(z => z.longitude == longitude && z.latitude == latitude);
        }
        public void Insert(Location location)
        {
            if (this.GetByLonLat(location.longitude, location.latitude) != null) {
                return;
            }

            _context.Add(location);
            _context.SaveChanges();
        }
    }
}
