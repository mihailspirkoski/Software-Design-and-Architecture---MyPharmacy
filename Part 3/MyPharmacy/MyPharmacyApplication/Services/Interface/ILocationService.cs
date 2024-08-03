using MyPharmacyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPharmacyApplication.Services.Interface
{
    public interface ILocationService
    {
        Location Get(int id);
        Location GetByLonLat(double longitude, double lattitude);
        void Create(Location location);
    }
}
