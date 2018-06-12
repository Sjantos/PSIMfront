using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using WebFrontend.Web.Startup;
namespace WebFrontend.Web.Tests
{
    [DependsOn(
        typeof(WebFrontendWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class WebFrontendWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebFrontendWebTestModule).GetAssembly());
        }
    }
}