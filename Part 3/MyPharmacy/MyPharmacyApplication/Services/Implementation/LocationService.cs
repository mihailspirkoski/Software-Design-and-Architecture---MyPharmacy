using MyPharmacyApplication.Common.Interfaces;
using MyPharmacyApplication.Services.Interface;
using MyPharmacyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPharmacyApplication.Services.Implementation
{
    public class LocationService : ILocationService
    {

        private readonly ILocationRepository<Location> _locationRepository;

        public LocationService(ILocationRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Location Get(int id)
        {
            return _locationRepository.Get(id);
        }

        public Location GetByLonLat(double longitude, double lattitude)
        {
            return _locationRepository.GetByLonLat(longitude, lattitude);
        }

        public void Create(Location location)
        {
            _locationRepository.Insert(location);
        }
    }
}
