using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalerasYSerpientes
{
    public abstract class Entidad : IDibujable
    {
        public Color colorLinea;
        public Color colorCabeza;
        public int grosor = 2;
        public Casillero [] casilleros = new Casillero[2];
        public Casillero inicio
        {
            get
            {
                return casilleros[0];
            }
            set
            {
                casilleros[0] = value;
            }
        }
        public Casillero final
        {
            get
            {
                return casilleros[1];
            }
            set
            {
                casilleros[1] = value;
            }
        }
        public void Draw(Graphics g)
        {
            Point startPoint = new Point(inicio.centroX(), inicio.centroY());
            Point endPoint = new Point(final.centroX(), final.centroY());
            g.DrawLine(new Pen(colorLinea, grosor), startPoint, endPoint);
            g.DrawEllipse(new Pen(colorCabeza, grosor*2), startPoint.X - grosor, startPoint.Y - grosor, grosor * 2, grosor * 2);
        }
    }
}
