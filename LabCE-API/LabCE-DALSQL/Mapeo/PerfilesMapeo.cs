using AutoMapper;
using LabCE_MODEL.DTOs;
using LabCE_MODEL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_DALSQL.Mapeo
{
    public class PerfilesMapeo : Profile
    {
        public PerfilesMapeo() 
        {
            CreateMap<Profesor, ProfesorDTO>();
            CreateMap<SolicitudActivo, SolicitudPendienteDTO>();
        }
    }
}
