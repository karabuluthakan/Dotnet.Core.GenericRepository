using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Dotnet.Core.Common.Presentation
{
    public interface IConfigure
    {
        void InstallConfigurations(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration);
    }
}