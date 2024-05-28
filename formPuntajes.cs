using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocoMomo
{
    public partial class formPuntajes : Form
    {
        List<Marca> records;
        FormPrincipal formularioPrincipal;
        public formPuntajes(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            records = new List<Marca>();
            formularioPrincipal = formPrincipal;
        }

        private void formPuntajes_Load(object sender, EventArgs e)
        {
            extraerDatos();
            cargarPuntajesJugadores();
        }

        private void cargarPuntajesJugadores()
        {
            var recordsOrdenados = records.OrderByDescending(record =>record.mostrarPuntaje()).ToList();

            for (int indice = 0; indice <= 15; indice++) {
                try
                {
                    textPuntajes.AppendText($"\t{indice+1}-{recordsOrdenados[indice].mostrarNombre()} con {recordsOrdenados[indice].mostrarPuntaje()} puntos \n");

                }
                catch (Exception)
                {
                    textPuntajes.AppendText("(Son todos los puntajes Registrados)");
                    break;
                }
            }
        }
        private void extraerDatos() {
            string ruta = "DatosJugadores.txt";
            try
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea;

                    while ((linea = sr.ReadLine()) != null)
                    {
                        var Marca = new Marca(linea);
                        try
                        {
                            records.Add(Marca);
                        }
                        catch (Exception){  } 

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Archivo Corrompido");
            }


        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            formularioPrincipal.Show();
            this.Close();
        }
    }
    class Marca {
        string nombre;
        int puntaje;
        public Marca(string linea) {
            var datosEncontrados = devolverDatosJugadores(linea);
            nombre = datosEncontrados.Nombre;
            puntaje = datosEncontrados.puntaje;
        }
        public int mostrarPuntaje() => this.puntaje;

        public string mostrarNombre() => this.nombre;


        private bool nombreEsValido(string nombre) => nombre.Length > 0 && nombre.Length <= 15;

        (string Nombre, int puntaje) devolverDatosJugadores(string linea)
        {
            var datosSeparados = linea.Split('-');
            string nombreEncontrado = datosSeparados[0];
            int puntajeEncontrado;
            try
            {
                puntajeEncontrado = Int32.Parse(datosSeparados[1]);
                if (!nombreEsValido(nombreEncontrado)) throw new lineaCorruptaExcepcion();
            }
            catch (Exception)
            {
                throw new lineaCorruptaExcepcion();
            }
            return (nombreEncontrado, puntajeEncontrado);

        }

    }
    class lineaCorruptaExcepcion : Exception { 
    
    }
    
}
