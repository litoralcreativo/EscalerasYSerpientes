using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscalerasYSerpientes
{
    public partial class FormElegirJuego : Form
    {
        public FormElegirJuego()
        {
            InitializeComponent();
        }

        public int juego = 1;

        private void rbLvl1_CheckedChanged(object sender, EventArgs e)
        {
            juego = 1;
        }

        private void rbLvl2_CheckedChanged(object sender, EventArgs e)
        {
            juego = 2;

        }

        private void rbLvl3_CheckedChanged(object sender, EventArgs e)
        {
            juego = 3;
        }
    }
}
