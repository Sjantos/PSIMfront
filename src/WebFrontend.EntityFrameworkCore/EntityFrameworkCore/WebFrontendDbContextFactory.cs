using WebFrontend.Configuration;
using WebFrontend.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebFrontend.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class WebFrontendDbContextFactory : IDesignTimeDbContextFactory<WebFrontendDbContext>
    {
        public WebFrontendDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WebFrontendDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(WebFrontendConsts.ConnectionStringName)
            );

            return new WebFrontendDbContext(builder.Options);
        }
    }
}