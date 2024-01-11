using Salon.Models;
using Salon.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HairSalonDbContext>(builder.Configuration["HairSalonDbConnectionString"]);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// TO-DO: Make AppointmentService class, add seed data to DbContext, Make new migration, update endpoints from service to AppointmentService



// Get all stylists
app.MapGet("/api/stylists", (HairSalonDbContext db) =>
{
    return db.Stylists
       .Include(s => s.Appointments)
        .ThenInclude(a => a.Customer)  
        .Include(s => s.Appointments)
        .ThenInclude(a => a.Services)
        .ThenInclude(s => s.Service)
        .Select(s => new StylistDTO
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            Address = s.Address,
            IsActive = s.IsActive,
            Appointments = s.Appointments.Select(a => new AppointmentDTO
            {
                Id = a.Id,
                CustomerId = a.CustomerId,
                Customer = new CustomerDTO
                {
                    Id = a.Customer.Id,
                    FirstName = a.Customer.FirstName,
                    LastName = a.Customer.LastName,
                    Email = a.Customer.Email,
                    Address = a.Customer.Address
                },
                AppointmentTime = a.AppointmentTime,
                Services = a.Services.Select(s => new AppointmentServiceDTO
                {
                    Id = s.Id,
                    ServiceId = s.ServiceId,
                    Service = new ServiceDTO
                    {
                        Id = s.Service.Id,
                        Name = s.Service.Name
                    }

                }).ToList()
                
            }).ToList()
        })
        .ToList();
});

// Get stylist by Id
app.MapGet("/api/stylists/{id}", (HairSalonDbContext db, int id) =>
{
    return db.Stylists
       .Include(s => s.Appointments)
        .ThenInclude(a => a.Customer)  
        .Include(s => s.Appointments)
        .ThenInclude(a => a.Services)
        .ThenInclude(s => s.Service)
        .Select(s => new StylistDTO
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            Address = s.Address,
            IsActive = s.IsActive,
            Appointments = s.Appointments.Select(a => new AppointmentDTO
            {
                Id = a.Id,
                CustomerId = a.CustomerId,
                Customer = new CustomerDTO
                {
                    Id = a.Customer.Id,
                    FirstName = a.Customer.FirstName,
                    LastName = a.Customer.LastName,
                    Email = a.Customer.Email,
                    Address = a.Customer.Address
                },
                AppointmentTime = a.AppointmentTime,
                Services = a.Services.Select(s => new AppointmentServiceDTO
                {
                    Id = s.Id,
                    ServiceId = s.ServiceId,
                    Service = new ServiceDTO
                    {
                        Id = s.Service.Id,
                        Name = s.Service.Name
                    }

                }).ToList()
            }).ToList()
        })
        .SingleOrDefault(s => s.Id == id);
});

// Add stylist
app.MapPost("/api/stylists", (HairSalonDbContext db, Stylist newStylist) =>
{
    try
    {
        newStylist.IsActive = true;
        db.Stylists.Add(newStylist);
        db.SaveChanges();
        return Results.Created($"/stylists/{newStylist.Id}", newStylist);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid data submitted");
    }
});

// Deactivate stylist
app.MapPut("/api/stylists/deactivate/{id}", (HairSalonDbContext db, int id, Stylist stylist) =>
{
    Stylist stylistToUpdate = db.Stylists.SingleOrDefault(patron => patron.Id == id);
    if (stylistToUpdate == null)
    {
        return Results.NotFound();
    }

    stylistToUpdate.IsActive = false;
    // stylistToUpdate.Appointments = null;

    db.SaveChanges();
    return Results.Ok(stylistToUpdate);
});

// Get all customers 
app.MapGet("/api/customers", (HairSalonDbContext db) =>
{
    return db.Customers
       .Include(s => s.Appointments)
        .ThenInclude(a => a.Stylist)  
        .Include(s => s.Appointments)
        .ThenInclude(a => a.Services)
        .ThenInclude(s => s.Service)
        .Select(s => new CustomerDTO
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            Address = s.Address,
            Appointments = s.Appointments.Select(a => new AppointmentDTO
            {
                Id = a.Id,
                StylistId = a.StylistId,
                Stylist = new StylistDTO
                {
                    Id = a.Stylist.Id,
                    FirstName = a.Stylist.FirstName,
                    LastName = a.Stylist.LastName,
                    Email = a.Stylist.Email,
                    Address = a.Stylist.Address,
                    IsActive = a.Stylist.IsActive
                },
                AppointmentTime = a.AppointmentTime,
                Services = a.Services.Select(s => new AppointmentServiceDTO
                {
                    Id = s.Id,
                    ServiceId = s.ServiceId,
                    Service = new ServiceDTO
                    {
                        Id = s.Service.Id,
                        Name = s.Service.Name
                    }

                }).ToList()
            }).ToList()
        })
        .ToList();
});

// Get customer by Id
app.MapGet("/api/customers/{id}", (HairSalonDbContext db, int id) =>
{
    return db.Customers
       .Include(c => c.Appointments)
        .ThenInclude(a => a.Stylist)  
        .Include(c => c.Appointments)
        .ThenInclude(a => a.Services)
        .ThenInclude(s => s.Service)
        .Select(c => new CustomerDTO
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            Address = c.Address,
            Appointments = c.Appointments.Select(a => new AppointmentDTO
            {
                Id = a.Id,
                StylistId = a.CustomerId,
                Stylist = new StylistDTO
                {
                    Id = a.Stylist.Id,
                    FirstName = a.Stylist.FirstName,
                    LastName = a.Stylist.LastName,
                    Email = a.Stylist.Email,
                    Address = a.Stylist.Address,
                    IsActive = a.Stylist.IsActive
                },
                AppointmentTime = a.AppointmentTime,
                Services = a.Services.Select(s => new AppointmentServiceDTO
                {
                    Id = s.Id,
                    ServiceId = s.ServiceId,
                    Service = new ServiceDTO
                    {
                        Id = s.Service.Id,
                        Name = s.Service.Name
                    }

                }).ToList()
            }).ToList()
        })
        .FirstOrDefault(c => c.Id == id);
});

// Add customer
app.MapPost("/api/customers", (HairSalonDbContext db, Customer newCustomer) =>
{
    try
    {
        db.Customers.Add(newCustomer);
        db.SaveChanges();
        return Results.Created($"/stylists/{newCustomer.Id}", newCustomer);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid data submitted");
    }
});

// Get all appointments
app.MapGet("/api/appointments", (HairSalonDbContext db) =>
{
    return db.Appointments
        .Include(a => a.Stylist)
        .Include(a => a.Customer)
        .Include(a => a.Services)
        .Select(p => new AppointmentDTO
        {
            Id = p.Id,
            CustomerId = p.CustomerId,
            Customer = new CustomerDTO
            {
                Id = p.Customer.Id,
                FirstName = p.Customer.FirstName,
                LastName = p.Customer.LastName,
                Email = p.Customer.Email,
                Address = p.Customer.Address,
            },
            StylistId = p.StylistId,
            Stylist = new StylistDTO
            {
                Id = p.Stylist.Id,
                FirstName = p.Stylist.FirstName,
                LastName = p.Stylist.LastName,
                Email = p.Stylist.Email,
                Address = p.Stylist.Address,
                IsActive = p.Stylist.IsActive
            },
            Services = p.Services.Select(s => new AppointmentServiceDTO
            {
                Id = s.Id,
                ServiceId = s.ServiceId,
                Service = new ServiceDTO
                {
                    Id = s.Service.Id,
                    Name = s.Service.Name,
                    Price = s.Service.Price
                }
            }).ToList(),
            AppointmentTime = p.AppointmentTime

        })
        .ToList();
});

// Get appointment by Id
app.MapGet("/api/appointments/{id}", (HairSalonDbContext db, int id) =>
{
    return db.Appointments
        .Include(a => a.Stylist)
        .Include(a => a.Customer)
        .Include(a => a.Services)
        .Select(p => new AppointmentDTO
        {
            Id = p.Id,
            CustomerId = p.CustomerId,
            Customer = new CustomerDTO
            {
                Id = p.Customer.Id,
                FirstName = p.Customer.FirstName,
                LastName = p.Customer.LastName,
                Email = p.Customer.Email,
                Address = p.Customer.Address,
            },
            StylistId = p.StylistId,
            Stylist = new StylistDTO
            {
                Id = p.Stylist.Id,
                FirstName = p.Stylist.FirstName,
                LastName = p.Stylist.LastName,
                Email = p.Stylist.Email,
                Address = p.Stylist.Address,
                IsActive = p.Stylist.IsActive
            },
            Services = p.Services.Select(s => new AppointmentServiceDTO
            {
                Id = s.Id,
                ServiceId = s.ServiceId,
                Service = new ServiceDTO
                {
                    Id = s.Service.Id,
                    Name = s.Service.Name,
                    Price = s.Service.Price
                }
            }).ToList(),
            AppointmentTime = p.AppointmentTime

        })
        .FirstOrDefault(a => a.Id == id);
});

// Create appointment
app.MapPost("/api/appointments", (HairSalonDbContext db, Appointment newAppointment) =>
{

    try
    {
       
    //    newAppointment.AppointmentTime = DateTime.Now.AddDays(10);
        db.Appointments.Add(newAppointment);
        db.SaveChanges();
        return Results.Created($"/appointments/{newAppointment.Id}", newAppointment);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid data submitted");
    }
});

// Add services to created appointment
app.MapPost("/api/appointmentservices", (HairSalonDbContext db, AppointmentService newAppointmentService) =>
{

    try
    {

        db.AppointmentServices.Add(newAppointmentService);
        db.SaveChanges();
        return Results.Created($"/appointmentservices/{newAppointmentService.Id}", newAppointmentService);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Invalid data submitted");
    }
});

// Delete services previously added to appointment
app.MapDelete("/api/appointmentservices/{id}", (HairSalonDbContext db, int id) =>
{
    AppointmentService service = db.AppointmentServices.SingleOrDefault(aserv => aserv.Id == id);
    if (service == null)
    {
        return Results.NotFound();
    }
    db.AppointmentServices.Remove(service);
    db.SaveChanges();
    return Results.Ok(service);

});

// Get all appointment services
app.MapGet("/api/appointmentservices", (HairSalonDbContext db) =>
{
    return db.AppointmentServices
    .Select(c => new AppointmentServiceDTO
    {
        Id = c.Id,
        ServiceId = c.ServiceId,
        AppoinmentId = c.AppointmentId,
        Service = new ServiceDTO
        {
            Id = c.Service.Id,
            Name = c.Service.Name,
            Price = c.Service.Price
        }
    }).ToList();
});

// Get all services
app.MapGet("/api/services", (HairSalonDbContext db) =>
{
    return db.Services
    .Select(c => new ServiceDTO
    {
        Id = c.Id,
        Name = c.Name,
        Price = c.Price,
        
    }).ToList();
});

// Delete an appointment
app.MapDelete("/api/appointments/{id}", (HairSalonDbContext db, int id) =>
{
    Appointment appointment = db.Appointments.SingleOrDefault(a => a.Id == id);
    if (appointment == null)
    {
        return Results.NotFound();
    }
    db.Appointments.Remove(appointment);
    db.SaveChanges();
    return Results.Ok(appointment);

});

app.Run();

