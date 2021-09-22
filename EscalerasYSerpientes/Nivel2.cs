using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscalerasYSerpientes
{
    class Nivel2 : Nivel1
    {
        protected ArrayList entidades = new ArrayList();

        public Nivel2(int width, int height, int jugadores) : base(width, height, jugadores)
        {
            CrearEntidades(random.Next(5, 10), random.Next(5, 8));
        }

        public void CrearEntidades(int serpientes, int escaleras)
        {
            for (int i = 0; i < escaleras; i++)
            {
                int inicioIndex = random.Next(1, 100 - 12); // 30
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
                inicio.entidad = esc;
                inicio.EsInicio = true;
            }

            for (int i = 0; i < serpientes; i++)
            {
                int inicioIndex = random.Next(19, 99); // 19 a 98
                int altura = random.Next(5, 19); // 5 a 18
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
                inicio.entidad = ser;
                inicio.EsInicio = true;
            }
        }

        public override void Jugar()
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

        public override void CheckDado()
        {
            Jugador jugador = jugadores[turno];
            if (dado == 6)
            {
                seises++;
                if (seises < 3)
                {
                    Roll();
                    Mover();
                    if (!CheckCasillero())
                    {
                        CheckDado();
                    }
                }
                else
                {
                    jugador.bloqueado = true;
                    casInicial = jugadores[turno].actual.NroCasillero;
                    jugador.Mover(casilleros[0]);
                    casFinal = jugador.actual.NroCasillero;
                    AñadirRegistro(jugador.nombre, dado, casInicial, casFinal);
                }
            }
        }

        public override void Draw()
        {
            base.Draw();
            foreach (IDibujable elemento in entidades)
            {
                elemento.Draw(graficos);
            }
        }
        
        public virtual bool CheckCasillero()
        {
            Jugador jugador = jugadores[turno];
            if (jugador.actual.EsInicio)
            {
                casInicial = jugador.actual.entidad.inicio.NroCasillero;
                casFinal = jugador.actual.entidad.final.NroCasillero;
                string tipoEntida = "";
                if (jugador.actual.entidad is Escalera)
                {
                    tipoEntida = "Escalera =====";
                }
                else if (jugador.actual.entidad is Serpiente)
                {
                    tipoEntida = "Serpiente (°, ,°)";
                }

                AñadirRegistro(tipoEntida, " ", casInicial.ToString(), " al ", casFinal.ToString());
                AñadirRegistro("");

                jugador.Mover(jugador.actual.entidad.final);
                if (!esSimulacion) Draw();
            }
            return jugador.actual.EsInicio;
        }
    }
}
