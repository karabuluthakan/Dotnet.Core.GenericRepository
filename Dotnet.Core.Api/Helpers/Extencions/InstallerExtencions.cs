using System;
using System.Linq;
using Dotnet.Core.Common.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Core.Api.Helpers.Extencions
{
    public static class InstallerExtencions
    {
        public static void ServicesInstallerAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x
                    => typeof(IConfigureServices).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IConfigureServices>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }

        public static void ConfigurationsInstallerAssembly(this IApplicationBuilder app, IConfiguration configuration,
            IHostingEnvironment env)
        {
            // configurationsSetup = installers
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x
                    => typeof(IConfigure).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IConfigure>().ToList();

            installers.ForEach(installer => installer.InstallConfigurations(app, env, configuration));
        }
    }
}