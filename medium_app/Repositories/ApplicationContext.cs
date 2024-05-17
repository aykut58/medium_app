using medium_app.Models;
using Microsoft.EntityFrameworkCore;

namespace medium_app.Repositories
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-NIT9CTB\\SQLEXPRESS; Database= MediumApp; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User>  Users { get; set; }
    }
}
