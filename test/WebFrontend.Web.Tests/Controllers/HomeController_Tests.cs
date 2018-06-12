using System.Threading.Tasks;
using WebFrontend.Web.Controllers;
using Shouldly;
using Xunit;

namespace WebFrontend.Web.Tests.Controllers
{
    public class HomeController_Tests: WebFrontendWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
