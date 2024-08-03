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
    public class MyPharmacyUserRepository : IMyPharmacyUserRepository<MyPharmacyUser>
    {

        private readonly ApplicationDbContext _context;

        public MyPharmacyUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MyPharmacyUser Get(string userId)
        {
            return _context.MyPharmacyUsers.FirstOrDefault(z => z.Id == userId);
        }

        public void Update(MyPharmacyUser user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }
    }
}
