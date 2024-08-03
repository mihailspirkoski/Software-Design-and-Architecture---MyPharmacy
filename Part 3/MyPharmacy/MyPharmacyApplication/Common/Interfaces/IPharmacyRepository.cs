using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPharmacyApplication.Common.Interfaces
{
    public interface IPharmacyRepository<Pharmacy> where Pharmacy : class
    {
        Pharmacy Get(long id);
        Pharmacy GetByLatLong(double lon, double lat);
        List<Pharmacy> GetAll();
        void Insert(Pharmacy pharmacy);


    }
}
