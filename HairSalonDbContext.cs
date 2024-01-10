using Microsoft.EntityFrameworkCore;
using Salon.Models;

public class HairSalonDbContext : DbContext
{
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }
   

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
            new Service { Id = 1, Name = "Haircut", Price = 24.99M },
            new Service { Id = 2, Name = "Beard Trim", Price = 19.99M  },
            new Service { Id = 3, Name = "Hair Color", Price = 49.99M },
            new Service { Id = 4, Name = "Perm", Price = 69.99M },
            new Service { Id = 5, Name = "Hair Extensions", Price = 99.99M },

        });

        // appointment seed data
        modelBuilder.Entity<Appointment>().HasData(new Appointment[]
        {
            new Appointment { Id = 1, CustomerId = 2, StylistId = 1, AppointmentTime = new DateTime(2024, 01, 12, 08, 00, 00) },
            new Appointment { Id = 2, CustomerId = 1, StylistId = 2, AppointmentTime = new DateTime(2024, 01, 11, 09, 00, 00) },
            new Appointment { Id = 3, CustomerId = 4, StylistId = 3, AppointmentTime = new DateTime(2024, 01, 13, 09, 00, 00) },
            new Appointment { Id = 4, CustomerId = 3, StylistId = 4, AppointmentTime = new DateTime(2024, 01, 12, 10, 00, 00) },
        });

        // appointment service seed data
     modelBuilder.Entity<AppointmentService>().HasData(new AppointmentService[]
        {
            new AppointmentService { Id = 1, AppointmentId = 1, ServiceId = 2},
            new AppointmentService { Id = 2, AppointmentId = 1, ServiceId = 1},
            new AppointmentService { Id = 3, AppointmentId = 2, ServiceId = 3},
            new AppointmentService { Id = 4, AppointmentId = 3, ServiceId = 2},
            new AppointmentService { Id = 5, AppointmentId = 4, ServiceId = 4},
            new AppointmentService { Id = 6, AppointmentId = 3, ServiceId = 2},
            new AppointmentService { Id = 7, AppointmentId = 4, ServiceId = 2},
        });

    }
}