using Dotnet.Core.Api.Helpers.Extensions;
using Dotnet.Core.Common.Presentation;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Dotnet.Core.Api.Helpers.StartupConfigureServices
{
    public class OdataConfigureServices : IConfigureServices
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOData();
            services.AddTransient<OdataExtensions>();
        }
    }
}