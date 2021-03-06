using EscalerasYSerpientes.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscalerasYSerpientes
{
    public abstract class Tablero
    {
        public Casillero [] casilleros = new Casillero[100];
        public Jugador[] jugadores;
        public Graphics graficos;
        public ArrayList registro = new ArrayList();
        public int turno;
        public int dado;
        public Random random = new Random();
        public int animacionDelay;
        public bool animacionMover = false;
        public bool esSimulacion = false;
        public int ronda = 1;
        public bool ganador = false;
        protected int vueltaDados = 5;

        public Tablero(int width, int height, int jugadores)
        {
            this.jugadores = new Jugador[jugadores];
            int cellSize = width / 10;
            int contador = 0;
            for (int i = 0; i < 10; i++)
            {
                if (i%2 == 0)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        casilleros[contador] = new Casillero(j* cellSize, i* cellSize, cellSize, contador+1);
                        contador++;
                    }
                } else
                {
                    for (int j = 9; j >= 0 ; j--)
                    {
                        casilleros[contador] = new Casillero(j * cellSize, i * cellSize, cellSize, contador + 1);
                        contador++;
                    }
                }
            }
            turno = 0;
            animacionDelay = 100;
        }

        public void AgregarJugador(Jugador jugador)
        {
            jugador.picadurasVenenosas = 0;
            jugador.muerto = false;
            jugador.turnosAPerder = 0;
            bool asignado = false;
            int i = 0;
            while (i < jugadores.Length && !asignado)
            {
                if (jugadores[i] == null)
                {
                    jugadores[i] = jugador;
                    jugador.actual = casilleros[0];
                    asignado = true;
                }
                i++;
            }
        }
        public void Reset()
        {
            foreach (Jugador jugador in jugadores)
            {
                jugador.Mover(casilleros[0]);
            }
        }

        protected void AñadirSeparador()
        {
            registro.Add(""); // separador
            registro.Add("----------Ronda " + ronda + "----------"); // separador
        }
        protected void AñadirRegistro(params string [] text)
        {

            registro.Add(string.Concat(text));
        }

        protected void AñadirRegistro(string nombre, int dado, int casilleroInicial, int casilleroFinal, string entidad = "")
        {
            string log;
            if (entidad == "")
            {
                log = String.Format("Turno: {0} - Dado: {1} - Casilleros: {2:D2} al {3:D2}", nombre, dado, casilleroInicial, casilleroFinal);
            } else
            {
                log = String.Format("Turno: {0} - Dado: {1} - Casilleros: {2:D2} al {3:D2} - {4}", nombre, dado, casilleroInicial, casilleroFinal, entidad);
            }
            registro.Add(log);
        }
        protected void AñadirRegistro(string nombre, int dado, int casilleroInicial, int casilleroFinal, int seises)
        {
            string log = String.Format("Turno: {0} - Dado: {1} - Casilleros: {2:D2} al {3:D2} - Seises: {4}", nombre, dado, casilleroInicial, casilleroFinal, seises);
            registro.Add(log);
        }
        protected void AñadirRegistro(string nombre, string estado, int picaduras = 0)
        {
            if (picaduras == 0)
            {
                string log = String.Format("Turno: {0} - Estado: {1}", nombre, estado);
                registro.Add(log);
            } else
            {
                string log = String.Format("Turno: {0} - Estado: {1} - Picaduras: {2}", nombre, estado, picaduras);
                registro.Add(log);
            }

        }

        protected void Roll()
        {
            if (animacionMover)
            {
                Panel pnlDado = jugadores[turno].panelDado;
                if (pnlDado != null)
                {
                    for (int i = 0; i < vueltaDados; i++)
                    {
                        dado = random.Next(1, 7);
                        switch (dado)
                        {
                            case 1:
                                pnlDado.BackgroundImage = Resources._1;
                                break;
                            case 2:
                                pnlDado.BackgroundImage = Resources._2;
                                break;
                            case 3:
                                pnlDado.BackgroundImage = Resources._3;
                                break;
                            case 4:
                                pnlDado.BackgroundImage = Resources._4;
                                break;
                            case 5:
                                pnlDado.BackgroundImage = Resources._5;
                                break;
                            case 6:
                                pnlDado.BackgroundImage = Resources._6;
                                break;
                        }
                        pnlDado.Refresh();
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    dado = random.Next(1, 7);
                }
            } 
            else
            {
                dado = random.Next(1, 7);
            }
        }
        
        protected virtual void Mover()
        {
            int casInicial = jugadores[turno].actual.NroCasillero;
            Jugador jugador = (Jugador)jugadores[turno];
            if (!jugador.bloqueado && !jugador.muerto)
            {
                if (jugador.actual.NroCasillero + dado < 100)
                {
                    int actual = jugador.actual.NroCasillero;
                    Casillero cas = casilleros[actual - 1 + dado];
                    if (animacionMover)
                    {
                        bool casilleroAcasillero = true;
                        
                        /* Si queremos que se mueva casillero por casillero */
                        if (casilleroAcasillero)
                        {
                            for (int i = 1; i <= dado; i++)
                            {
                                cas = casilleros[actual - 1 + i];
                                jugador.Mover(cas);
                                if (!esSimulacion) Draw();
                            }
                        } 
                        /*Si queremos que salte al casillero que le toco*/
                        else
                        {
                            jugador.Mover(cas);
                        }

                    }
                    else
                    {
                        jugador.Mover(cas);
                    }
                } else
                {
                    jugador.Mover(casilleros[99]);
                    jugador.Ganador = true;
                    ganador = true;
                    jugador.PartidosGanados++;
                }
            }
            int casFinal = jugadores[turno].actual.NroCasillero;
            AñadirRegistro(jugador.nombre, dado, casInicial, casFinal);
        }
        public virtual void Draw()
        {
            if (animacionMover) Thread.Sleep(animacionDelay);
            graficos.Clear(Color.White);
            for (int i = 0; i < casilleros.Length; i++)
            {
                Casillero cas = casilleros[i];
                cas.Draw(graficos);
            }
            foreach (Jugador jugador in jugadores)
            {
                jugador.Draw(graficos);
            }
        }
        
        protected abstract void Jugar();

        public void SimularJuego()
        {
            while (!ganador)            // mientras no tengamos ganador, simular
            {
                SimularRonda();
            }
            if (esSimulacion) Draw();
        }
        public void SimularRonda()
        {
            int i = 0;
            AñadirSeparador();
            ronda++;
            while (i < jugadores.Length && !ganador)
            {
                turno = i;
                Jugar();
                i++;
            }
        }
    }
}
