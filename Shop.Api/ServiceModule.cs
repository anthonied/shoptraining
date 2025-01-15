using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.DomainServices;

namespace Shop.Api
{
    public class ServicesModule : IModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductDomainService, ProductDomainService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<ShopContext>();
            dbContext.Database.Migrate();
        }
    }
    public interface IModule
    {
        void ConfigureServices(IServiceCollection services);
        void Configure(IApplicationBuilder app);
    }
}

