using Dotnet.Core.Common.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Dotnet.Core.Api.Helpers.StartupConfigure
{
    public class MvcConfigure : IConfigure
    {
        public void InstallConfigurations(IApplicationBuilder app, IHostingEnvironment env,
            IConfiguration configuration)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}