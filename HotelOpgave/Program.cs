using HotelOpgave;
using HotelOpgave.Interfaces;
using HotelOpgave.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using (IHost host = CreateDefaultHost(args).Build())
{
    using (IServiceScope scope = host.Services.CreateScope())
    {
        IServiceProvider serviceProvider = scope.ServiceProvider;

        try
        {
            serviceProvider.GetRequiredService<App>().Run(args);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

static IHostBuilder CreateDefaultHost(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton<App>();
            services.AddSingleton<Menu>();
            services.AddDbContext<HotelDbContext>(options =>
            {
                options.UseSqlServer(context.Configuration.GetConnectionString("HotelDb"), options =>
                {
                    options.EnableRetryOnFailure();
                });
                options.EnableSensitiveDataLogging();
            });
            services.AddTransient<IFacilityService, FacilityService>();
        })
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders();
        });
}