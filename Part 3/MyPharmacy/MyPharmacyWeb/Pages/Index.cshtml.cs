using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPharmacyApplication.Services.Interface;
using MyPharmacyDomain.Entities;
using MyPharmacyWeb.ViewModels;
using System.Security.Claims;

namespace MyPharmacyWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPharmacyService _pharmacyService;
        private readonly IMyPharmacyUserService _userService;

        [BindProperty]
        public List<Pharmacy> pharmacies { get; set; }
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



        public IndexModel(ILogger<IndexModel> logger, IPharmacyService pharmacyService)
        {
            _logger = logger;
            _pharmacyService = pharmacyService;
        }

        public void OnGet()
        {
            pharmacies = _pharmacyService.GetAll();
            distance = 0.0;
            longitude = 0.0;
            lattitude = 0.0;
            clongitude = 0.0;
            clattitude = 0.0;

        }

        public IActionResult OnPost()
        {
            

            TempData["Distance"] = distance.ToString();
            TempData["Longitude"] = longitude.ToString();
            TempData["Lattitude"] = lattitude.ToString();
            TempData["CLongitude"] = clongitude.ToString();
            TempData["CLattitude"] = clattitude.ToString();


            return RedirectToPage("FindNearbyPharmacy");
        }
    }
}
