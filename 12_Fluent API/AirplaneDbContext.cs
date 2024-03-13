using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Fluent_API
{
    internal class AirplaneDbContext : DbContext
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
    public class Airplane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassanger { get; set; }
        //Navigation properties
        //Relational type : Many to Many (*....*)
        public ICollection<Flight> Flights { get; set; }
    }

    //Entities
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }//not null ===> null
        //Navigation properties

        //Relational type : Many to Many (*....*)
        public ICollection<Flight> Flights { get; set; }
        public Credentials Credentials { get; set; }
    }
    public class Flight
    {
        //Primary key naming : Id/id/ID / EntityName+Id = FlightId
        public int Number { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        //Navigation properties
        //Relational type : One to Many (1....*)
        //Foreign key naming : RelatedEntityName + RelatedEntityPrimaryKeyName
        public int AirplaneId { get; set; }//foreign key
        public Airplane Airplane { get; set; }//null
                                              //Relational type : Many to Many (*....*)

        //Navigation properties
        public ICollection<Client> Clients { get; set; }

    }
    public class Credentials
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? ClientId { get; set; }
        // one to one
        public Client Client { get; set; }
    }
}
