using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace WebFrontend
{
    [DependsOn(
        typeof(WebFrontendCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class WebFrontendApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebFrontendApplicationModule).GetAssembly());
        }
    }
}