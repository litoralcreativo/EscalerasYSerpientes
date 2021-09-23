using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscalerasYSerpientes
{
    class Nivel3 : Nivel2
    {
        public Nivel3(int width, int height, int jugadores) : base(width, height, jugadores)
        {
            CrearEntidadesEspeciales(3);
        }

        public void CrearEntidadesEspeciales(int venenosas)
        {
            for (int i = 0; i < venenosas; i++)
            {
                int altura = 3;
                int inicioIndex = random.Next(4, 95); // 19 a 98
                int finIndex = inicioIndex - altura;

                while (casilleros[inicioIndex].TieneElemento || casilleros[finIndex].TieneElemento)
                {
                    inicioIndex = random.Next(19, 99);
                    finIndex = inicioIndex - altura;
                }

                Casillero inicio = casilleros[inicioIndex];
                inicio.TieneElemento = true;
                Casillero fin = casilleros[finIndex];
                fin.TieneElemento = true;

                Venenosa ven = new Venenosa(inicio, fin);
                entidades.Add(ven);
                inicio.entidad = ven;
                inicio.EsInicio = true;
            }
        }

        public override void Jugar()
        {
            if (!checkMuerto())
            {
                if (checkTurnoPerdido())
                {
                    seises = 0;
                    Roll();
                    if (!CheckBloqueo())
                    {
                        Mover();
                        if (!CheckCasillero())
                        {
                            CheckDado();
                        }
                    }
                }
                RandomizarVenenosas();
            }
        }

        private void RandomizarVenenosas()
        {
            for (int i = 0; i < entidades.Count; i++)
            {
                if (entidades[i] is Venenosa)
                {
                    Venenosa v = (Venenosa)entidades[i];
                    
                    // se habilitan nuevamente los casilleros
                    v.inicio.TieneElemento = false;
                    v.final.TieneElemento = false;
                    v.inicio.entidad = null;
                    v.inicio.EsInicio = false;

                    int inicioIndex = random.Next(4, 95); // 19 a 98
                    int finIndex = inicioIndex - 3;
                    while (casilleros[inicioIndex].TieneElemento 
                            || casilleros[finIndex].TieneElemento 
                            || getJugadorEnCasillero(casilleros[inicioIndex]))
                    {
                        inicioIndex = random.Next(19, 99);
                        finIndex = inicioIndex - 3;
                    }

                    casilleros[inicioIndex].TieneElemento = true;
                    casilleros[finIndex].TieneElemento = true;
                    casilleros[inicioIndex].entidad = v;
                    casilleros[inicioIndex].EsInicio = true;
                    v.ReSpawn(casilleros[inicioIndex], casilleros[finIndex]);
                }
            }
        }

        private bool getJugadorEnCasillero (Casillero inicio)
        {
            bool jugadorEnCasillero = false;
            for (int i = 0; i < jugadores.Length; i++)
            {
                if (jugadores[i].actual == inicio) jugadorEnCasillero = true;
            }
            return jugadorEnCasillero;
        }

        // si devolvemos true podemos continuar el juego, es decir el jugador no tiene turno perdido
        private bool checkTurnoPerdido()
        {
            int turnosAPerder = jugadores[turno].turnosAPerder;
            if (turnosAPerder > 0)
            {
                AñadirRegistro(jugadores[turno].nombre, "Turno perdido");
                jugadores[turno].turnosAPerder--;
            }

            return turnosAPerder == 0;
        }

        // si devolvemos true es por que el jugador esta muerto
        private bool checkMuerto()
        {
            bool muerto = jugadores[turno].muerto;
            if (muerto)
            {
                AñadirRegistro(jugadores[turno].nombre, "Jugador Muerto");
            }
            return muerto;
        }

        public override bool CheckCasillero()
        {
            Jugador jugador = jugadores[turno];
            if (jugador.actual.EsInicio)
            {
                if (jugador.actual.entidad is Venenosa)
                {
                    jugador.turnosAPerder = 1;
                    jugador.picadurasVenenosas += 1;
                    casInicial = jugador.actual.entidad.inicio.NroCasillero;
                    casFinal = jugador.actual.entidad.final.NroCasillero;
                    AñadirRegistro("Venenosa (x, ,x) ", casInicial.ToString(), " al ", casFinal.ToString(), " - Picaduras: ", jugador.picadurasVenenosas.ToString());
                    AñadirRegistro("");
                    if (jugador.picadurasVenenosas == 3)
                    {
                        jugador.muerto = true;
                    }
                    jugador.Mover(jugador.actual.entidad.final);
                    if (!esSimulacion) Draw();
                } else
                {
                    base.CheckCasillero();
                }
            }
            return jugador.actual.EsInicio;
        }
    }
}
