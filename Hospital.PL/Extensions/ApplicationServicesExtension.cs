using Hospital.BLL.Interfaces;
using Hospital.BLL.Repositories;
using Hospital.DAL.Data;
using Hospital.PL.Helpers;
using Microsoft.AspNetCore.Identity;

namespace Hospital.PL.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
        {
            
            Services.AddScoped<IUnitOfWork, UnitOfWork>();

            Services.AddAutoMapper(D => D.AddProfile(new MappingProfiles()));
           


            //Services.AddAutoMapper(U => U.AddProfile(new UserProfiles()));
            //Services.AddAutoMapper(U => U.AddProfile(new RoleProfiles()));
            //Services.AddIdentity<ApplicationUser, IdentityRole>()
            //        .AddEntityFrameworkStores<AppDbContext>()
            //        .AddDefaultTokenProviders();

            return Services;
        }
    }
}
