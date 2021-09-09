using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalerasYSerpientes
{
    public class Casillero : IDibujable
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Size { get; private set; }
        public int NroCasillero { get; private set; }
        public bool TieneElemento { get; set; }
        public bool EsInicio { get; set; }

        public Entidad entidad;

        public Casillero(int x, int y, int size, int nro)
        {
            X = x;
            Y = y;
            Size = size;
            NroCasillero = nro;
            TieneElemento = false;
            EsInicio = false;
        }

        public int centroX()
        {
            return X + (Size/2);
        }

        public int centroY()
        {
            return Y + (Size / 2);
        }

        public void Draw(Graphics g)
        {
            Font font = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Gray);
            PointF pf = new PointF(X, Y);
            g.DrawRectangle(Pens.Black, X, Y, Size, Size);
            g.DrawString(NroCasillero.ToString(), font, drawBrush, pf);
        }
    }
}
