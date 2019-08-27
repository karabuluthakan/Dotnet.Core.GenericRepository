using Dotnet.Core.Business.Abstract;
using Dotnet.Core.Business.Concrete;
using Dotnet.Core.Common.DataAccess;
using Dotnet.Core.Common.Presentation;
using Dotnet.Core.DataAccess.Abstract;
using Dotnet.Core.DataAccess.Abstract.EntityFramework;
using Dotnet.Core.DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Core.Api.Helpers.StartupConfigureServices
{
    public class DependencyInjectionConfigureServices : IConfigureServices
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IContinentalService, ContinentalManager>();
            services.AddScoped<IContinentalDal, EfContinentalDal>();
            services.AddScoped<IRegionService, RegionManager>();
            services.AddScoped<IRegionDal, EfRegionDal>();
            services.AddScoped<ICountryService, CountryManager>();
            services.AddScoped<ICountryDal, EfCountryDal>();
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<ICityDal, EfCityDal>();
        }
    }
}