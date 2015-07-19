using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajedrez.Ajedrez;

namespace Ajedrez.Piezas
{
    public class Caballo:Pieza
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
    
    public Caballo(Posicion pos, Color c)
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
    }
        
    public Movimientos getMovimientosPosibles() 
    {
        // Hay que comprobar las 8 casillas a la que puede acceder el caballo
        int f_aux = posicion.getFila();
        int c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        // Primera posicion posible
        if ((f_aux - 1 > 0)&&(c_aux + 2 < columnas.Length-1))
        {
            f_aux = f_aux - 1;
            c_aux = c_aux + 2;
            resultado.add(new Posicion(f_aux, c_aux));
        }
 
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        // Segunda posiciones posibles
        if ((f_aux + 1 < filas.Length - 1)&&(c_aux + 2 < columnas.Length-1))
        {        
            f_aux = f_aux + 1;
            c_aux = c_aux + 2;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        // Tercera posiciones posibles
        if ((f_aux - 1 > 0)&&(c_aux - 2 > 0))
        {
            f_aux = f_aux - 1;
            c_aux = c_aux - 2;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        
        // Cuarta posicion posible
        if ((f_aux + 1 < filas.Length - 1)&&(c_aux - 2 > 0))
        {        
            f_aux = f_aux + 1;
            c_aux = c_aux - 2;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        
        // Quinta posicion posible
        if ((f_aux + 2 < filas.Length - 1)&&(c_aux + 1 < columnas.Length-1))
        {        
            f_aux = f_aux + 2;
            c_aux = c_aux + 1;
            resultado.add(new Posicion(f_aux, c_aux));
        }
       
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        // Sexta posiciones posibles
        if ((f_aux + 2 < filas.Length - 1)&&(c_aux - 1 > 0))
        {        
            f_aux = f_aux + 2;
            c_aux = c_aux - 1;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        
        // Septima posiciones posibles
        if ((f_aux - 2 > 0)&&(c_aux + 1 < columnas.Length-1))
        {        
            f_aux = f_aux - 2;
            c_aux = c_aux + 1;
            resultado.add(new Posicion(f_aux, c_aux));
        }
        
        f_aux = posicion.getFila();
        c_aux = posicion.getColumna(); //Obtenemos la posición dentro del array
        // Octava posiciones posibles
        if ((f_aux - 2 > 0)&&(c_aux - 1 > 0))
        {        
            f_aux = f_aux - 2;
            c_aux = c_aux - 1;
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
        return "Caballo";
    }
    
    public String toString(){
        return "Caballo "+color.name();
    }
 }
}
