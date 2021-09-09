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
        public ArrayList entidades = new ArrayList();
        public Graphics graficos;
        public Jugador[] jugadores;
        public ArrayList registro = new ArrayList();
        public int turno;
        public int dado;
        public Random random = new Random();
        public int animacionDelay;
        public bool animacionMover = false;
        public bool esSimulacion = false;
        public int ronda = 1;

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
        

        public void Roll(int num, Panel pnlDado)
        {
            for (int i = 0; i < num; i++)
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
        public virtual void Play()
        {
            Jugador jugador = (Jugador)jugadores[turno];
            if (jugador.actual.NroCasillero + dado < 100)
            {
                int actual = jugador.actual.NroCasillero;
                Casillero cas = casilleros[actual - 1 + dado];
                if (animacionMover)
                {
                    for (int i = 1; i <= dado; i++)
                    {
                        cas = casilleros[actual - 1 + i];
                        //jugador.anterior = jugador.actual;
                        jugador.Mover(cas);
                        if (!esSimulacion) Draw();
                    }
                }
                else
                {
                    //jugador.anterior = jugador.actual;
                    jugador.Mover(cas);
                }
            } else
            {
                //jugador.anterior = jugador.actual;
                jugador.Mover(casilleros[99]);
                jugador.Ganador = true;
            }
        }
        public virtual void Draw()
        {
            if (animacionMover) Thread.Sleep(animacionDelay);
            graficos.Clear(Color.White);
            foreach (Jugador jugador in jugadores)
            {
                jugador.Draw(graficos);
            }
            for (int i = 0; i < casilleros.Length; i++)
            {
                Casillero cas = casilleros[i];
                cas.Draw(graficos);
            }
            
        }

        public abstract void SimularJuego();
        public abstract void SimularRonda(int girosDelDado, Panel[] panelesDeDados);

    }
}
