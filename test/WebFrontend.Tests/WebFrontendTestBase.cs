using System;
using System.Threading.Tasks;
using Abp.TestBase;
using WebFrontend.EntityFrameworkCore;
using WebFrontend.Tests.TestDatas;

namespace WebFrontend.Tests
{
    public class WebFrontendTestBase : AbpIntegratedTestBase<WebFrontendTestModule>
    {
        public WebFrontendTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<WebFrontendDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<WebFrontendDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<WebFrontendDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<WebFrontendDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<WebFrontendDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<WebFrontendDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<WebFrontendDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<WebFrontendDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
