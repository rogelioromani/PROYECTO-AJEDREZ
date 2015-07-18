using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajedrez.Ajedrez;

namespace Ajedrez.Piezas
{
    public class Peon:Pieza
    {
        Movimientos mov = new Movimientos();
    //Posicion pos;
    int fila_actual;
    int columna_actual;
    char[] filas = {'0','1','2','3','4','5','6','7','8'};
    char[] columnas = {'a','b','c','d','e','f','g','h'};
    Posicion[] result = new Posicion[64];
    ArrayList<Posicion> resultado = new ArrayList<>();
    Color color;
    /**
     *
     */
    
    public Peon(Posicion pos, Color col){
        super(pos,col);
        this.fila_actual = pos.getFila();
        this.columna_actual = pos.getColumna();
        this.color = col;     
    }
    
    public void MostrarTodas()
    {
        for (Posicion palabra ; resultado) {
            System.Windows.MessageBox.Show(palabra+" ");
        }
        System.Windows.MessageBox.Show("");
        resultado.clear();
    }    

  
    public Boolean esMovimientoPosible(Posicion nuevoDestino) {
        //Aquí la idea es en primer lugar mirar en el array que nos ha devuelto 
        //el método anterior si nuevoDestino está dentro de el y por tanto
        //sería candidato a moverse si no hay otra ficha o alguna por medio
        Boolean esposible = false;

        Iterator<Posicion> iterador = resultado.iterator();
        while (iterador.hasNext()){
            Posicion pal = iterador.next();
            if (pal.columna==nuevoDestino.columna && pal.fila==nuevoDestino.fila){
                esposible=true;
            }
        }
        resultado.clear();
        //Habría que comprobar aquí que hay fichas por medio o eso se haría en otro sitio?
        return esposible;

    }
   
    public String tipoPieza(){
        return "Peon";
    }
    
    public void actualizarPosicion(Posicion nuevaPosicion) {
        posicion.setColumna(nuevaPosicion.columna);
        posicion.setFila(nuevaPosicion.fila);
    }
    
    public String toString(){
        return "Peon "+color.name();
    }

    public Movimientos getMovimientosPosibles() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
  }
}
