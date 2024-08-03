using MyPharmacyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPharmacyApplication.Services.Interface
{
    public interface IMyPharmacyUserService
    {
        MyPharmacyUser GetMyPharmacyUser(string userId);

        void Update(MyPharmacyUser user);
    }
}
