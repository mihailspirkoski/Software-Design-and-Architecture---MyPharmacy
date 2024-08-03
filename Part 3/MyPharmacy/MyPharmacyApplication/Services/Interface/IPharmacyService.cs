using MyPharmacyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPharmacyApplication.Services.Interface
{
    public interface IPharmacyService
    {
        Pharmacy GetById(long id);
        Pharmacy GetByLatLong(double lat, double lon);
        List<Pharmacy> GetAll();
        void Create(Pharmacy pharmacy);
    }
}
