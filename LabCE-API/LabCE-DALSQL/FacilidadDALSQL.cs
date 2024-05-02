using AutoMapper;
using LabCE_MODEL.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_DALSQL
{
    public class FacilidadDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public FacilidadDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

       
    }
}
