﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.Modelos
{
    public class AdministracionActivos
    {
        public string CorreoAdministrador { get; set; }
        public string PlacaActivo { get; set; }
        public Activo Activo { get; set; }
        public Administrador Administrador { get; set; }

    }
}
