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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }
        


        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void botonIniciar_Click(object sender, EventArgs e)
        {
            formRegistro formularioReg = new formRegistro(this);
            formularioReg.Show();
            this.Hide();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void imgRecords_Click(object sender, EventArgs e)
        {
            formPuntajes formularioPuntajes = new formPuntajes(this);
            formularioPuntajes.Show();
            this.Hide();
        }

        private void imgInstrucciones_Click(object sender, EventArgs e)
        {
            formInstrucciones formularioInstrucciones = new formInstrucciones(this);
            formularioInstrucciones.Show();
            this.Hide();
        }
    }
}
