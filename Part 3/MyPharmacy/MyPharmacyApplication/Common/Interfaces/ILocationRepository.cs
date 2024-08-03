using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPharmacyApplication.Common.Interfaces
{
    public interface ILocationRepository<Location> where Location : class
    {
        Location Get(int? id);
        Location GetByLonLat(double longitude, double latitude);
        void Insert(Location location);
    }
}
