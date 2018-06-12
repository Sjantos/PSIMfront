using Abp.AspNetCore.Mvc.Views;

namespace WebFrontend.Web.Views
{
    public abstract class WebFrontendRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected WebFrontendRazorPage()
        {
            LocalizationSourceName = WebFrontendConsts.LocalizationSourceName;
        }
    }
}
