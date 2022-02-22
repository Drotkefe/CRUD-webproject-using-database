using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Data.DbContexts;
using VH3Q8P_HFT_2021221.Repository.Interfaces;
using VH3Q8P_HFT_2021221.Repository.Repositories;

namespace VH3Q8P_HFT_2021221.Repository.Infrastructure
{
    public static class RepoInitalization
    {
        public static void InitRepoServices(IServiceCollection services)
        {
            services.AddScoped<BikePurchaseHistoryDbContext>((sp)=> new BikePurchaseHistoryDbContext());
            services.AddScoped<IBikeRepository, BikeRepository>();
            services.AddScoped<IRiderRepository, RiderRepository>();
            services.AddScoped<IManufactureRepository, ManufactureRepository>();
        }
    }
}
