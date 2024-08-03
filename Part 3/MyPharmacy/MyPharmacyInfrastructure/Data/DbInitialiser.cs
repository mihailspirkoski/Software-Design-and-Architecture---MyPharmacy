using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyPharmacyApplication.Common.Interfaces;
using MyPharmacyApplication.Common.Utility;
using MyPharmacyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using NuGet.Protocol;
using Newtonsoft.Json;
using MyPharmacyApplication.Services.Interface;


namespace MyPharmacyInfrastructure.Data
{
    public class DbInitialiser : IDbInitialiser
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        ApplicationDbContext _context;
        //private readonly IPharmacyService _pharmacyService;

        public DbInitialiser(UserManager<IdentityUser> userManager, 
                             RoleManager<IdentityRole> roleManager,
                             IConfiguration configuration,
                             ApplicationDbContext context
                             /*IPharmacyService pharmacyService*/)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
            //_pharmacyService = pharmacyService;
        }

        public void Initialize()
        {

            //migrations if they are not applied
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex) { }


            //create role if not created

            if (!_roleManager.RoleExistsAsync(SD.Role_StandardUser).GetAwaiter().GetResult())
                {

                _roleManager.CreateAsync(new IdentityRole(SD.Role_StandardUser)).GetAwaiter().GetResult();

                //if roles are not created, then add pharmacies to the database

                var pharmacies = _configuration.GetSection("pharmacies").GetChildren().ToArray();

                foreach(var item in pharmacies)
                {
                    Pharmacy pharmacy = new Pharmacy();

                    var pharmaEntry = item.GetChildren().ToArray();

                    pharmacy.id = long.Parse(pharmaEntry[0].Value);
                    pharmacy.lat = double.Parse(pharmaEntry[1].Value) / 10000000;
                    pharmacy.lon = double.Parse(pharmaEntry[2].Value) / 10000000;
                    pharmacy.name = pharmaEntry[3].Value;

                    _context.Pharmacies.Add(pharmacy);
                    _context.SaveChanges();

                    //TODO : add pharmacy to db via pharmacy service;
                }

                //if roles are not created, then add user as well
                _userManager.CreateAsync(new MyPharmacyUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    Name = "Admin",
                }, "Admin123*").GetAwaiter().GetResult();


                MyPharmacyUser user = _context.MyPharmacyUsers.FirstOrDefault(u => u.Email == "admin@admin.com");
                _userManager.AddToRoleAsync(user, SD.Role_StandardUser).GetAwaiter().GetResult();

            }

            return;

        }
    }
}
