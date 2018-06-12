using WebFrontend.EntityFrameworkCore;

namespace WebFrontend.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly WebFrontendDbContext _context;

        public TestDataBuilder(WebFrontendDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}