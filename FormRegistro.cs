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
    public partial class formRegistro : Form
    {
        FormPrincipal formularioPrincipal;
        public formRegistro(FormPrincipal formPrincipal)
        {
            InitializeComponent();

            formularioPrincipal = formPrincipal;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            formularioPrincipal.Show();
            this.Close();
        }

        private void botonEscoger_Click(object sender, EventArgs e)
        {
            if (!textoEsValido()) {
                MessageBox.Show("Introduzca un nombre de 1 a 15 caracteres", "Advertencia");
                return;
            }
            FormPartida formularioPartida = new FormPartida(textNombre.Text,formularioPrincipal);
            formularioPartida.Show();
            this.Close();
        }

        bool textoEsValido() => textNombre.Text.Length <= 15 && textNombre.Text.Length > 0;
    }
}
