using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LocoMomoJuego
{
    public class fichaAnimal
    {
        animales animal;
        colores color;
        movimientos movimiento;

        public fichaAnimal(animales animalRecibido, colores colorRecibido)
        {
            this.animal = animalRecibido;
            this.color = colorRecibido;

            this.movimiento = asignarMovimiento(animalRecibido);
        }

        public movimientos mostrarMovimiento() => this.movimiento;

        public colores mostrarColor() => this.color;

        public animales mostrarAnimal() => this.animal;



        public movimientos asignarMovimiento(animales animalRecibido)
        {

            switch (animalRecibido)
            {
                case animales.conejo: return movimientos.avance;

                case animales.leopardo: return movimientos.retrocede;

                case animales.oso: return movimientos.permanece;

                case animales.aguila: return movimientos.diagonal;

                case animales.pato: return movimientos.recorrido;

                default: throw new animalInvalidoExcepcion();

            }

        }

    }
    public class ficheroAnimal
    {
        public List<fichaAnimal> fichasAnimales = new List<fichaAnimal>();
        public int CantidadFichasRestantes,
            CantidadFichasIniciales,
            CantidadFichasUtilizadas;
        public bool EstaVacio() => CantidadFichasRestantes == 0;
    }

    public class ficheroReparticion : ficheroAnimal
    {
        public ficheroReparticion()
        {
            var coloresARepartir = (colores[])Enum.GetValues(typeof(colores));
            var animalesARepartir = (animales[])Enum.GetValues(typeof(animales));

            generarFichas(coloresARepartir, animalesARepartir);
            prepararFichas();
        }

        void prepararFichas() {
            this.CantidadFichasUtilizadas = 0;
            this.CantidadFichasRestantes = this.CantidadFichasIniciales;
            this.fichasAnimales = revolverFichero(fichasAnimales);
        }
        void generarFichas(colores[] coloresARepartir, animales[] animalesARepartir) {
            int contadorFichas = 0;
            for (int indiceColores = 0; indiceColores <= 3; indiceColores++)
            {
                for (int indiceAnimales = 0; indiceAnimales <= 4; indiceAnimales++)
                {
                    for (int fichasGeneradas = 0; fichasGeneradas <= 5; fichasGeneradas++)
                    {
                        agregarFichaAnimal(coloresARepartir[indiceColores], animalesARepartir[indiceAnimales]);
                        contadorFichas++;
                    }
                }
            }
            asignarCantidadFichasIniciales(contadorFichas);
        }

        void agregarFichaAnimal(colores color, animales animal) {
            fichaAnimal fichaAnimalGenerada = new fichaAnimal(animal, color);
            fichasAnimales.Add(fichaAnimalGenerada);
        }

        private void asignarCantidadFichasIniciales(int contadorFichas)
        {
            CantidadFichasIniciales = contadorFichas;
        }

        public List<fichaAnimal> revolverFichero(List<fichaAnimal> ficheroARevolver) {
            var rnd = new Random();
            return ficheroARevolver.OrderBy(item => rnd.Next()).ToList();
        }
        public fichaAnimal repartirFicha() {
            if (EstaVacio()) throw new ficheroVacioExcepcion();
            fichaAnimal fichaARepartir = sacarFicha();
            descartarFicha();
            CantidadFichasRestantes--;
            return fichaARepartir;
        }
        public fichaAnimal sacarFicha() => fichasAnimales[0];

        public void descartarFicha() {
            fichasAnimales.RemoveAt(0);
        }
    }

    public class ficheroTablero : ficheroAnimal {
        public const byte maximoFichas = 4;

        public ficheroTablero(List<fichaAnimal> ficheroInicial) {
            this.fichasAnimales = ficheroInicial;
            CantidadFichasIniciales = ficheroInicial.Count;
            CantidadFichasRestantes = ficheroInicial.Count;
        }

        public List<fichaAnimal> devolverFichero() => this.fichasAnimales;

        public List<fichaAnimal> RecibirFichaJugada(fichaAnimal animalRecibido)
        {
            var animalesCapturados = devolverFichasAnimalesCapturados(animalRecibido.mostrarColor());

            CantidadFichasRestantes -= animalesCapturados.Count;

            animalesCapturados.Add(animalRecibido);

            this.fichasAnimales = fichasAnimales.Except(animalesCapturados).ToList();

            return animalesCapturados;
        }
        public void recibirFichaRepartida(fichaAnimal fichaRecibida) {
            if (CantidadFichasRestantes == maximoFichas) throw new ficheroDesbordadoExcepcion();
            this.fichasAnimales.Add(fichaRecibida);
            CantidadFichasRestantes++;
        }
        public int devolverCantidadFichasRestantes() => CantidadFichasRestantes;

        List<fichaAnimal> devolverFichasAnimalesCapturados(colores colorAnimalRecibido) =>
            this.fichasAnimales.Where(ficha => ficha.mostrarColor() == colorAnimalRecibido).ToList();
        public fichaAnimal escogerFichaEspecifica(int posicion) {
            var fichaADevolver = devolverFichaEscogida(posicion);
            descartarFicha(posicion);
            return fichaADevolver;
        }
        public void descartarFicha(int posicion) {
            this.fichasAnimales.RemoveAt(posicion-1);
            this.CantidadFichasRestantes--;
        }

        public fichaAnimal devolverFichaEscogida(int posicion) => this.fichasAnimales[posicion-1];

        public bool ContieneAnimal(fichaAnimal fichaAnimalBuscada) => 
            this.fichasAnimales.Exists(ficha =>ficha.mostrarAnimal()==fichaAnimalBuscada.mostrarAnimal());
        
    }

    public class tableroPrincipal {
        Dictionary<int, ficheroTablero> ficherosTablero = new Dictionary<int, ficheroTablero>();
        int posicionUltimoFicheroRecorrido;
        public tableroPrincipal(List<fichaAnimal>[] listasIniciales) {
            for (int indiceListasIniciales=1;indiceListasIniciales<=4;indiceListasIniciales++) {
                ficherosTablero.Add(indiceListasIniciales, new ficheroTablero(listasIniciales[indiceListasIniciales-1]));
            }
        }

        public Dictionary<int, ficheroTablero> mostrarFicheroTablero() => this.ficherosTablero;
        public ficheroTablero devolverFicheroEspecificoTablero(int posicion) => this.ficherosTablero[posicion];

        public void colocarFichaRepartida(fichaAnimal fichaRelleno,int posicionFicheroEscogido ) {
            if (!posicionExiste(posicionFicheroEscogido)) throw new posicionInvalidaExcepcion(); 
            devolverFicheroEspecificoTablero(posicionFicheroEscogido).recibirFichaRepartida(fichaRelleno);
        }
        
        public List<fichaAnimal> capturarFichasAnimales(int posicionFicheroEscogido, int posicionFichaJugada) {
            if (!(posicionExiste(posicionFicheroEscogido) && posicionExiste(posicionFichaJugada))) 
                throw new posicionInvalidaExcepcion();
            ficheroTablero ficheroEscogido = devolverFicheroEspecificoTablero(posicionFicheroEscogido);
            fichaAnimal fichaEscogida = ficheroEscogido.escogerFichaEspecifica(posicionFichaJugada);
            List<fichaAnimal> resultadoJugada = escogerMovimiento(fichaEscogida, posicionFicheroEscogido);
            return resultadoJugada;
        }

        private List<fichaAnimal> escogerMovimiento(fichaAnimal fichaEscogida, int posicionFicheroActual)
        {
            var movimiento = fichaEscogida.mostrarMovimiento();

            switch (movimiento) {

                case movimientos.avance: return hacerMovimientoAvance(posicionFicheroActual, fichaEscogida);

                case movimientos.diagonal: return hacerMovimientoDiagonal(posicionFicheroActual, fichaEscogida);

                case movimientos.permanece: return hacerMovimientoPermanece(posicionFicheroActual, fichaEscogida);

                case movimientos.recorrido: return hacerMovimientoRecorrido(posicionFicheroActual, fichaEscogida);

                case movimientos.retrocede: return hacerMovimientoRetrocede(posicionFicheroActual, fichaEscogida);

                default: throw new movimientoInvalidoExepcion();

            }
        }

       public List<fichaAnimal> hacerMovimientoRetrocede(int posicionInicial, fichaAnimal fichaEscogida) =>
            devolverFicheroEspecificoTablero(calcularPosicionJugada(posicionInicial - 1)).RecibirFichaJugada(fichaEscogida);

        public List<fichaAnimal> hacerMovimientoRecorrido(int posicionInicial, fichaAnimal fichaEscogida)
        {
            int posicionRecorridoActual = posicionInicial;
            for (int ficherosRecorridos = 1; ficherosRecorridos <= 4; ficherosRecorridos++) {
                ficheroTablero ficheroARevisar = devolverFicheroEspecificoTablero(calcularPosicionJugada(posicionInicial + ficherosRecorridos));

                if (ficheroARevisar.ContieneAnimal(fichaEscogida)) 
                    return devolverFicheroEspecificoTablero(calcularPosicionJugada(posicionInicial + ficherosRecorridos)).RecibirFichaJugada(fichaEscogida);
            }
            return devolverFicheroEspecificoTablero(posicionInicial).RecibirFichaJugada(fichaEscogida);
        }

        public List<fichaAnimal> hacerMovimientoPermanece(int posicionInicial, fichaAnimal fichaEscogida)=> 
            devolverFicheroEspecificoTablero(calcularPosicionJugada(posicionInicial)).RecibirFichaJugada(fichaEscogida);
        

        public List<fichaAnimal> hacerMovimientoDiagonal(int posicionActual, fichaAnimal fichaEscogida) =>
            devolverFicheroEspecificoTablero(calcularPosicionJugada(posicionActual + 2)).RecibirFichaJugada(fichaEscogida);
        

        public List<fichaAnimal> hacerMovimientoAvance(int posicionInicial, fichaAnimal fichaEscogida) =>
            devolverFicheroEspecificoTablero(calcularPosicionJugada(posicionInicial+1)).RecibirFichaJugada(fichaEscogida);

        public int calcularPosicionJugada(int posicionFicheroJugada) {
            if (!posicionExiste(posicionFicheroJugada)) { 
                int posicionCorregida= corregirPosicion(posicionFicheroJugada);
                posicionUltimoFicheroRecorrido = posicionCorregida;
                return posicionCorregida;
            }
            posicionUltimoFicheroRecorrido = posicionFicheroJugada;
            return posicionFicheroJugada;
        }

        private int corregirPosicion(int posicion)
        {
            if (posicion > 4) return posicion - 4;
            else if (posicion < 1) return posicion + 4;
            throw new posicionInvalidaExcepcion();
        }
        public int devolverPosicionUltimoFicheroRecorrido() => this.posicionUltimoFicheroRecorrido;
        public bool posicionExiste(int posicion)=> !(posicion < 1 || posicion > 4);

    }

    public class jugador {
        tableroPuntajes tableroPuntaje;
        int puntaje;
        string nombre;
        List<fichaAnimal> fichasCapturadas;
        public jugador(string nombreJugador) {
            tableroPuntaje = new tableroPuntajes();
            fichasCapturadas = new List<fichaAnimal>();
            nombre = nombreJugador;
        }

        public int devolverCantidadFichasCapturadas() => this.fichasCapturadas.Count;
        public List<fichaAnimal> devolverConjuntoFichasCapturadas() => this.fichasCapturadas;
        public tableroPuntajes devolverTablero() => this.tableroPuntaje;
        public void colocarFichaCapturadaATablero(int indiceFichaEscogida, int indiceFilaTableroDestino)
        {
            if (!posicionCapturaEstaDisponible(indiceFichaEscogida)) throw new posicionNoDisponibleExepcion();
            var fichaEscogida=devolverFichaCaptura(indiceFichaEscogida);
            tableroPuntaje.recibirFichaAnimal(fichaEscogida,indiceFilaTableroDestino);
            descartarFicha(indiceFichaEscogida);
        }

        private void descartarFicha(int indiceFichaEscogida)
        {
            this.fichasCapturadas.RemoveAt(indiceFichaEscogida-1);
        }

        fichaAnimal devolverFichaCaptura(int posicion) =>this.fichasCapturadas[posicion-1];

        public void recibirFichasCaptura(List<fichaAnimal> fichasCapturadas) {
            this.fichasCapturadas.AddRange(fichasCapturadas);
        }
        public void asignarPuntajeFinal() {
            this.puntaje = this.tableroPuntaje.calcularPuntajeFinal();
        }
        public bool fichasCapturadasEstaVacio() => this.fichasCapturadas.Count == 0;

        public (string nombre, int puntaje) devolverDatosJugador() => (this.nombre, this.puntaje);

        bool posicionCapturaEstaDisponible(int posicion) => posicion<=this.fichasCapturadas.Count && posicion>0;
    }

    

    public class tableroPuntajes {

        List<fichaAnimal>[] tableroFichasPuntaje;
        const int numeroElementosMaximoFilasColumnas = 5;

        int[] puntajesPosibles = {1,2,5,9,14};
        public tableroPuntajes() {
            tableroFichasPuntaje = new List<fichaAnimal>[numeroElementosMaximoFilasColumnas];

            for (int indice = 0; indice < tableroFichasPuntaje.Length; indice++) {
                tableroFichasPuntaje[indice] = new List<fichaAnimal>();
            }
        }

        public void recibirFichaAnimal(fichaAnimal fichaRecibida, int indiceFilaEscogida) {
            if (!filaExiste(indiceFilaEscogida)) throw new posicionInvalidaExcepcion();

            var filaEscogidaTablero = extraerFila(indiceFilaEscogida);

            if (!posicionTableroPuntajeEstaDisponible(filaEscogidaTablero)) throw new posicionNoDisponibleExepcion();

            filaEscogidaTablero.Add(fichaRecibida);
        }

        public List<fichaAnimal> extraerFila(int posicionFilaEscogida) => tableroFichasPuntaje[posicionFilaEscogida - 1];

        public int calcularPuntajeFinal() => 
                calcularPuntajesPrimeraFila()+ 
                calcularPuntajesSegundaTerceraFila()+
                calcularPuntajeCuartaFila()+
                calcularPuntajeQuintaFila()+
                calcularPuntajeColumnas();

        public int calcularPuntajeColumnas() {
            int puntajeAcumulado=0;
            for (int indice = 0; indice<= 4; indice++) {
                var columnaExtraida = tableroFichasPuntaje
                    .Select(fila => fila.ElementAtOrDefault(indice))
                    .Where(ficha => ficha!=default(fichaAnimal))
                    .ToList();
                if (columnaExtraida.Count==5) { 
                    bool coloresSonIguales = columnaExtraida.All(ficha => ficha.mostrarColor() == columnaExtraida[0].mostrarColor());
                    if (coloresSonIguales) puntajeAcumulado += 5;
                }
            }
            return puntajeAcumulado;
        }
        public int calcularPuntajesPrimeraFila() {
            int numeroCoincidenciasParejas =
                extraerFila(3).
                Zip(extraerFila(2),
                (fichaPrimerConjunto, fichaSegundoConjunto) => new { fichaPrimerConjunto, fichaSegundoConjunto }).
                Zip(extraerFila(1),
                (pareja,fichaTercerConjunto)=>new { pareja.fichaPrimerConjunto, pareja.fichaSegundoConjunto,fichaTercerConjunto}).
                Where(trio => 
                trio.fichaPrimerConjunto.mostrarAnimal() == trio.fichaSegundoConjunto.mostrarAnimal()
                &&
                trio.fichaSegundoConjunto.mostrarAnimal() == trio.fichaTercerConjunto.mostrarAnimal()
                ).
                Select(coincidencia => coincidencia.fichaPrimerConjunto).
                Count();
            return numeroCoincidenciasParejas*4;
        }
        public int calcularPuntajesSegundaTerceraFila() {
            int numeroCoincidenciasParejas =
                extraerFila(3).Zip(extraerFila(2),
                (fichaPrimerConjunto, fichaSegundoConjunto) => new { fichaPrimerConjunto, fichaSegundoConjunto }).
                Where(pareja => 
                pareja.fichaPrimerConjunto.mostrarAnimal() == pareja.fichaSegundoConjunto.mostrarAnimal()
                ).
                Select(coincidencia =>coincidencia.fichaPrimerConjunto).
                Count();

            return numeroCoincidenciasParejas * 3;
        }

        public int calcularPuntajeCuartaFila() {
            int puntajeAcumulado = 0;
            var elementosAgrupados= extraerFila(4).GroupBy(ficha => ficha.mostrarAnimal()).
                Select(g=>new { animal=g.Key, repeticiones=g.Count()});
            foreach (var grupo in elementosAgrupados) {
                puntajeAcumulado+= this.puntajesPosibles[grupo.repeticiones-1];
            }
            return puntajeAcumulado;
        }

        //devuelve un puntaje en base a los elementos distintos que cuenta
        public int calcularPuntajeQuintaFila() => 
            puntajesPosibles[extraerFila(5).Select(ficha =>ficha.mostrarAnimal()).Distinct().Count()-1];

        bool filaExiste(int posicionFilaEscogida)
            => posicionFilaEscogida <= numeroElementosMaximoFilasColumnas && posicionFilaEscogida >= 1;
        bool posicionTableroPuntajeEstaDisponible(List<fichaAnimal> filaRecibida) 
            => filaRecibida.Count < numeroElementosMaximoFilasColumnas;
    }


    public enum colores: byte
    {
        rojo,
        azul,
        marron,
        verde
    }
    public enum animales:byte
    {
        conejo,
        oso,
        aguila,
        pato,
        leopardo
    }
    public enum movimientos:byte
    {
        avance,
        permanece,
        diagonal,
        recorrido,
        retrocede
    }

    public class animalInvalidoExcepcion : Exception
    {

    }

    public class movimientoInvalidoExepcion : Exception { 
    
    }

    public class ficheroVacioExcepcion : Exception
    {

    }
    public class posicionInvalidaExcepcion : Exception {
    
    }

    public class posicionNoDisponibleExepcion : Exception { 
    
    }

    public class ficheroDesbordadoExcepcion : Exception { }
}
