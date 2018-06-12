using Abp.AspNetCore.Mvc.Controllers;

namespace WebFrontend.Web.Controllers
{
    public abstract class WebFrontendControllerBase: AbpController
    {
        protected WebFrontendControllerBase()
        {
            LocalizationSourceName = WebFrontendConsts.LocalizationSourceName;
        }
    }
}