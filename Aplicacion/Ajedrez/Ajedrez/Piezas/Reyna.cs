using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajedrez.Ajedrez;

namespace Ajedrez.Piezas
{
   public class Reyna:Pieza
    {
       Movimientos mov = new Movimientos();
    //Posicion pos;
    int fila_actual;
    int columna_actual;
    char[] filas = {'0','1','2','3','4','5','6','7','8'};
    char[] columnas = {'a','b','c','d','e','f','g','h'};
    Posicion[] result = new Posicion[64];
    ArraySegment<Posicion> resultado = new ArraySegment<>();
    Color col;

    /**
     *
     */
    
    public Reyna(Posicion pos, Color c)
    {
        super(pos,c);
        this.fila_actual = pos.getFila();
        this.columna_actual = pos.getColumna();
        this.color = c; 
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
    
    public Movimientos getMovimientosPosibles() 
    {
        //Al ser una reyna tenemos 8 posibles caminos que comprobar (las 4 esquinas y  los 4 horizaontales y verticales)

        //Esquina superior derecha
        int f_aux = posicion.getFila();
        int c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        System.Windows.MessageBox.Show("Columnas " + columnas.Length);
        System.Windows.MessageBox.Show("Filas " + columnas.Length);
        while ((f_aux > 0) && (c_aux < columnas.Length-1)) {
            f_aux--;
            c_aux++;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        //Esquina inferior derecha
        //Partimos del punto inicial para volver a mirar
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna();
        System.Windows.MessageBox.Show("mala: " + "f_aux= "+ f_aux + "c_aux= " + c_aux);
        while ((f_aux < filas.Length-2) && (c_aux < columnas.Length-1)) {
            f_aux++;
            c_aux++;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        while((f_aux < filas.Length-2) && (c_aux > 0)){
            //Esquina superior izquierda
            f_aux++;
            c_aux--;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        while((f_aux > 0) && (c_aux > 0)){
            //Esquina inferior izquierda
            f_aux--;
            c_aux--;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        while(f_aux > 0){
            //Hacia atras
            f_aux--;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        while(f_aux < filas.Length-2){
            //Hacia delante
            f_aux++;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        while(c_aux > 0){
            // Hacia izquiera
            c_aux--;
            resultado.add(new Posicion(f_aux, c_aux));
        }

        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        while(c_aux < columnas.Length -2){
            // Hacia derecha
            c_aux++;
            resultado.add(new Posicion(f_aux, c_aux));
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
        return "Reyna";
    }
   
    public String toString(){
        return "Reyna "+color.name();
    }
    }
}
