using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MornrideApi.Application.Interfaces;
using MornrideApi.Application.Services;
using MornrideApi.Data.Context;
using Newtonsoft.Json;
using Redis.OM;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(connectionString);
});

// Add services to the container.

builder.Services.AddScoped<IBikeService, BikeService>();
builder.Services.AddScoped<IImagesService, ImagesService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBikeImageService, BikeImageService>();
builder.Services.AddScoped<IBikeCategoryService, BikeCategoryService>();
builder.Services.AddScoped<IBannerImageService, BannerImageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICachingService, CachingService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddUnitOfWork<DataContext>();

const bool USING_REDIS_SERVICE = false;

if(USING_REDIS_SERVICE)
{
    string redisConnectionString = builder.Configuration["REDIS_CONNECTION_STRING"];
    builder.Services.AddSingleton(new RedisConnectionProvider(redisConnectionString));
    builder.Services.AddHostedService<IndexCreationService>();
}


builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
