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
    public class PharmacyRepository : IPharmacyRepository<Pharmacy>
    {

        private readonly ApplicationDbContext _context;

        public PharmacyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Pharmacy Get(long id)
        {
            return _context.Pharmacies.FirstOrDefault(z => z.id == id);
        }

        public Pharmacy GetByLatLong(double lon, double lat)
        {
            return _context.Pharmacies.FirstOrDefault(z => z.lon == lon && z.lat == lat);
        }

        public List<Pharmacy> GetAll()
        {
            return _context.Pharmacies.ToList();
        }

        public void Insert(Pharmacy pharmacy)
        {
            if (pharmacy == null)
            {
                throw new ArgumentNullException("pharmacy");
            }
            _context.Pharmacies.Add(pharmacy);
            _context.SaveChanges();
        }

    }
}
