using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPharmacyApplication.Services.Interface;
using MyPharmacyDomain.Entities;
using System.Security.Claims;

namespace MyPharmacyWeb.Pages
{
    public class SeeLastSavedLocationModel : PageModel
    {

        private readonly IPharmacyService _pharmacyService;
        private readonly ILocationService _locationService;
        private readonly IMyPharmacyUserService _myPharmacyUserService;

        public SeeLastSavedLocationModel(IPharmacyService pharmacyService,
                                       ILocationService locationService,
                                       IMyPharmacyUserService myPharmacyUserService)
        {
            _myPharmacyUserService = myPharmacyUserService;
            _pharmacyService = pharmacyService;
            _locationService = locationService;
        }

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            MyPharmacyUser user = _myPharmacyUserService.GetMyPharmacyUser(userId);
            Pharmacy pharmacy = _pharmacyService.GetById((long)user.lastPharmacyId);
            Location location = _locationService.Get((int)user.lastLocationId);

            TempData["Distance"] = location.distance.ToString();
            TempData["Longitude"] = pharmacy.lon.ToString();
            TempData["Lattitude"] = pharmacy.lat.ToString();
            TempData["CLongitude"] = location.longitude.ToString();
            TempData["CLattitude"] = location.latitude.ToString();
            TempData["Time"] = user.lastEntryDate.ToString();
            TempData["Name"] = pharmacy.name.ToString();
        }
    }
}
