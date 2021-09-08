using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalerasYSerpientes
{
    public class Jugador
    {
        public string nombre;
        Color color;
        public Casillero anterior;
        public Casillero actual;
        public Casillero siguiente;
        public Point offset;
        private Color main;
        private Color second;
        public bool Ganador { get; set; }
        public int PartidosGanados { get; set; }
        public bool bloqueado = false;

        public Jugador(string nombre, int offsetX, int offsetY)
        {
            this.nombre = nombre;
            color = Color.Blue;
            offset = new Point(offsetX, offsetY);
            main = Color.CadetBlue;
            second = Color.Blue;
        }

        public void Mover(Casillero hacia)
        {
            anterior = actual;
            siguiente = hacia;
            actual = siguiente;
            Ganador = actual.NroCasillero == 100;
        }

        public void SetMainColor(Color col)
        {
            main = col;
        }
        public void SetSecond(Color col)
        {
            second = col;
        }

        public void Draw(Graphics g)
        {
            Font font = new Font("Arial", 7, FontStyle.Bold);
            Point pf = new Point(actual.X+offset.X+2, actual.Y+offset.Y+15);
            g.FillEllipse(new SolidBrush(main), pf.X, pf.Y, 12, 12);
            g.DrawString(nombre, font, new SolidBrush(second), pf.X+3, pf.Y+1);
        }
    }
}
