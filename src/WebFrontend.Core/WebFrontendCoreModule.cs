using Abp.Modules;
using Abp.Reflection.Extensions;
using WebFrontend.Localization;

namespace WebFrontend
{
    public class WebFrontendCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            WebFrontendLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebFrontendCoreModule).GetAssembly());
        }
    }
}