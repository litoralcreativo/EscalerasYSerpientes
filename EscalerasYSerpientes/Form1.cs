using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;

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
            lbRegistro.DrawMode = DrawMode.OwnerDrawFixed; // para poder dibujar en el listBox con estilos

            FormElegirJugadores ej = new FormElegirJugadores();
            int virtuales = 1;
            DialogResult respuesta = ej.ShowDialog();
            if (respuesta == DialogResult.Retry )
            {
                Demo();
            }
            else if (respuesta == DialogResult.OK)
            {
                virtuales = Convert.ToInt32(ej.nudVirtuales.Value);
                // crear jugadores para AGREGARLOS
                jugadores = new Jugador[virtuales + 1];
                Panel[] dados = { panelDado1, panelDado2, panelDado3, panelDado4 };
                Jugador humano = new Jugador("HUMAN", 10, 0, dados[0]);
                jugadores[0] = humano;
                for (int i = 1; i <= virtuales; i++)
                {

                    jugadores[i] = new Jugador("COM " + i.ToString(), 10, 10 * i, dados[i]); ;
                    jugadores[i].SetMainColor(Color.Red);
                    jugadores[i].SetSecondColor(Color.DarkRed);
                }
                Reset();
            } else
            {
                Close();
            }
        }

        private void Demo()
        {
            jugadores = new Jugador[2];
            Panel[] dados = { panelDado1, panelDado2, panelDado3, panelDado4 };
            Jugador humano = new Jugador("HUMAN", 10, 0, dados[0]);
            jugadores[0] = humano;
            jugadores[1] = new Jugador("COM 1", 10, 10, dados[1]); ;
            jugadores[1].SetMainColor(Color.Red);
            jugadores[1].SetSecondColor(Color.DarkRed);

            btnSimular.Enabled = false;
            btnReset.Enabled = false;
            btnMover.Enabled = false;
            btnDemo.Enabled = true;

            // NIVEL 1
            tablero = new Nivel1(600, 600, 2);
            tablero.graficos = g;
            tablero.AgregarJugador(jugadores[0]);
            tablero.AgregarJugador(jugadores[1]);
            tablero.Reset();
            lbRegistro.Items.Clear();
            
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
                tablero.animacionDelay = 200;
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
            Mover();
        }

        private void Mover()
        {
            btnMover.Enabled = false;
            Panel[] p = { panelDado1, panelDado2, panelDado3, panelDado4 };
            tablero.SimularRonda();
            btnMover.Enabled = true;
            lbRegistro.Items.Clear();
            foreach (string item in tablero.registro)
            {
                lbRegistro.Items.Add(item);
            }
            lbRegistro.PerformLayout();

            lblGanados1.Text = ((Jugador)tablero.jugadores[0]).PartidosGanados.ToString();
            lblGanados2.Text = ((Jugador)tablero.jugadores[1]).PartidosGanados.ToString();
            if (tablero.jugadores.Length >= 3) lblGanados3.Text = ((Jugador)tablero.jugadores[2]).PartidosGanados.ToString();
            if (tablero.jugadores.Length == 4) lblGanados4.Text = ((Jugador)tablero.jugadores[3]).PartidosGanados.ToString();
            Draw();
        }
        private void Simular()
        {
            tablero.SimularJuego();
            lbRegistro.Items.Clear();
            foreach (object item in tablero.registro)
            {
                lbRegistro.Items.Add(item);
            }
            btnSimular.Enabled = false;
            lbRegistro.Update();
            lblGanados1.Text = ((Jugador)tablero.jugadores[0]).PartidosGanados.ToString();
            lblGanados2.Text = ((Jugador)tablero.jugadores[1]).PartidosGanados.ToString();
            if (tablero.jugadores.Length >= 3) lblGanados3.Text = ((Jugador)tablero.jugadores[2]).PartidosGanados.ToString();
            if (tablero.jugadores.Length == 4) lblGanados4.Text = ((Jugador)tablero.jugadores[3]).PartidosGanados.ToString();
            Draw();
        }
        private void btnSimular_Click(object sender, EventArgs e)
        {
            Simular();
        }

        private void lbRegistro_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index != -1)
            {
                e.DrawBackground();
                Brush b = new SolidBrush(Color.Black);
                Brush back = new SolidBrush(Color.White);
                string text = lbRegistro.Items[e.Index].ToString();
                bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;


                // si esta seleccionado
                if (selected)
                {
                    if (text.Length >= 4)
                    {
                        string textStart = text.Substring(0, 4);
                        switch (textStart)
                        {
                            case "Esca":
                                back = new SolidBrush(Color.Green);
                                b = new SolidBrush(Color.White);
                                break;
                            case "Serp":
                                back = new SolidBrush(Color.Red);
                                b = new SolidBrush(Color.White);
                                break;
                            case "Vene":
                                back = new SolidBrush(Color.Purple);
                                b = new SolidBrush(Color.White);
                                break;
                            default:
                                back = new SolidBrush(Color.LightGray);
                                b = new SolidBrush(Color.Black);
                                break;
                        }
                    }
                } else
                {
                    if (text.Length >= 4)
                    {
                        string textStart = text.Substring(0, 4);
                        switch (textStart)
                        {
                            case "Esca":
                                b = new SolidBrush(Color.Black);
                                back = new SolidBrush(Color.LightGreen);
                                break;
                            case "Serp":
                                b = new SolidBrush(Color.Black);
                                back = new SolidBrush(Color.LightPink);
                                break;
                            case "Vene":
                                b = new SolidBrush(Color.Black);
                                back = new SolidBrush(Color.Plum);
                                break;
                            default:
                                back = new SolidBrush(Color.White);
                                b = new SolidBrush(Color.Black);
                                break;
                        }
                    }
                }
                e.Graphics.FillRectangle(back, e.Bounds);
                e.Graphics.DrawString(text, new Font(FontFamily.GenericMonospace, 10), b, e.Bounds);
                e.DrawFocusRectangle();
            }
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            // NIVEL 1
            tablero = new Nivel1(600, 600, 2);
            tablero.graficos = g;
            tablero.AgregarJugador(jugadores[0]);
            tablero.AgregarJugador(jugadores[1]);
            tablero.Reset();
            tablero.animacionMover = false;
            tablero.animacionDelay = 100;
            tablero.esSimulacion = true;

            Simular();
            Thread.Sleep(1000);

            // NIVEL 2
            tablero = new Nivel2(600, 600, 2);
            tablero.graficos = g;
            tablero.AgregarJugador(jugadores[0]);
            tablero.AgregarJugador(jugadores[1]);
            tablero.Reset();
            tablero.animacionMover = false;
            tablero.animacionDelay = 100;
            tablero.esSimulacion = true;

            Simular();
            Thread.Sleep(1000);

            // NIVEL 3
            tablero = new Nivel3(600, 600, 2);
            tablero.graficos = g;
            tablero.AgregarJugador(jugadores[0]);
            tablero.AgregarJugador(jugadores[1]);
            tablero.Reset();
            tablero.animacionMover = false;
            tablero.animacionDelay = 100;
            tablero.esSimulacion = true;

            Simular();
        }
    }
}
