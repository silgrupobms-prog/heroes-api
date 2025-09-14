using Heroes.Database;
using Heroes.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Services;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICreateHeroeService, CreateHeroeService>();
builder.Services.AddScoped<IGetHeroeService, GetHeroesService>();
builder.Services.AddScoped<IDeleteHeroeService, DeleteHeroeService>();
builder.Services.AddScoped<IGetHeroeByIdService, GetHeroeByIdService>();
builder.Services.AddScoped<IUpdateHeroeService, UpdateHeroeService>();
builder.Services.AddScoped<IHeroPowerRepository, HeroPowerRepository>();
builder.Services.AddScoped<IHeroPowerService, HeroPowerService>();
builder.Services.AddScoped<IHeroesRepository, HeroesRepository>();
builder.Services.AddDbContext<HeroesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgresql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
