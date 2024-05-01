using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL
{
    public static class Inyeccion
    {
        public static IServiceCollection AddLabCEServices
    (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISeguridadBLL, SeguridadBLL>();

            return services;
        }

    }
}
