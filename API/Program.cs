using API.Middlewares;
using Core.Interfaces;
using Data.Contexts;
using Infrastructure.Logging;
using Infrastructure.Repositories;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Service.Services;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            //Configure Serilog With the settings
            //Log.Logger = new LoggerConfiguration()
            //            .WriteTo.Console()
            //            .MinimumLevel.Information()
            //            .Enrich.FromLogContext()
            //            .CreateBootstrapLogger();


            try
            {
                var builder = WebApplication.CreateBuilder(args);

                //builder.Services.AddApplicationInsightsTelemetry();


                //builder.Host.UseSerilog(
                //(context, services, loggerconfiguration) => loggerconfiguration.WriteTo
                //.ApplicationInsights(services.GetRequiredService<TelemetryConfiguration>(), TelemetryConverter.Events));


                Log.Information("Starting the Application...");

                // Add services to the container.

                builder.Services.AddDbContext<RestaurantAppDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration
                        .GetConnectionString("DefaultConnectionString"))
                        .EnableSensitiveDataLogging();
                });


                builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
                builder.Services.AddScoped<IRestaurantService, RestaurantService>();
                builder.Services.AddSingleton(typeof(ILoggerAdapter<>),typeof(SerilogAdapter<>));
                builder.Services.AddScoped<IFileService, FileService>();
                builder.Services.AddScoped<SeedService>();

                builder.Services.AddControllers();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                var app = builder.Build();

                using (var scope = app.Services.CreateScope())
                {
                    var seedService = scope.ServiceProvider.GetRequiredService<SeedService>();
                    await seedService.SeedDataAsync();
                }

                // Configure the HTTP request pipeline.
                //if (app.Environment.IsDevelopment())
                app.UseMiddleware<ExceptionHandlingMiddleware>();

                {
                app.UseSwagger();
                app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application startup failed.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
