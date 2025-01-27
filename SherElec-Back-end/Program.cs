using Microsoft.EntityFrameworkCore;
using SherElec_Back_end.Data;
using SherElec_Back_end.Mappers;
using SherElec_Back_end.Repositories.Interfaces;
using SherElec_Back_end.Repositories;
using SherElec_Back_end.Services.Interfaces;
using SherElec_Back_end.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);



// Add services to the container.
builder.Services.AddScoped<IOffreRepository, OffreRepository>();
builder.Services.AddScoped<IOffreService, OffreService>();

// Configuration de AutoMapper
builder.Services.AddAutoMapper(typeof(OffreMappingProfile));


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
