using Microsoft.EntityFrameworkCore;

namespace WebApiApp.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
    }
}
