﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.Modelos
{
    public class Facilidad
    {
        public string NombreLab { get; set; }
        public string NombreFacilidad { get; set; }
        public Laboratorio Laboratorio { get; set; }
    }
}
