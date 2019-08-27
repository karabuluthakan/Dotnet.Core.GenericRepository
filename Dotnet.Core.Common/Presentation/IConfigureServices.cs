using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Core.Common.Presentation
{
    public interface IConfigureServices
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}