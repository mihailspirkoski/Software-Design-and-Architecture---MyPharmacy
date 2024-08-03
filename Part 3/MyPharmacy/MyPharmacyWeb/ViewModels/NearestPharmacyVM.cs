using MyPharmacyDomain.Entities;

namespace MyPharmacyWeb.ViewModels
{
    public class NearestPharmacyVM
    {
        public MyPharmacyUser myPharmacyUser {  get; set; }
        public Pharmacy pharmacy { get; set; }
    }
}
