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
    public class PharmacyService : IPharmacyService
    {
        private readonly IPharmacyRepository<Pharmacy> _pharmacyRepository;

        public PharmacyService(IPharmacyRepository<Pharmacy> pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public Pharmacy GetById(long id)
        {
            return _pharmacyRepository.Get(id);
        }

        public Pharmacy GetByLatLong(double lon, double lat)
        {
            return _pharmacyRepository.GetByLatLong(lon, lat);
        }

        public List<Pharmacy> GetAll()
        {
            return _pharmacyRepository.GetAll();
        }

        public void Create(Pharmacy pharmacy)
        {
             _pharmacyRepository.Insert(pharmacy);
        }
    }
}
