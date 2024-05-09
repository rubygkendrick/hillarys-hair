using HillarysHair.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using HillarysHair.Models.DTOS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillarysHairDbContext>(builder.Configuration["HillarysHairDbConnectionString"]);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//write an endpoint that gets all the stylists
app.MapGet("/api/stylists", (HillarysHairDbContext db) =>
{
    return db.Stylists.Select(s => new StylistDTO
    {
        Id = s.Id,
        Name = s.Name,
        IsActive = s.IsActive
    });

});

//write an endpoint that will change a stylists isActive status 
app.MapPut("/api/stylists/{id}/status", (HillarysHairDbContext db, int id) =>
{
    Stylist stylistToUpdate = db.Stylists.Single(s => s.Id == id);

    if (stylistToUpdate == null)
    {
        return Results.NotFound();
    }
    if (stylistToUpdate.IsActive == false)
    {
        stylistToUpdate.IsActive = true;
    }
    else
    {
        stylistToUpdate.IsActive = false;
    }

    db.SaveChanges();
    return Results.Ok(stylistToUpdate);
});

// write an endpoint that gets all the appointments and thei associated services
app.MapGet("/api/appointments", (HillarysHairDbContext db) =>
{

    return db.Appointments
      .Include(a => a.AppointmentServices) // Include AppointmentServices
          .ThenInclude(aps => aps.Service)    // ThenInclude Services
      .Select(a => new AppointmentDTO
      {
          Id = a.Id,
          CustomerId = a.CustomerId,
          Customer = new CustomerDTO
          {
              Id = a.Customer.Id,
              Name = a.Customer.Name,
              Phone = a.Customer.Phone
          },
          StylistId = a.StylistId,
          Stylist = new StylistDTO
          {
              Id = a.Stylist.Id,
              Name = a.Stylist.Name,
              IsActive = a.Stylist.IsActive
          },
          Time = a.Time,
          TotalCost = a.TotalCost,
          Services = a.AppointmentServices.Select(aps => new ServiceDTO
          {
              Id = aps.Service.Id,
              Type = aps.Service.Type,
              Cost = aps.Service.Cost
          }).ToList()
      });

});



app.Run();
