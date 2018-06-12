using Abp.Application.Services;

namespace WebFrontend
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class WebFrontendAppServiceBase : ApplicationService
    {
        protected WebFrontendAppServiceBase()
        {
            LocalizationSourceName = WebFrontendConsts.LocalizationSourceName;
        }
    }
}