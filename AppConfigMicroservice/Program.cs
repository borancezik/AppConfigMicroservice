using AppConfigMicroservice.Common.Behaviors;
using AppConfigMicroservice.Common.Services.CacheService;
using AppConfigMicroservice.DataAccess;
using AppConfigMicroservice.Features.Config;
using AppConfigMicroservice.Features.Config.Command;
using AppConfigMicroservice.Features.Config.Data;
using AppConfigMicroservice.Features.Config.Query;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IConfigRepository, ConfigRepository>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
builder.Services.AddTransient<IValidator<ConfigQuery>, ConfigQueryValidator>();
builder.Services.AddTransient<IValidator<ConfigCommand>, ConfigCommandValidator>();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

ConfigsController.MapEndpoints(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
