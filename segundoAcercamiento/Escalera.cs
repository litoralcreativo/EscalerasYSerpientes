﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalerasYSerpientes
{
    class Escalera: Entidad
    {
        public Escalera(Casillero caveza, Casillero cola)
        {
            base.inicio = caveza;
            base.final = cola;
            base.colorCabeza = Color.DarkGreen;
            base.colorLinea = Color.Green;
            base.grosor = 3;
        }
    }
}
