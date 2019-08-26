using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Core.Common.Api
{
    public interface IConfigureServices
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}