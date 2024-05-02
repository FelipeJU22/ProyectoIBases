using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_DALSQL
{
    public class ProfesorDALSQL
    {
        private readonly IConfiguration _configuration;

        public ProfesorDALSQL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
