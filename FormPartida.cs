using LocoMomoJuego;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocoMomo
{
    public partial class FormPartida : Form
    {
        //Atributos visuales
        List<List<Panel>> tableroPrincipalInterfazVisual;
        List<List<Panel>> tableroPuntajeInterfazVisual;
        List<Panel> fichasCapturadasVisual;
        List<Panel> panelesJugadaCapturaVisual;
        List<Label> flechasTableroPuntaje;

        //Atributos de partida
        const int numeroMaximoRondas = 6;
        int rondaActual;
        tableroPrincipal tableroPrincipalJuego;
        jugador jugadorActual;
        ficheroReparticion ficheroAnimalesReparticion;

        //Variable que guarda la posicion de la ficha capturada seleccionada
        int posicionFichaCapturadaSeleccionada;

        FormPrincipal formPrincipal;
        public FormPartida(string nombreEscogido, FormPrincipal formularioPrincipal)
        {
            InitializeComponent();
            iniciarComponentesPartida(nombreEscogido);
            iniciarComponentesVisuales();
            iniciarFlechasTableroPuntaje();
            formPrincipal = formularioPrincipal;
        }
        void iniciarComponentesPartida(string nombre) {
            this.jugadorActual = new jugador(nombre);
            this.ficheroAnimalesReparticion = new ficheroReparticion();
            this.tableroPrincipalJuego = new tableroPrincipal(generarFichasIniciales());
            this.rondaActual = 1;
            posicionFichaCapturadaSeleccionada = -1;
        }
        void iniciarFlechasTableroPuntaje() {
            flechasTableroPuntaje = new List<Label>
            {
                FlechaFila1,
                FlechaFila2,
                FlechaFila3,
                FlechaFila4,
                FlechaFila5
            };
        }
        void iniciarComponentesVisuales() {
            iniciarTableroPrincipalInterfazVisual();
            iniciarTableroPuntajeInterfazVisual();
            iniciarPanelesJugadaCapturaVisual();
            iniciarFichasCapturadasVisual();
            pintarComponentesIniciales();
        }
        void iniciarFichasCapturadasVisual() {
            fichasCapturadasVisual = new List<Panel>
            {
                Capturados1,
                Capturados2,
                Capturados3,
                Capturados4,
                Capturados5
            };
        }
        void iniciarPanelesJugadaCapturaVisual()
        {
            panelesJugadaCapturaVisual = new List<Panel> { CapturaC1, CapturaC2, CapturaC3, CapturaC4 };
        }
        void iniciarTableroPuntajeInterfazVisual() {
            tableroPuntajeInterfazVisual = new List<List<Panel>>
            {
                new List<Panel>{ E1F1Puntaje,E2F1Puntaje,E3F1Puntaje,E4F1Puntaje,E5F1Puntaje},
                new List<Panel>{ E1F2Puntaje,E2F2Puntaje,E3F2Puntaje,E4F2Puntaje,E5F2Puntaje},
                new List<Panel>{ E1F3Puntaje,E2F3Puntaje,E3F3Puntaje,E4F3Puntaje,E5F3Puntaje},
                new List<Panel>{ E1F4Puntaje,E2F4Puntaje,E3F4Puntaje,E4F4Puntaje,E5F4Puntaje},
                new List<Panel>{ E1F5Puntaje,E2F5Puntaje,E3F5Puntaje,E4F5Puntaje,E5F5Puntaje}
            };
        }
        void iniciarTableroPrincipalInterfazVisual() {
            tableroPrincipalInterfazVisual = new List<List<Panel>> {
            new List<Panel>{ P1C1,P2C1,P3C1,P4C1},
            new List<Panel> { P1C2, P2C2, P3C2, P4C2 },
            new List<Panel> { P1C3, P2C3, P3C3, P4C3 },
            new List<Panel> { P1C4, P2C4, P3C4, P4C4 },
            };
        }
        void pintarComponentesIniciales() {
            for (int indice = 1; indice <= 4; indice++)
            {
                var conjuntoFichas = tableroPrincipalJuego.devolverFicheroEspecificoTablero(indice).devolverFichero();
                var conjuntoPaneles = tableroPrincipalInterfazVisual[indice - 1];
                PintarGrupoPaneles(conjuntoFichas, conjuntoPaneles);
            }
        }
        Bitmap escogerImagenFondo(animales animal) {
            switch (animal)
            {
                case animales.oso: return Properties.Resources.oso;

                case animales.conejo: return Properties.Resources.conejo;

                case animales.leopardo: return Properties.Resources.leopardo;

                case animales.pato: return Properties.Resources.pato;

                case animales.aguila: return Properties.Resources.aguila;

                default: return null;
            }
        }

        Color escogerColor(colores colorRecibido) {
            switch (colorRecibido)
            {
                case colores.rojo: return Color.Red;

                case colores.azul: return Color.Blue;

                case colores.marron: return Color.Brown;

                case colores.verde: return Color.Green;

                default: return Color.Empty;
            }

        }

        void PintarGrupoPaneles(List<fichaAnimal> fichasRecibidas, List<Panel> panelesAActualizar)
        {
            for (int indice = 0; indice < panelesAActualizar.Count; indice++) {
                if (fichasRecibidas.Count > indice) PintarPanelEspecifico(fichasRecibidas[indice], panelesAActualizar[indice]);
                else DespintarPanelEspecifico(panelesAActualizar[indice]);
            }
        }

        void DespintarPanelEspecifico(Panel PanelEscogido) {
            PanelEscogido.BackgroundImage = null;
            PanelEscogido.BackColor = Color.Transparent;
        }
        void PintarPanelEspecifico(fichaAnimal fichaRecibida, Panel panelAActualizar)
        {
            panelAActualizar.BackgroundImage = escogerImagenFondo(fichaRecibida.mostrarAnimal());
            panelAActualizar.BackColor = escogerColor(fichaRecibida.mostrarColor());
        }
        List<fichaAnimal>[] generarFichasIniciales()
        {
            List<fichaAnimal>[] fichasIniciales = new List<fichaAnimal>[4];
            for (int indiceLista = 0; indiceLista < 4; indiceLista++)
            {
                fichasIniciales[indiceLista] = new List<fichaAnimal>();
                for (int indiceFicha = 0; indiceFicha < 4; indiceFicha++)
                {
                    fichasIniciales[indiceLista].Add(this.ficheroAnimalesReparticion.repartirFicha());
                }
            }

            return fichasIniciales;
        }

        void hacerJugada(int posicionFichaEscogida, int indiceFicheroTableroPrincipalEscogido)
        {
            var fichasCapturadas = tableroPrincipalJuego.capturarFichasAnimales(indiceFicheroTableroPrincipalEscogido, posicionFichaEscogida);
            int ultimaPosicionAfectada = tableroPrincipalJuego.devolverPosicionUltimoFicheroRecorrido();
            Panel panelVisualFichaEscogida = tableroPrincipalInterfazVisual[indiceFicheroTableroPrincipalEscogido - 1][posicionFichaEscogida - 1];
            mostrarJugadaVisual(panelVisualFichaEscogida, ultimaPosicionAfectada, indiceFicheroTableroPrincipalEscogido, fichasCapturadas.Last());
            culminarJugada(fichasCapturadas, indiceFicheroTableroPrincipalEscogido, ultimaPosicionAfectada);
        }

        private void culminarJugada(List<fichaAnimal> fichasCapturadas, int indiceFicheroTableroPrincipalEscogido, int ultimaPosicionAfectada)
        {

            jugadorActual.recibirFichasCaptura(fichasCapturadas);
            rellenarTableroPrincipal(indiceFicheroTableroPrincipalEscogido);
            mostrarCambiosVisualesJugada(indiceFicheroTableroPrincipalEscogido, ultimaPosicionAfectada); 
        }

        async void mostrarJugadaVisual(Panel PanelJugada, int ultimaPosicionAfectada, int indiceFicheroTableroPrincipalEscogido, fichaAnimal FichaEscogida)
        {
            DespintarPanelEspecifico(PanelJugada);
            PintarPanelEspecifico(FichaEscogida, panelesJugadaCapturaVisual[ultimaPosicionAfectada - 1]);
            await Task.Delay(1500);
            DespintarPanelEspecifico(panelesJugadaCapturaVisual[ultimaPosicionAfectada - 1]);
            mostrarCambiosVisualesJugada(indiceFicheroTableroPrincipalEscogido, ultimaPosicionAfectada);

        }

        private async void mostrarCambiosVisualesJugada(int indiceFicheroTableroPrincipalEscogido, int ultimaPosicionRecorrida)
        {
            await Task.Delay(1500);
            PintarGrupoPaneles(
               tableroPrincipalJuego.devolverFicheroEspecificoTablero(indiceFicheroTableroPrincipalEscogido).devolverFichero()
               , this.tableroPrincipalInterfazVisual[indiceFicheroTableroPrincipalEscogido - 1]);
            PintarGrupoPaneles(
               tableroPrincipalJuego.devolverFicheroEspecificoTablero(ultimaPosicionRecorrida).devolverFichero()
               , this.tableroPrincipalInterfazVisual[ultimaPosicionRecorrida - 1]);
            PintarGrupoPaneles(jugadorActual.devolverConjuntoFichasCapturadas(), this.fichasCapturadasVisual);
        }
        void rellenarTableroPrincipal(int indiceFicheroEscogido)
        {
            int indiceFicheroRecorrido = tableroPrincipalJuego.devolverPosicionUltimoFicheroRecorrido();
            //se rellena el fichero de la jugada
            rellenarFicheroEspecifico(1, indiceFicheroEscogido);

            int fichasRestantesFicheroRecorrido = tableroPrincipalJuego.devolverFicheroEspecificoTablero(indiceFicheroRecorrido).CantidadFichasRestantes;
            //se rellena el fichero donde fue la captura
            rellenarFicheroEspecifico(4 - fichasRestantesFicheroRecorrido, indiceFicheroRecorrido);
        }
        void rellenarFicheroEspecifico(int cantidad, int posicionficheroEscogido)
        {
            for (int indice = 1; indice <= cantidad; indice++)
            {
                tableroPrincipalJuego.colocarFichaRepartida(ficheroAnimalesReparticion.repartirFicha(), posicionficheroEscogido);
            }
        }

        void pasarSiguienteRonda()
        {
            rondaActual++;
            if (rondasMaximasSeSuperaron()) terminarPartida();
            lblRondaActual.Text = rondaActual.ToString();
        }

        private void terminarPartida()
        {
            jugadorActual.asignarPuntajeFinal();
            var DatosJugador = jugadorActual.devolverDatosJugador();
            string datosJugadorCadena = DatosJugador.nombre + "-" + DatosJugador.puntaje;
            MessageBox.Show("Puntaje acumulado: "+DatosJugador.puntaje.ToString(),"Partida Terminada");
            using (StreamWriter escritor = new StreamWriter("DatosJugadores.txt",true))
            {
                escritor.WriteLine(datosJugadorCadena);
            }
            formPrincipal.Show();
            this.Close();
        }

        public bool rondasMaximasSeSuperaron() => rondaActual > numeroMaximoRondas;


        private void FormPartida_Load(object sender, EventArgs e)
        {

        }

        void intentarJugada(int posicionFichaEscogida, int posicionFicheroEscogida) {
            if (jugadorActual.fichasCapturadasEstaVacio())
                hacerJugada(posicionFichaEscogida, posicionFicheroEscogida);
            else MessageBox.Show("Primero Vacia tus fichas capturadas antes de continuar", "Advertencia");
        }

        private void P1C1_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(1, 1);
        }

        private void P2C1_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(2, 1);
        }

        private void P3C1_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(3, 1);
        }

        private void P4C1_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(4, 1);
        }

        private void P1C2_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(1, 2);
        }

        private void P2C2_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(2, 2);
        }

        private void P3C2_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(3, 2);
        }

        private void P4C2_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(4, 2);
        }

        private void P1C3_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(1, 3);
        }

        private void P2C3_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(2, 3);
        }

        private void P3C3_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(3, 3);
        }

        private void P4C3_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(4, 3);
        }

        private void P1C4_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(1, 4);
        }

        private void P2C4_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(2, 4);
        }

        private void P3C4_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(3, 4);
        }

        private void P4C4_DoubleClick(object sender, EventArgs e)
        {
            intentarJugada(4, 4);
        }

        private void dibujarBorde(Panel panel)
        {
            panel.BorderStyle = BorderStyle.Fixed3D;
        }

        void quitarBordesPanelesFichasCapturadas() {
            foreach (Panel panel in fichasCapturadasVisual) {
                panel.BorderStyle = BorderStyle.None;
            }
        }
        private void Capturados1_Click(object sender, EventArgs e)
        {
            quitarBordesPanelesFichasCapturadas();
            posicionFichaCapturadaSeleccionada = 1;
            dibujarBorde(this.Capturados1);
        }

        private void Capturados2_Click(object sender, EventArgs e)
        {
            quitarBordesPanelesFichasCapturadas();
            posicionFichaCapturadaSeleccionada = 2;
            dibujarBorde(this.Capturados2);
        }

        private void Capturados3_Click(object sender, EventArgs e)
        {
            quitarBordesPanelesFichasCapturadas();
            posicionFichaCapturadaSeleccionada = 3;
            dibujarBorde(this.Capturados3);
        }

        private void Capturados4_Click(object sender, EventArgs e)
        {
            quitarBordesPanelesFichasCapturadas();
            posicionFichaCapturadaSeleccionada = 4;
            dibujarBorde(this.Capturados4);
        }

        private void Capturados5_Click(object sender, EventArgs e)
        {
            quitarBordesPanelesFichasCapturadas();
            posicionFichaCapturadaSeleccionada = 5;
            dibujarBorde(this.Capturados5);
        }

        void mostrarCambiosVisualesFilaTableroPuntajes(int filaEscogida)
        {
            var fichasFilaEscogida = jugadorActual.devolverTablero().extraerFila(filaEscogida);
            var panelesFilaEscogida = tableroPuntajeInterfazVisual[filaEscogida - 1];
            PintarGrupoPaneles(fichasFilaEscogida, panelesFilaEscogida);
        }
        void mostrarFlecha(int fila)
        {
            var flechaEscogida = flechasTableroPuntaje[fila - 1];
            flechaEscogida.Visible = true;
        }
        void intentarColocarFichaCapturada(int filaSeleccionada) {
            if (!(posicionFichaCapturadaSeleccionada == -1))
            {
                try {
                    jugadorActual.colocarFichaCapturadaATablero(posicionFichaCapturadaSeleccionada, filaSeleccionada);
                    mostrarCambiosVisualesFichasColocadas(filaSeleccionada);
                    if(jugadorActual.devolverCantidadFichasCapturadas()==0) pasarSiguienteRonda();
                }
                catch (posicionNoDisponibleExepcion) {
                    if (posicionFichaCapturadaSeleccionada > jugadorActual.devolverCantidadFichasCapturadas()) { 
                    MessageBox.Show("Por favor marque una captura no vacia", "Advertencia");
                        return;
                    }
                    MessageBox.Show("Ya se alcanzaron la maxima cantad de fichas en esta fila", "Advertencia");

                }
            }
        }
        void mostrarCambiosVisualesFichasColocadas(int fila) {
            mostrarCambiosVisualesFilaTableroPuntajes(fila);
            pintarCambiosFichasCaptura(posicionFichaCapturadaSeleccionada);
            posicionFichaCapturadaSeleccionada = -1;
        }
        void pintarCambiosFichasCaptura(int posicion) {
            var capturas=jugadorActual.devolverConjuntoFichasCapturadas();
            PintarGrupoPaneles(capturas,fichasCapturadasVisual);
            fichasCapturadasVisual[posicion - 1].BorderStyle = BorderStyle.None;
        } 
        private void E1F1Puntaje_Click(object sender, EventArgs e)
        {
            intentarColocarFichaCapturada(1);
        }

        void despintarFlechasTableroPuntaje() 
        {
            foreach (Label flecha in flechasTableroPuntaje) {
                flecha.Visible = false;
            }
        }
        private void FormPartida_MouseEnter(object sender, EventArgs e)
        {
            despintarFlechasTableroPuntaje();
        }

        private void E1F1Puntaje_MouseLeave(object sender, EventArgs e)
        {
            despintarFlechasTableroPuntaje();
        }

        private void E1F1Puntaje_MouseEnter(object sender, EventArgs e)
        {
            if(!(posicionFichaCapturadaSeleccionada == -1))
                mostrarFlecha(1);
        }

        private void E1F2Puntaje_Click(object sender, EventArgs e)
        {
            intentarColocarFichaCapturada(2);
        }

        private void E1F2Puntaje_MouseEnter(object sender, EventArgs e)
        {
            if (!(posicionFichaCapturadaSeleccionada == -1))
                mostrarFlecha(2);
        }

        private void E1F3Puntaje_Click(object sender, EventArgs e)
        {
            intentarColocarFichaCapturada(3);
        }

        private void E1F3Puntaje_MouseEnter(object sender, EventArgs e)
        {
            if (!(posicionFichaCapturadaSeleccionada == -1))
                mostrarFlecha(3);
        }

        private void E1F4Puntaje_Click(object sender, EventArgs e)
        {
            intentarColocarFichaCapturada(4);
        }

        private void E1F4Puntaje_MouseEnter(object sender, EventArgs e)
        {
            if (!(posicionFichaCapturadaSeleccionada == -1))
                mostrarFlecha(4);
        }

        private void E1F5Puntaje_Click(object sender, EventArgs e)
        {   

            intentarColocarFichaCapturada(5);
        }

        private void E1F5Puntaje_MouseEnter(object sender, EventArgs e)
        {
            if (!(posicionFichaCapturadaSeleccionada == -1))
                mostrarFlecha(5);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TituloRonda_Click(object sender, EventArgs e)
        {

        }

        private void lblRondaActual_Click(object sender, EventArgs e)
        {

        }

        private void imgSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estas seguro que deseas salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes) { 
            formPrincipal.Show();
            this.Close();
            }
        }
    }
}
