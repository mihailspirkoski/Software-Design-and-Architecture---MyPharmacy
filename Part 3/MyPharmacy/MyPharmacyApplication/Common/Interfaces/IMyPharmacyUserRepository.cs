using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyPharmacyApplication.Common.Interfaces
{
    public interface IMyPharmacyUserRepository<MyPharmacyUser> where MyPharmacyUser : class
    {
        MyPharmacyUser Get(string userId);
        void Update(MyPharmacyUser user);
    }
}
