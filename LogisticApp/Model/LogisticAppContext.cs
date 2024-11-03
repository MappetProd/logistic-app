using Microsoft.EntityFrameworkCore;

namespace LogisticApp.Model
{
    public class LogisticAppContext : DbContext
    {
        //public static readonly string connectionString = "server=127.0.0.1;uid=root;pwd=сдфыы123;database=logistic_app;port=3306;GuidFormat=Binary16;";
        private readonly IConfiguration _configuration;

        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets{ get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Postcode> Postcodes { get; set; }
        public DbSet<StreetType> StreetTypes { get; set; }

        public LogisticAppContext()
        {
            Database.EnsureCreated();
        }

        public LogisticAppContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connectionString = $"server={_configuration["DB_HOST"]};" +
                $"uid=root;" +
                $"pwd={_configuration["DB_PASSWORD"]};" +
                $"database=logistic_app;" +
                $"port={_configuration["DB_PORT"]};" +
                $"GuidFormat=Binary16;";

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Postcode>().HasIndex(p => p.Code).IsUnique();


            /*modelBuilder.Entity<City>()
                .HasMany(c => c.Streets)
                .WithOne(s => s.City)
                .HasForeignKey(s => s.CityId)
                .IsRequired();

            modelBuilder.Entity<Street>()
                .HasMany(s => s.Houses)
                .WithOne(h => h.Street)
                .HasForeignKey(h => h.StreetId)
                .IsRequired();*/

            /*modelBuilder.Entity<Order>()
                .HasOne(o => o.SenderAdress)
                .WithMany(a => a.Orders);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.RecipientAddress)
                .WithMany(a => a.Orders);*/
        }
    }
}
