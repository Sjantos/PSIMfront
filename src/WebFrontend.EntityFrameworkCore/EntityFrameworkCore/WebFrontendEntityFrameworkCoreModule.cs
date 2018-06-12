using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace WebFrontend.EntityFrameworkCore
{
    [DependsOn(
        typeof(WebFrontendCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class WebFrontendEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebFrontendEntityFrameworkCoreModule).GetAssembly());
        }
    }
}