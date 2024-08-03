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
    public class MyPharmacyUserService : IMyPharmacyUserService
    {

        private readonly IMyPharmacyUserRepository<MyPharmacyUser> _repository;

        public MyPharmacyUserService(IMyPharmacyUserRepository<MyPharmacyUser> repository)
        {
            _repository = repository;
        }

        public MyPharmacyUser GetMyPharmacyUser(string userId)
        {
            return _repository.Get(userId);
        }

        public void Update(MyPharmacyUser user)
        {
            
            _repository.Update(user);
        }
    }
}
