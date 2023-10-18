using DAL.Models;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;
using DAL.Implementaciones;

namespace BLL
{
    public static class Dependencia
    {
        public static void Inyeccion(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<AtomContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICompraRepo, CompraRepo>();
            services.AddScoped<IDetalleCompraRepo, DetalleCompraRepo>();
            services.AddScoped<IProductoRepo, ProductoRepo>();
            
        }
    }
}