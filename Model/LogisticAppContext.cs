using Microsoft.EntityFrameworkCore;

namespace LogisticApp.Model
{
    public class LogisticAppContext : DbContext
    {
        public static readonly string connectionString = "server=127.0.0.1;uid=root;pwd=сдфыы123;database=logistic_app;port=3306;GuidFormat=Binary16;";

        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets{ get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Building> Buildings{ get; set; }

        public LogisticAppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
