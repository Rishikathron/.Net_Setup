using Microsoft.EntityFrameworkCore;
using Sample_API.DataModel;

namespace Sample_API
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Students> Students { get; set; } 

       //public Students Students { get; set; }

    }
}
