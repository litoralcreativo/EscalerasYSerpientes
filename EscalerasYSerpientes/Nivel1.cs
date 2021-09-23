using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscalerasYSerpientes
{
    public class Nivel1 : Tablero
    {
        protected int seises;
        protected int casInicial;
        protected int casFinal;
        public Nivel1(int width, int height, int jugadores) : base(width, height, jugadores)
        {

        }

        protected override void Jugar()
        {
            seises = 0;
            Roll();
            if (!CheckBloqueo())
            {
                CheckDado();
            }
        }
        protected bool CheckBloqueo()
        {
            bool unlocked = false;
            if (jugadores[turno].bloqueado && dado == 6)
            {
                jugadores[turno].bloqueado = false;
                Mover();
                unlocked = true;
            }
            return unlocked;
        }
        protected virtual void CheckDado()
        {
            Jugador jugador = jugadores[turno];
            if (dado == 6)
            {
                seises++;
                if (seises < 3)
                {
                    Mover();
                    Roll();
                    CheckDado();
                } else
                {
                    jugadores[turno].bloqueado = true;
                    casInicial = jugadores[turno].actual.NroCasillero;
                    jugador.Mover(casilleros[0]);
                    casFinal = jugadores[turno].actual.NroCasillero;
                    AñadirRegistro(jugador.nombre, dado, casInicial, casFinal);
                }
            } else
            {
                Mover();
            }
        }
        
    }
}
