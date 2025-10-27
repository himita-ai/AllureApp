
using AllureApp.Core.DBContext;
using AllureApp.Core.Entities;
using AllureApp.Repository;
using AllureApp.Repository.Implementation;
using AllureApp.Repository.Interface;
using AllureApp.Service.Implementation;
using AllureApp.Service.Interface;
using AllureStore.Core.Entities;
using AllureStore.Repository.Implementation;
using AllureStore.Repository.Interface;
using AllureStore.Service.Implementation;
using AllureStore.Service.Interface;
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

            // Entities
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<AdminNavItem>, Repository<AdminNavItem>>();
            services.AddScoped<IRepository<AdminRole>, Repository<AdminRole>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<SubCategory>, Repository<SubCategory>>();




            // Repo
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();



            //Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RolesService>();
            services.AddScoped<IProductService, ProductService>();

        }
    }
}
