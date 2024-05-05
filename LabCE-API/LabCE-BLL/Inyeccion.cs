using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using LabCE_DALSQL.Mapeo;
using LabCE_DALSQL;
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
        public static IServiceCollection AddLabCEServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISeguridadBLL, SeguridadBLL>();
            services.AddSingleton<IProfesorBLL, ProfesorBLL>();
            services.AddSingleton<ISolicitudActivoBLL, SolicitudActivoBLL>();
            services.AddSingleton<ILaboratorioBLL, LaboratorioBLL>();
            services.AddSingleton<IFacilidadBLL, FacilidadBLL>();
            services.AddSingleton<IActivoBLL, ActivoBLL>();
            services.AddSingleton<ITipoActivoBLL, TipoActivoBLL>();

            services.AddSingleton<ActivoDALSQL>();    
            services.AddSingleton<ProfesorDALSQL>();
            services.AddSingleton<SolicitudActivoDALSQL>();
            services.AddSingleton<LaboratorioDALSQL>();
            services.AddSingleton<FacilidadDALSQL>();
            services.AddSingleton<TipoActivoDALSQL>();

            services.AddAutoMapper(typeof(PerfilesMapeo));

            return services;
        }

    }
}
