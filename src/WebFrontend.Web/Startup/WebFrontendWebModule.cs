using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebFrontend.Configuration;
using WebFrontend.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace WebFrontend.Web.Startup
{
    [DependsOn(
        typeof(WebFrontendApplicationModule), 
        typeof(WebFrontendEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class WebFrontendWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public WebFrontendWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(WebFrontendConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<WebFrontendNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(WebFrontendApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebFrontendWebModule).GetAssembly());
        }
    }
}