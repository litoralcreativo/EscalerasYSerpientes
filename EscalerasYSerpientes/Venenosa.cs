using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EscalerasYSerpientes
{
    class Venenosa : Entidad
    {
        public Venenosa(Casillero caveza, Casillero cola)
        {
            base.inicio = caveza;
            base.final = cola;
            base.colorCabeza = Color.PaleVioletRed;
            base.colorLinea = Color.MediumVioletRed;
        }

        public void ReSpawn(Casillero caveza, Casillero cola)
        {
            base.inicio = caveza;
            base.final = cola;
        }
    }
}
