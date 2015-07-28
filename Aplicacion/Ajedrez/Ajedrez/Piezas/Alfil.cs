using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajedrez.Ajedrez;

namespace Ajedrez
{
    public class Alfil:Pieza
    {
    Movimientos mov = new Movimientos();
    Posicion pos;
    int fila_actual;
    int columna_actual;
    char[] filas = {'0', '1', '2', '3', '4', '5', '6', '7'};
    char[] columnas = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'};
    Posicion[] result = new Posicion[64];
    public ArrayList resultado;
    Color col;


     public Alfil (Posicion pos, Color c)
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
        for (Posicion palabra; resultado) {
             System.Windows.MessageBox.Show(palabra + " ");
        }
         System.Windows.MessageBox.Show("");

        resultado.Clear (); 

    }

    public Posicion[] getResult() {
        return result;
    }
    
   public Movimientos getMovimientosPosibles() {
        //Al ser un alfil tenemos 4 posibles caminos que comprobar (las 4 esquinas)
        //Esquina superior derecha
        int f_aux = Posicion.getFila();
        int c_aux = Posicion.getColumna(); //Obtenemos la posición dentro del array
        
        while ((f_aux > 0) && (c_aux < columnas.Length-1)) {
            f_aux--;
            c_aux++;
            
            resultado.Add(new Posicion(f_aux, c_aux));
            
        }
        //Esquina inferior derecha
        //Partimos del punto inicial para volver a mirar
        f_aux = Posicion.getFila();
        c_aux = Posicion.getColumna();
        System.Windows.MessageBox.Show("mala: " + "f_aux= "+ f_aux + "c_aux= " + c_aux);
        while ((f_aux < filas.Length-1) && (c_aux < columnas.Length-1)) {
            f_aux++;
            c_aux++;
            
            resultado.add(new Posicion(f_aux, c_aux));
        }
        f_aux = Posicion.getFila();
        c_aux = Posicion.getColumna();
        System.Windows.MessageBox.Show("puta: " + "f_aux= "+ f_aux + "c_aux= " + c_aux);
        while ((f_aux > 0) && (c_aux > 0)) {
            //Esquina superior izquierda
            f_aux--;
            c_aux--;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        f_aux = Posicion.getFila();
        c_aux = Posicion.getColumna();
        System.Windows.MessageBox.Show("joder: " + "f_aux= "+ f_aux + "c_aux= " + c_aux);
        while ((f_aux < filas.Length-1) && (c_aux > 0)) {
            //Esquina inferior izquierda
            f_aux++;
            c_aux--;
            resultado.add(new Posicion(f_aux, c_aux));
            System.Windows.MessageBox.Show("me cago en to: " + "f_aux= "+ f_aux + "c_aux= " + c_aux);
        }
        //Aquí tenemos que devolver el arr ay result pero ¿De qué tipo?       
        return mov;

    }

    public Boolean esMovimientoPosible(Posicion nuevoDestino) {
        //Aquí la idea es en primer lugar mirar en el array que nos ha devuelto 
        //el método anterior si nuevoDestino está dentro de el y por tanto
        //sería candidato a moverse si no hay otra ficha o alguna por medio
        //System.out.println("resultado0= "+resultado.toString());
        Movimientos movimientos = this.getMovimientosPosibles();
        Boolean esposible = false;
        System.Windows.MessageBox.Show("nuevoDestino.fila= "+nuevoDestino.fila);
        System.Windows.MessageBox.Show("nuevoDestino.columna= "+nuevoDestino.columna);
        System.Windows.MessageBox.Show("resultado= "+resultado);
        System.Windows.MessageBox.Show("nuevoDestino= "+nuevoDestino);

        Iterator<Posicion> iterador = resultado.iterator();
        while (iterador.hasNext()){
            Posicion pal = iterador.next();
            if (pal.columna==nuevoDestino.columna && pal.fila==nuevoDestino.fila){
                esposible=true;
            }
        }
        resultado.clear();
        System.Windows.MessageBox.Show("resultadoSIPOTE= "+resultado);
        //Habría que comprobar aquí que hay fichas por medio o eso se haría en otro sitio?
        return esposible;

    }
      public String tipoPieza(){
        return "Alfil";
    }
    
     public String toString() {
         return "Alfil " + color.name();
    }

  }
}
