using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalerasYSerpientes
{
    class Serpiente: Entidad
    {
        public Serpiente(Casillero caveza, Casillero cola)
        {
            base.inicio = caveza;
            base.final = cola;
            base.colorCabeza = Color.LightPink;
            base.colorLinea = Color.LightPink;
        }
    }
}
