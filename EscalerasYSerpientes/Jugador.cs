using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscalerasYSerpientes
{
    public class Jugador : IDibujable
    {
        public string nombre;
        public Casillero anterior;
        public Casillero actual;
        public Casillero siguiente;
        private Point offset; // provisoria
        private Color main;
        private Color second;
        public bool Ganador { get; set; }
        public int PartidosGanados { get; set; }
        public bool bloqueado = false;
        public bool muerto = false;
        public Panel panelDado;
        public int turnosAPerder = 0;
        public int picadurasVenenosas = 0;

        public Jugador(string nombre, int offsetX, int offsetY, Panel dado)
        {
            this.nombre = nombre;
            offset = new Point(offsetX, offsetY);
            main = Color.CadetBlue;
            second = Color.Blue;
            panelDado = dado;
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
        public void SetSecondColor(Color col)
        {
            second = col;
        }

        public void Draw(Graphics g)
        {
            Font font = new Font("Arial", 7, FontStyle.Bold);
            Point pf = new Point(actual.X+offset.X, actual.Y+offset.Y+13);
            g.FillEllipse(new SolidBrush(main), pf.X, pf.Y+3, 5, 5);
            g.DrawString(nombre, font, new SolidBrush(second), pf.X+5, pf.Y);
        }
    }
}
