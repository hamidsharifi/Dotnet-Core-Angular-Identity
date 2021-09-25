using Avery.LabelManager.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avery.LabelManager.DAL.Core
{
    public static class Configuration
    {
        public static IServiceCollection AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AveryDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AveryLabelManager"), b => b.MigrationsAssembly("Avery.LabelManager")));

            // add identity
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<AveryDbContext>()
                .AddDefaultTokenProviders();
            
            return services
                .AddScoped<AveryDbContext, AveryDbContext>();

        }
    }
}
