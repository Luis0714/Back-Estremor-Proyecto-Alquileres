using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository.Implementation;
using Shared.Services;
using Shared.Services.Implementation;

namespace Persistence
{
    public static class ServiceExtension
    {
        public static void AddPersistenseInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)
            ));
            services.AddDbContext<RolDbContext>(options => options.UseSqlServer(
              configuration.GetConnectionString("DefaultConnection"),
              b => b.MigrationsAssembly(typeof(RolDbContext).Assembly.FullName)
          ));
            services.AddTransient<IDateTimeService, DateTimeService>();
            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(MyRepositoryAsync<>));
            services.AddTransient(typeof(IRolRepository<>), typeof(RolRepository<>));
            #endregion

            var serviceProvider = services.BuildServiceProvider();
            try
            {
                var dbContext = serviceProvider.GetRequiredService<ApplicationDBContext>();
                dbContext.Database.Migrate();
            }
            catch
            {

            }
        }
    }
}
