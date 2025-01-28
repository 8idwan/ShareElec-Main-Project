using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShareElec.Repositories;
using SherElec_Back_end.Mapper; // Assure-toi que ce namespace est correct
using SherElec_Back_end.Model;
using SherElec_Back_end.Repositories;
using SherElec_Back_end.Services; // Assure-toi que ce namespace est correct pour les entités

var builder = WebApplication.CreateBuilder(args);

// Ajouter AutoMapper
builder.Services.AddAutoMapper(typeof(UserMapping).Assembly);


// Ajouter d'autres services ici
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Ajouter les contrôleurs
builder.Services.AddControllers();

// Ajouter Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurer la pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
