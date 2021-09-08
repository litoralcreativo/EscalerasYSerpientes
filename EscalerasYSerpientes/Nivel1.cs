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
        public Nivel1(int width, int height, int jugadores) : base(width, height, jugadores)
        {

        }

        public override void SimularJuego()
        {
            bool ganador = false;
            int ganadorIndex = -1;
            animacionDelay = 0;
            animacionMover = false;

            int six = 0;                // numero de seises
            string nombre = "";         // nombre del jugador
            int casInicial = 0;         // casillero inicial
            int casFinal = 0;           // casillero final
            bool penalizado = false;    // si fue penalizado

            while (!ganador)            // mientras no tengamos ganador, simular
            {
                int i = 0;
                AñadirSeparador();
                ronda++;
                while (i < jugadores.Length && !ganador)
                {
                    six = 0;
                    nombre = ((Jugador)jugadores[i]).nombre;
                    nombre = nombre == "J" ? "HUMAN" : ("COM " + nombre);
                    casInicial = ((Jugador)jugadores[i]).actual.NroCasillero;
                    penalizado = ((Jugador)jugadores[i]).bloqueado;
                    turno = i;
                    dado = random.Next(1, 7);
                    six += dado == 6 ? 1 : 0;
                    if (!penalizado || dado == 6)
                    {
                        ((Jugador)jugadores[i]).bloqueado = false;
                        Play();
                    }
                    casFinal = ((Jugador)jugadores[i]).actual.NroCasillero;

                    AñadirRegistro(nombre, dado, casInicial, casFinal, six);

                    ganador = ((Jugador)jugadores[i]).Ganador; // ver si tenemos ganador
                    while (dado == 6 && !penalizado && !ganador) // jugar otra vez en caso de sacar 6
                    {
                        casInicial = ((Jugador)jugadores[i]).actual.NroCasillero;
                        dado = random.Next(1, 7);
                        six += dado == 6 ? 1 : 0;
                        if (six == 3)
                        {
                            penalizado = true; // si salieron 3 veces 6 penalizar
                            ((Jugador)jugadores[i]).bloqueado = true;
                            casFinal = 1;
                        }
                        else
                        {
                            Play();
                            casFinal = ((Jugador)jugadores[i]).actual.NroCasillero;
                        }
                        ganador = ((Jugador)jugadores[i]).Ganador; // ver si tenemos ganador
                        
                        AñadirRegistro(nombre, dado, casInicial, casFinal, six);
                    }
                    if (penalizado) ((Jugador)jugadores[i]).Mover(casilleros[0]); // si fue penalizado mover al casillero inicial
                    if (ganador) ganadorIndex = i;
                    i++;
                }
            }
            if (esSimulacion) Draw();
            ((Jugador)jugadores[ganadorIndex]).PartidosGanados++;
        }
        public override void SimularRonda(int num, Panel[] panels)
        {
            bool ganador = false;
            int ganadorIndex = -1;

            int six = 0;
            string nombre = "";
            int casInicial = 0;
            int casFinal = 0;
            bool penalizado = false;

            int i = 0;
            AñadirSeparador();
            ronda++;
            while (i < jugadores.Length && !ganador)
            {
                six = 0;
                nombre = ((Jugador)jugadores[i]).nombre;
                nombre = nombre == "J" ? "HUMAN" : ("COM " + nombre);
                casInicial = ((Jugador)jugadores[i]).actual.NroCasillero;
                penalizado = ((Jugador)jugadores[i]).bloqueado;
                turno = i;
                Roll(num, panels[i]);
                six += dado == 6 ? 1 : 0;
                if (!penalizado || dado == 6)
                {
                    ((Jugador)jugadores[i]).bloqueado = false;
                    Play();
                }
                casFinal = ((Jugador)jugadores[i]).actual.NroCasillero;

                AñadirRegistro(nombre, dado, casInicial, casFinal, six);

                ganador = ((Jugador)jugadores[i]).Ganador; // ver si tenemos ganador
                while (dado == 6 && !penalizado && !ganador) // jugar otra vez en caso de sacar 6
                {
                    casInicial = ((Jugador)jugadores[i]).actual.NroCasillero;
                    Roll(num, panels[i]);
                    six += dado == 6 ? 1 : 0;
                    if (six == 3)
                    {
                        penalizado = true; // si salieron 3 veces 6 penalizar
                        casFinal = 1;
                    }
                    else
                    {
                        Play();
                        casFinal = ((Jugador)jugadores[i]).actual.NroCasillero;
                    }
                    ganador = ((Jugador)jugadores[i]).Ganador; // ver si tenemos ganador

                    AñadirRegistro(nombre, dado, casInicial, casFinal, six);
                }

                if (penalizado) ((Jugador)jugadores[i]).Mover(casilleros[0]); // si fue penalizado mover al casillero inicial
                if (ganador) ganadorIndex = i;
                i++;
            }
            if (ganador) ((Jugador)jugadores[ganadorIndex]).PartidosGanados++;
        }
    }
}
