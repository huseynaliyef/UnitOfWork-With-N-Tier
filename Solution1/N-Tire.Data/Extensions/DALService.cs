using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using N_Tier.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Data.Extensions
{
    public static class DALService
    {
        public static void InjectDataBase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MyDataBaseDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<MyDataBaseDbContext>().AddDefaultTokenProviders();
        }
    }
}
