using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscalerasYSerpientes
{
    class Nivel2 : Tablero
    {
        public Nivel2(int width, int height, int jugadores) : base(width, height, jugadores)
        {
            CrearEntidades(random.Next(5, 10), random.Next(5, 8));
        }

        public void CrearEntidades(int serpientes, int escaleras)
        {
            for (int i = 0; i < escaleras; i++)
            {
                int inicioIndex = random.Next(1, 100 - 12);
                int altura = random.Next(3, 13);
                int finIndex = inicioIndex + altura;

                while (casilleros[inicioIndex].TieneElemento || casilleros[finIndex].TieneElemento)
                {
                    inicioIndex = random.Next(0, 100 - 12);
                    altura = random.Next(3, 13);
                    finIndex = inicioIndex + altura;
                }
                Casillero inicio = casilleros[inicioIndex];
                inicio.TieneElemento = true;
                Casillero fin = casilleros[finIndex];
                fin.TieneElemento = true;

                Escalera esc = new Escalera(inicio, fin);
                entidades.Add(esc);
                inicio.elemento = esc;
                inicio.EsInicio = true;
            }

            for (int i = 0; i < serpientes; i++)
            {
                int inicioIndex = random.Next(19, 100);
                int altura = random.Next(5, 19);
                int finIndex = inicioIndex - altura;

                while (casilleros[inicioIndex].TieneElemento || casilleros[finIndex].TieneElemento)
                {
                    inicioIndex = random.Next(19, 99);
                    altura = random.Next(5, 19);
                    finIndex = inicioIndex - altura;
                }

                Casillero inicio = casilleros[inicioIndex];
                inicio.TieneElemento = true;
                Casillero fin = casilleros[finIndex];
                fin.TieneElemento = true;

                Serpiente ser = new Serpiente(inicio, fin);
                entidades.Add(ser);
                inicio.elemento = ser;
                inicio.EsInicio = true;
            }
        }
        
        public override void SimularJuego()
        {
            bool ganador = false;
            int ganadorIndex = -1;
            animacionDelay = 0;
            animacionMover = false;

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
                    nombre = ((Jugador)jugadores[i]).nombre;
                    nombre = nombre == "J" ? "HUMAN" : ("COM " + nombre);
                    casInicial = ((Jugador)jugadores[i]).actual.NroCasillero;
                    penalizado = ((Jugador)jugadores[i]).bloqueado;
                    turno = i;
                    dado = random.Next(1, 7);
                    if (!penalizado || dado == 6)
                    {
                        ((Jugador)jugadores[i]).bloqueado = false;
                        Play();
                    }
                    casFinal = ((Jugador)jugadores[i]).actual.NroCasillero;
                    AñadirRegistro(nombre, dado, casInicial, casFinal);
                    ganador = ((Jugador)jugadores[i]).Ganador; // ver si tenemos ganador
                    while (dado == 6 && !penalizado && !ganador) // jugar otra vez en caso de sacar 6
                    {
                        casInicial = ((Jugador)jugadores[i]).actual.NroCasillero;
                        dado = random.Next(1, 7);
                        Play();
                        casFinal = ((Jugador)jugadores[i]).actual.NroCasillero;
                        ganador = ((Jugador)jugadores[i]).Ganador; // ver si tenemos ganador
                        
                        string ent = "";
                        if (((Jugador)jugadores[i]).anterior.EsInicio)
                        {
                            if (((Jugador)jugadores[i]).anterior.elemento is Serpiente)
                            {
                                ent = "Serpiente";
                            }
                            else if(((Jugador)jugadores[i]).anterior.elemento is Escalera)
                            {
                                ent = "Escalera";
                            }
                        }
                        AñadirRegistro(nombre, dado, casInicial, casFinal, ent);
                    }

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

            string nombre = "";
            int casInicial = 0;
            int casFinal = 0;

            int i = 0;
            AñadirSeparador();
            ronda++;
            while (i < jugadores.Length && !ganador)
            {
                nombre = ((Jugador)jugadores[i]).nombre;
                nombre = nombre == "J" ? "HUMAN" : ("COM " + nombre);
                
                casInicial = ((Jugador)jugadores[i]).actual.NroCasillero;
                turno = i;
                Roll(num, panels[i]);
                Play();
                casFinal = ((Jugador)jugadores[i]).actual.NroCasillero;
                ganador = ((Jugador)jugadores[i]).Ganador; // ver si tenemos ganador
                
                string ent = "";
                if (((Jugador)jugadores[i]).anterior.EsInicio)
                {
                    if (((Jugador)jugadores[i]).anterior.elemento is Serpiente)
                    {
                        ent = "Serpiente";
                    }
                    else if (((Jugador)jugadores[i]).anterior.elemento is Escalera)
                    {
                        ent = "Escalera";
                    }
                }
                AñadirRegistro(nombre, dado, casInicial, casFinal, ent);

                if (ganador) ganadorIndex = i;
                i++;
            }
            if (ganador) ((Jugador)jugadores[ganadorIndex]).PartidosGanados++;
        }

        public override void Play()
        {
            base.Play();
            Jugador jugador = (Jugador)jugadores[turno];
            if (jugador.actual.EsInicio)
            {
                //jugador.anterior = jugador.actual;
                jugador.Mover(jugador.siguiente.elemento.final);
                if (!esSimulacion) Draw();
            }
        }
        public override void Draw()
        {
            base.Draw();
            foreach (object elemento in entidades)
            {
                ((Entidad)elemento).Draw(graficos);
            }
        }

    }
}
