using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajedrez.Ajedrez;

namespace Ajedrez.Piezas
{
    public class Rey:Pieza
    {
        Movimientos mov = new Movimientos();
    //Posicion pos;
    int fila_actual;
    int columna_actual;
    char[] filas = {'0', '1', '2', '3', '4', '5', '6', '7'};
    char[] columnas = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'};
    Posicion[] result = new Posicion[64];
    public ArrayList resultado;
    Color col;
    
    public Rey(Posicion pos, Color c)
     :base(pos, c)
    {
        this.fila_actual = pos.getFila();
        this.columna_actual = pos.getColumna();
        this.Color = c;
    }
    public void MostrarTodas()
    {
        this.getMovimientosPosibles();
        System.Windows.MessageBox.Show("MOVIMIENTOS POSIBLES");
        for (Posicion palabra ; resultado) {
           System.Windows.MessageBox.Show(palabra+" ");
        }
        System.Windows.MessageBox.Show("");
        resultado.clear();
    }
   
    public Movimientos getMovimientosPosibles() {
        //Al ser un rey tenemos 4 posibles caminos que comprobar (las 4 esquinas)
        //Esquina superior derecha
        int f_aux = Posicion.getFila();
        int c_aux = Posicion.getColumna(); //Obtenemos la posición dentro del array
        
        if((f_aux > 0) && (f_aux < filas.Length-1) && (c_aux > 0) && (c_aux < columnas.Length-1)){
        //posicion media
            
            resultado.add(new Posicion(f_aux, c_aux+1));
            resultado.add(new Posicion(f_aux+1, c_aux));
            resultado.add(new Posicion(f_aux-1, c_aux));
            resultado.add(new Posicion(f_aux-1, c_aux-1));
            resultado.add(new Posicion(f_aux, c_aux-1));
            resultado.add(new Posicion(f_aux+1, c_aux-1));
            resultado.add(new Posicion(f_aux+1, c_aux+1));
            resultado.add(new Posicion(f_aux-1, c_aux+1));
        }
        else if((c_aux -1 < 0) && (f_aux-1 <0)){
         //esquina superior izquierda
            resultado.add(new Posicion(f_aux, c_aux+1));
            resultado.add(new Posicion(f_aux+1, c_aux+1));
            resultado.add(new Posicion(f_aux+1, c_aux));
        }
        else if((c_aux - 1 < 0) && (f_aux + 1 > filas.Length)){
         //esquina inferior izquierda
            resultado.add(new Posicion(f_aux, c_aux+1));
            resultado.add(new Posicion(f_aux-1, c_aux+1));
            resultado.add(new Posicion(f_aux-1, c_aux));
        }
        else if((c_aux +1 > columnas.Length) && (f_aux +1 > filas.Length))
        {
            //esquina inferior derecha
            resultado.add(new Posicion(f_aux, c_aux-1));
            resultado.add(new Posicion(f_aux-1, c_aux-1));
            resultado.add(new Posicion(f_aux -1, c_aux));
        }
        else if((c_aux +1 > columnas.Length) && (f_aux -1 < 0)){
            //esquina superior derecha
            resultado.add(new Posicion(f_aux+1, c_aux));
            resultado.add(new Posicion(f_aux, c_aux-1));
            resultado.add(new Posicion(f_aux+1, c_aux-1));
        }
        else if(c_aux - 1 < 0 ){
            //Lateral izquierdo
            resultado.add(new Posicion(f_aux+1, c_aux));
            resultado.add(new Posicion(f_aux-1, c_aux));
            resultado.add(new Posicion(f_aux+1, c_aux+1));
            resultado.add(new Posicion(f_aux, c_aux+1));
            resultado.add(new Posicion(f_aux-1, c_aux+1));
           
        }
        else if(c_aux + 1 > columnas.Length -1){
            //Lateral derecho
            resultado.add(new Posicion(f_aux+1, c_aux));
            resultado.add(new Posicion(f_aux-1, c_aux));
            resultado.add(new Posicion(f_aux+1, c_aux-1));
            resultado.add(new Posicion(f_aux, c_aux-1));
            resultado.add(new Posicion(f_aux-1, c_aux-1));
        }
        else if(f_aux + 1 > filas.Length -1){
            //Inferior
            resultado.add(new Posicion(f_aux-1, c_aux));
            resultado.add(new Posicion(f_aux-1, c_aux+1));
            resultado.add(new Posicion(f_aux, c_aux+1));
            resultado.add(new Posicion(f_aux-1, c_aux-1));
            resultado.add(new Posicion(f_aux, c_aux-1));
        }
        else if(f_aux - 1 < 0){
            //Superior
            resultado.add(new Posicion(f_aux+1, c_aux));
            resultado.add(new Posicion(f_aux, c_aux-1));
            resultado.add(new Posicion(f_aux, c_aux+1));
            resultado.add(new Posicion(f_aux+1, c_aux-1));
            resultado.add(new Posicion(f_aux+1, c_aux+1));
        }
            
        return mov;
    }
    
    public Boolean esMovimientoPosible(Posicion nuevoDestino) {
        //Aquí la idea es en primer lugar mirar en el array que nos ha devuelto 
        //el método anterior si nuevoDestino está dentro de el y por tanto
        //sería candidato a moverse si no hay otra ficha o alguna por medio
        System.Windows.MessageBox.Show("resultado0= "+resultado.ToString());
        Movimientos movimientos = this.getMovimientosPosibles();
        ArraySegment<Posicion> arrayLista = new ArraySegment<>();
        Boolean esposible = false;
        System.Windows.MessageBox.Show("nuevoDestino.fila= "+nuevoDestino.fila);
        System.Windows.MessageBox.Show("nuevoDestino.columna= "+nuevoDestino.columna);
        System.Windows.MessageBox.Show("resultado= "+resultado.ToString());
        System.Windows.MessageBox.Show("nuevoDestino= "+nuevoDestino);

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
        return "Rey";
    }
   
    public String toString(){
        return "Rey "+Color.name();
    }
  }
}
