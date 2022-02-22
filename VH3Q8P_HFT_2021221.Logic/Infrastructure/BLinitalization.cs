using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH3Q8P_HFT_2021221.Logic.Interfaces;
using VH3Q8P_HFT_2021221.Logic.Services;
using VH3Q8P_HFT_2021221.Repository.Infrastructure;

namespace VH3Q8P_HFT_2021221.Logic.Infrastructure
{
    public static class BLinitalization
    {
        public static void InitBlServices(IServiceCollection services)
        {
            RepoInitalization.InitRepoServices(services);
            services.AddScoped<IBikeLogic, BikeLogic>();
            services.AddScoped<IRiderLogic, RiderLogic>();
            services.AddScoped<IManufactureLogic, ManufactureLogic>();
        }
    }
}
