using EscalerasYSerpientes.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscalerasYSerpientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        
        Jugador[] jugadores;
        Tablero tablero;
        Graphics g;

        private void Form1_Load(object sender, EventArgs e)
        {

            g = panelGraficos.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;

            FormElegirJugadores ej = new FormElegirJugadores();
            int virtuales = 1;
            if (ej.ShowDialog() == DialogResult.OK)
            {
                virtuales = Convert.ToInt32(ej.nudVirtuales.Value);
            }

            // crear jugadores para AGREGARLOS
            jugadores = new Jugador[virtuales + 1];
            Panel[] dados = { panelDado1, panelDado2, panelDado3, panelDado4 };
            Jugador humano = new Jugador("HUMAN", 10, 0, dados[0]);
            jugadores[0] = humano;
            for (int i = 1; i <= virtuales; i++)
            {
                
                jugadores[i] = new Jugador("COM "+i.ToString(), 10, 10 * i, dados[i]); ;
                jugadores[i].SetMainColor(Color.Red);
                jugadores[i].SetSecondColor(Color.DarkRed);
            }
            Reset();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            Draw();
        }

        public void Draw()
        {
            tablero.Draw();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        
        private void Reset()
        {
            int lvl = 1;
            int virtuales = jugadores.Length;
            bool simulacion = false;
            FormElegirJuego nuevo = new FormElegirJuego();
            if (nuevo.ShowDialog() == DialogResult.OK)
            {
                lvl = nuevo.juego;
                simulacion = nuevo.cbSimulacion.Checked;
            }
            switch (lvl)
            {
                case 1:
                    tablero = new Nivel1(600, 600, virtuales);
                    break;
                case 2:
                    tablero = new Nivel2(600, 600, virtuales);
                    break;
                case 3:
                    tablero = new Nivel3(600, 600, virtuales);
                    break;

            }
            tablero.graficos = g;

            for (int i = 0; i < jugadores.Length; i++)
            {
                tablero.AgregarJugador(jugadores[i]);
            }
            
            tablero.Reset();
            
            lbRegistro.Items.Clear();
            
            if (!simulacion)
            {
                btnSimular.Enabled = false;
                btnMover.Enabled = true;
                tablero.animacionMover = true;
                tablero.animacionDelay = 100;
                tablero.esSimulacion = false;
            }
            else
            {
                btnSimular.Enabled = true;
                btnMover.Enabled = false;
                tablero.animacionMover = false;
                tablero.animacionDelay = 0;
                tablero.esSimulacion = true;
            }
            Draw();
        }

        private void btnMover_Click(object sender, EventArgs e)
        {
            btnMover.Enabled = false;
            Panel[] p = { panelDado1, panelDado2, panelDado3, panelDado4 };
            tablero.SimularRonda();
            btnMover.Enabled = true;
            lbRegistro.Items.Clear();
            foreach (object item in tablero.registro)
            {
                lbRegistro.Items.Add(item);
            }
            lblGanados1.Text = ((Jugador)tablero.jugadores[0]).PartidosGanados.ToString();
            lblGanados2.Text = ((Jugador)tablero.jugadores[1]).PartidosGanados.ToString();
            if (tablero.jugadores.Length >= 3) lblGanados3.Text = ((Jugador)tablero.jugadores[2]).PartidosGanados.ToString();
            if (tablero.jugadores.Length  == 4) lblGanados4.Text = ((Jugador)tablero.jugadores[3]).PartidosGanados.ToString();
            Draw();
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            tablero.SimularJuego();
            foreach (object item in tablero.registro)
            {
                lbRegistro.Items.Add(item);
            }
            btnSimular.Enabled = false;
            lblGanados1.Text = ((Jugador)tablero.jugadores[0]).PartidosGanados.ToString();
            lblGanados2.Text = ((Jugador)tablero.jugadores[1]).PartidosGanados.ToString();
            if (tablero.jugadores.Length >= 3) lblGanados3.Text = ((Jugador)tablero.jugadores[2]).PartidosGanados.ToString();
            if(tablero.jugadores.Length == 4) lblGanados4.Text = ((Jugador)tablero.jugadores[3]).PartidosGanados.ToString();
            Draw();
        }
    }
}
