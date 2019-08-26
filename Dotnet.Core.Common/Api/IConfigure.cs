using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Dotnet.Core.Common.Api
{
    public interface IConfigure
    {
        void InstallConfigurations(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration);
    }
}