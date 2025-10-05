
using AllureApp.Core.DBContext;
using AllureApp.Repository;
using AllureApp.Repository.Interface;
using AllureApp.Service.Implementation;
using AllureApp.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AllureApp.Services
{
    public static class ConfigureServices
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration config)
        {
            // DbContext
            services.AddDbContext<AllureAppContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Db_Connection")));

            // Repositories
            services.AddScoped<IUserRepo, UserRepo>();

            // Services
            services.AddScoped<IUserService, UserService>();
        }
    }
}
