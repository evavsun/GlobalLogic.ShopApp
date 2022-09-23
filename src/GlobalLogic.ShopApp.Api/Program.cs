using Autofac;
using Autofac.Extensions.DependencyInjection;
using GlobalLogic.ShopApp.Application.Identity.Models;
using GlobalLogic.ShopApp.Infrastructure;
using GlobalLogic.ShopApp.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add services to the container.
builder.Services.AddAppDbContext(builder.Configuration.GetConnectionString("Dev"));

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new ApplicationModule());
    containerBuilder.RegisterModule(new InfrastructureModule());
});

builder.Services.AddAuthentication(builder.Configuration.GetSection("Jwt").Get<JwtOptions>());

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
