using EcoMonitor.Api.Data;
using EcoMonitor.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EcoMonitor.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EnergyUsageDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
            builder.Services.AddScoped<IAlertRepository, AlertRepository>();
            builder.Services.AddScoped<IEnergyUsageRepository, EnergyUsageRepository>();

            builder.Services.AddScoped<Services.DeviceService>();
            builder.Services.AddScoped<Services.AlertService>();
            builder.Services.AddScoped<Services.ReportService>();

            builder.Services.AddControllers();
            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
