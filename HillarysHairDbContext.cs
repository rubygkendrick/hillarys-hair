using Microsoft.EntityFrameworkCore;
using HillarysHair.Models;

public class HillarysHairDbContext : DbContext
{

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Service> Services { get; set; }

    public HillarysHairDbContext(DbContextOptions<HillarysHairDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<Appointment>().HasData(new Appointment[]
        {
        new Appointment
        {
            Id = 1,
            CustomerId = 2,
            StylistId = 1,
            Time = new DateTime(2024, 5, 10, 14, 30, 0),
            TotalCost = 100.00M,

        },
        new Appointment
        {
            Id = 2,
            CustomerId = 3,
            StylistId = 2,
            Time = new DateTime(2024, 5, 11, 14, 30, 0),
            TotalCost = 50.00M,
        },

        });

        modelBuilder.Entity<AppointmentService>().HasData(new AppointmentService[]
        {
            new AppointmentService
            {
                Id = 1,
                AppointmentId = 1,
                ServiceId = 2
            },
            new AppointmentService
            {
                Id = 2,
                AppointmentId = 1,
                ServiceId = 1
            },
            new AppointmentService
            {
                Id = 3,
                AppointmentId = 2,
                ServiceId = 2
            },
        });

        modelBuilder.Entity<Service>().HasData(new Service[]
        {
            new Service
            {
                Id = 1,
                Type = "color",
                Cost = 50.00M
            },
            new Service
            {
                Id = 2,
                Type = "cut",
                Cost = 50.00M
            },
            new Service
            {
                Id = 3,
                Type = "perm",
                Cost = 100.00M
            },
            new Service
            {
                Id = 4,
                Type = "wax",
                Cost = 75.00M
            },
        });
        modelBuilder.Entity<Customer>().HasData(new Customer[]
        {
            new Customer
            {
                Id = 1,
                Name = "Liz Earle",
                Phone = "555-555-5555"
            },
            new Customer
            {
                Id = 2,
                Name = "Ruby Kendrick",
                Phone = "123-555-4678"
            },
            new Customer
            {
                Id = 3,
                Name = "Nicolas Dobbratz",
                Phone = "615-777-9999"
            },

        });
        modelBuilder.Entity<Stylist>().HasData(new Stylist[]
        {
            new Stylist
            {
                Id = 1,
                Name = "Jill Silberstein",
                IsActive = true
            },
             new Stylist
            {
                Id = 2,
                Name = "Laura Solomon",
                IsActive = true
            },
            new Stylist
            {
                Id = 3,
                Name = "Michael Sadler",
                IsActive = true
            },
             new Stylist
            {
                Id = 4,
                Name = "Ziona Riley",
                IsActive = false
            },

        });
    }

}