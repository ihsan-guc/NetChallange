using Microsoft.EntityFrameworkCore;
using NetChallange.Data.Domain.Entities;
using System.Reflection;

namespace NetChallange.DAL
{
    public class NetChallangeContext : DbContext
    {
        public NetChallangeContext(DbContextOptions<NetChallangeContext> options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
