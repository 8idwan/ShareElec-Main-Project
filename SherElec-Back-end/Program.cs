using Microsoft.EntityFrameworkCore;
using SherElec_Back_end.Data;
using SherElec_Back_end.Mappers;
using SherElec_Back_end.Repositories.Interfaces;
using SherElec_Back_end.Repositories;
using SherElec_Back_end.Services.Interfaces;
using SherElec_Back_end.Services;


var builder = WebApplication.CreateBuilder(args);

// Ajouter la configuration CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

// Ajouter le DbContext avec la chaine de connexion
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<IOffreRepository, OffreRepository>();
builder.Services.AddScoped<IOffreService, OffreService>();

// Configuration de AutoMapper
builder.Services.AddAutoMapper(typeof(OffreMappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAll");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (context.Database.CanConnect())
    {
        Console.WriteLine("Connexion reussie !");
    }
    else
    {
        Console.WriteLine("Connexion echouee !");
    }
}


app.Run();
