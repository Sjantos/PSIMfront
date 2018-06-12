using Abp.Application.Navigation;
using Abp.Localization;

namespace WebFrontend.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class WebFrontendNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("Posts"),
                        url: "",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.AddPost,
                        L("AddPost"),
                        url: "Home/CreatePost"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "Home/About",
                        icon: "fa fa-info"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, WebFrontendConsts.LocalizationSourceName);
        }
    }
}
