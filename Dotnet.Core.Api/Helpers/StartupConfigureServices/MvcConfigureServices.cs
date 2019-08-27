using System.Reflection;
using AutoMapper;
using Dotnet.Core.Common.Helpers.AutoMapper;
using Dotnet.Core.Common.Helpers.Filters;
using Dotnet.Core.Common.Presentation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Core.Api.Helpers.StartupConfigureServices
{
    public class MvcConfigureServices : IConfigureServices
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(new Assembly[] {typeof(AutoMapperProfile).GetTypeInfo().Assembly});

            services.AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(opt => { opt.RegisterValidatorsFromAssemblyContaining<Startup>(); })
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}