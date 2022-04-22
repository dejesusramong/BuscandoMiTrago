using AccesoADatos.Generico;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BuscandoMiTrago.Extensiones
{
    ///control de inversion
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inyectar los servicios del repositorio génerico
            services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));

            return services;
        }
    }
}
