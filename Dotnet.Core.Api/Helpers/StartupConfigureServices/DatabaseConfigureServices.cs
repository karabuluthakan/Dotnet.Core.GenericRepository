using Dotnet.Core.Common.Contracts;
using Dotnet.Core.Common.Presentation;
using Dotnet.Core.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Core.Api.Helpers.StartupConfigureServices
{
    public class DatabaseConfigureServices : IConfigureServices
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<GenericContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString(
                            DefaultConstants.DefaultDatabaseConnection
                        ))).BuildServiceProvider();
        }
    }
}