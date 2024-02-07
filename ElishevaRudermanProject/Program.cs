using Data.Model;
using WebApi.Config;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.Configurations();
builder.Host.UseSerilog((context, configuration) =>
{

    ///קריאה של ההגדות מהקונפיd 
    configuration.ReadFrom.Configuration(context.Configuration);

});



builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        configuration.GetConnectionString("DietConnectionString"),
        x => x.MigrationsAssembly("WebApi")));
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
app.UseSerilogRequestLogging();

app.MapControllers();
app.UseMiddleware(typeof(MiddleWare));

app.Run();
