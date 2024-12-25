using ComproPikoulasTest.Data;
using Microsoft.EntityFrameworkCore;
using ComproPikoulasTest.Business.Services;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Globalization;
using ComproPikoulasTest.API.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    // Use the default property (Pascal) casing
    options.SerializerSettings.Culture = new CultureInfo(string.Empty)
    {
        NumberFormat = new NumberFormatInfo
        {
            CurrencyDecimalDigits = 2
        }
    };
   // options.SerializerSettings.Converters.Add(new DecimalConverter());
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
}).AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ComproPikoulasTestDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:ComproPikoulasTest"]));



builder.Services.AddScoped<Validator, Validator>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();
var app = builder.Build();
using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ComproPikoulasTestDbContext>();

    // Check and apply pending migrations
    var pendingMigrations = dbContext.Database.GetPendingMigrations();
    if (pendingMigrations.Any())
    {
        Console.WriteLine("Applying pending migrations...");
        dbContext.Database.Migrate();
        Console.WriteLine("Migrations applied successfully.");
    }
    else
    {
        Console.WriteLine("No pending migrations found.");
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
