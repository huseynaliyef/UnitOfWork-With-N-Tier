using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using N_Tier.BusinessLogic.Logics;
using N_Tier.Data.DAL;
using N_Tier.Data.Extensions;
using N_Tier.BusinessLogic.Abstractions;
using N_Tier.BusinessLogic.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.BusinessLogic.Extensions
{
    public static class BusinessServices
    {
        public static void InjectBusiness(this IServiceCollection services)
        {
            services.AddScoped<ProductsLogics>();
            services.AddScoped<CatagoryLogics>();
            services.AddScoped<IAccountLogic, AccountLogic>();
            services.AddAutoMapper(typeof(AccountLogic));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
        }
    }
}
