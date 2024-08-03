using Microsoft.EntityFrameworkCore;
using MyPharmacyInfrastructure.Data;
using Microsoft.AspNetCore.Identity;
using MyPharmacyApplication.Common.Interfaces;
using MyPharmacyApplication.Services.Implementation;
using MyPharmacyDomain.Entities;
using MyPharmacyInfrastructure.Repository;
using Microsoft.AspNetCore.Identity.UI.Services;
using MyPharmacyInfrastructure.Emails;
using MyPharmacyApplication.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Configuration.AddJsonFile("pharmacies.json", true, true);

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped(typeof(IPharmacyRepository<Pharmacy>), typeof(PharmacyRepository));
builder.Services.AddScoped(typeof(ILocationRepository<Location>), typeof(LocationRepository));
builder.Services.AddScoped(typeof(IMyPharmacyUserRepository<MyPharmacyUser>), typeof(MyPharmacyUserRepository));
builder.Services.AddScoped<IPharmacyService, PharmacyService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IMyPharmacyUserService, MyPharmacyUserService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IDbInitialiser, DbInitialiser>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


SeedDatabase();

app.MapRazorPages();



app.Run();

void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitialiser = scope.ServiceProvider.GetRequiredService<IDbInitialiser>();
        dbInitialiser.Initialize();
    }
}
