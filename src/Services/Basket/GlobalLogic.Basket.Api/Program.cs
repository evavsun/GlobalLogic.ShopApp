var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient<OrderingProcessService>();

builder.Services.Configure<BasketSettings>(builder.Configuration);

builder.Services.AddScoped<IBasketRepository, RedisBasketRepository>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddSingleton<ConnectionMultiplexer>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<BasketSettings>>().Value;
    var configuration = ConfigurationOptions.Parse(settings.ConnectionString, true);

    return ConnectionMultiplexer.Connect(configuration);
});

var x = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();

builder.Services.AddJwtAuthentication(builder.Configuration.GetSection("Jwt").Get<JwtOptions>());

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

