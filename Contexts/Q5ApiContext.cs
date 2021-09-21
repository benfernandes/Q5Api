using Microsoft.EntityFrameworkCore;
using Q5Api.Models;

namespace Q5Api.Contexts
{
    public class Q5ApiContext : DbContext
    {
        public Q5ApiContext(DbContextOptions<Q5ApiContext> options) : base(options)
        {

        }

        public DbSet<Queue> Queues { get; set; }
    }
}