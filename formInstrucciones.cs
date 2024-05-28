using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocoMomo
{
    public partial class formInstrucciones : Form
    {

        FormPrincipal formularioPrincipal;
        public formInstrucciones(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            formularioPrincipal = formPrincipal;
        }

        private void formInstrucciones_Load(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            formularioPrincipal.Show();
            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
