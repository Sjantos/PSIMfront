using Microsoft.EntityFrameworkCore;

namespace WebFrontend.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<WebFrontendDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for WebFrontendDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
