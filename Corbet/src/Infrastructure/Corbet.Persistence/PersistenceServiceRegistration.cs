using Corbet.Application.Contracts.Persistence;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Persistence.Repositories;
using Corbet.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Corbet.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ITaxRepository, TaxRepository>();
            services.AddScoped<ITaxDetailsRepository, TaxDetailsRepository>();
            services.AddScoped<IUnitMeasurementRepository, UnitMeasurementRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IAuthenticationServiceLogin, AuthenticationServiceLogin>();

            return services;
        }
    }
}
