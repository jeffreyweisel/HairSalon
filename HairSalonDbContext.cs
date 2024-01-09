using Microsoft.EntityFrameworkCore;
using Salon.Models;

public class HairSalonDbContext : DbContext
{
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
   

    public HairSalonDbContext(DbContextOptions<HairSalonDbContext> context) : base(context)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // stylist seed data
        modelBuilder.Entity<Stylist>().HasData(new Stylist[]
        {
            new Stylist { Id = 1, FirstName = "Will", LastName = "Johnson", Email = "will@example.com", Address = "123 Main Street", IsActive = true },
            new Stylist { Id = 2, FirstName = "Chloe", LastName = "Smith", Email = "chloe@example.com", Address = "321 This Street", IsActive = true },
            new Stylist { Id = 3, FirstName = "Mckenzie", LastName = "Stewart", Email = "mckenzie@example.com", Address = "456 That Street", IsActive = true },
            new Stylist { Id = 4, FirstName = "Hillary", LastName = "West", Email = "hillary@example.com", Address = "789 Other Street", IsActive = true },
            new Stylist { Id = 5, FirstName = "Ethan", LastName = "Watson", Email = "ethan@example.com", Address = "1011 Over Street", IsActive = true },

        });

        // customer seed data
        modelBuilder.Entity<Customer>().HasData(new Customer[]
        {
            new Customer { Id = 1, FirstName = "Dwight", LastName = "Schrute", Email = "dwight@example.com", Address = "123 Main Street" },
            new Customer { Id = 2, FirstName = "Jim", LastName = "Halpert", Email = "jim@example.com", Address = "321 Oak Avenue" },
            new Customer { Id = 3, FirstName = "Michael", LastName = "Scott", Email = "mike@example.com", Address = "456 Oak Avenue" },
            new Customer { Id = 4, FirstName = "Stanley", LastName = "Hudson", Email = "stanley@example.com", Address = "456 Bark Street" },
            new Customer { Id = 5, FirstName = "Kelly", LastName = "Kapoor", Email = "kelly@example.com", Address = "222 Oak Avenue" },
            new Customer { Id = 6, FirstName = "Phyllis", LastName = "Vance", Email = "phyl@example.com", Address = "111 Oak Avenue" },
            new Customer { Id = 7, FirstName = "Jan", LastName = "Levinson", Email = "jan@example.com", Address = "899 Bark Street" }, 

        });

       // services seed data
        modelBuilder.Entity<Service>().HasData(new Service[]
        {
            new Service { Id = 1, Name = "Haircut" },
            new Service { Id = 2, Name = "Beard Trim"  },
            new Service { Id = 3, Name = "Hair Color" },
            new Service { Id = 4, Name = "Perm" },
            new Service { Id = 5, Name = "Hair Extensions" },

        });

        // appointment seed data
        modelBuilder.Entity<Appointment>().HasData(new Appointment[]
        {

        });


    }
}