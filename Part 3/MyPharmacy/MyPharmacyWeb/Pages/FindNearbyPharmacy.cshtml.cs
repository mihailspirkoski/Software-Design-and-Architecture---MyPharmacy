using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPharmacyApplication.Services.Interface;
using MyPharmacyDomain.Entities;
using MyPharmacyWeb.ViewModels;
using System.Security.Claims;

namespace MyPharmacyWeb.Pages
{
    public class FindNearbyPharmacyModel : PageModel
    {

        private readonly IPharmacyService _pharmacyService;
        private readonly ILocationService _locationService;
        private readonly IMyPharmacyUserService _myPharmacyUserService;


        [BindProperty]
        public string userId { get; set; }
        [BindProperty]
        public double distance { get; set; }
        [BindProperty]
        public double longitude { get; set; }
        [BindProperty]
        public double lattitude { get; set; }
        [BindProperty]
        public double clongitude { get; set; }
        [BindProperty]
        public double clattitude { get; set; }


        public FindNearbyPharmacyModel(IPharmacyService pharmacyService,
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

            userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            longitude = Convert.ToDouble(TempData["Longitude"]);
            lattitude = Convert.ToDouble(TempData["Lattitude"]);
            clongitude = Convert.ToDouble(TempData["CLongitude"]);
            clattitude = Convert.ToDouble(TempData["CLattitude"]);
            distance = Convert.ToDouble(TempData["Distance"]);

            TempData["Name"] = _pharmacyService.GetByLatLong(longitude,lattitude).name.ToString();

            Location toAdd = new Location();
            toAdd.longitude = clongitude;
            toAdd.latitude = clattitude;
            toAdd.distance = distance;


            _locationService.Create(toAdd);


        }
        public IActionResult OnPost()
        {

            MyPharmacyUser myPharmacyUser = _myPharmacyUserService.GetMyPharmacyUser(userId);
            Pharmacy pharmacy = _pharmacyService.GetByLatLong(longitude, lattitude);
            Location location = _locationService.GetByLonLat(clongitude, clattitude);

            
            myPharmacyUser.lastPharmacy = pharmacy;
            myPharmacyUser.lastPharmacyId = pharmacy.id;
            myPharmacyUser.lastLocation = location;
            myPharmacyUser.lastLocationId = location.Id;
            myPharmacyUser.lastEntryDate = DateTime.UtcNow;

            _myPharmacyUserService.Update(myPharmacyUser);
            

            return RedirectToPage("/SeeLastSavedLocation");
        }
    }
}
