using data_access_fluentApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace data_access_fluentApi
{
    public class AirplaneDbContext : DbContext
    {
        public AirplaneDbContext()
        {
            this.Database.EnsureCreated();
        }
        //Collections
        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Airplane> Credentials { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-83U7DVV\SQLEXPRESS;
                                        Initial Catalog = NewAirplanePD321;
                                        Integrated Security=True;
                                        Connect Timeout=2;Encrypt=False;
                                         Trust Server Certificate=False;
                                        Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Fluent API configuration

            modelBuilder.Entity<Client>().ToTable("Passangers");
            modelBuilder.Entity<Client>()
                .Property(c => c.Name)
                .IsRequired() // not null
                .HasMaxLength(100) // nvarchar(100)
                .HasColumnName("FirstName");
            modelBuilder.Entity<Client>()
                .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Airplane>()
                .Property(c=>c.Model)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Flight>().HasKey(c => c.Number);
            modelBuilder.Entity<Flight>()
                .Property(c => c.DepartureCity)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Flight>()
                .Property(c => c.ArrivalCity)
                .IsRequired()
                .HasMaxLength(100);

            // One to many (1 ..... *)
            modelBuilder.Entity<Flight>()
                .HasOne(f=>f.Airplane)
                .WithMany(a=>a.Flights)
                .HasForeignKey(f => f.AirplaneId);

            // many to many (*......*)
            modelBuilder.Entity<Flight>()
                .HasMany(a => a.Clients)
                .WithMany(c => c.Flights);
            // one to one
            modelBuilder.Entity<Credentials>()
                .HasOne(c => c.Client)
                .WithOne(c => c.Credentials)
                .HasForeignKey<Credentials>(c => c.ClientId);


            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFlights();
            modelBuilder.SeedCredentials();
            modelBuilder.SeedClients();
        }
    }
}
