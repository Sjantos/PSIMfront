using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebFrontend.EntityFrameworkCore
{
    public class WebFrontendDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public WebFrontendDbContext(DbContextOptions<WebFrontendDbContext> options) 
            : base(options)
        {

        }
    }
}
