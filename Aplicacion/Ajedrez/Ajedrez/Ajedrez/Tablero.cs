using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ajedrez.Piezas;

namespace Ajedrez.Ajedrez
{
   public class Tablero:ITablero
    {
    private Pieza pieza;
    
    private final Posicion posicion = new Posicion(0,0);
    private final Peon[] peon = new Peon[16];
    private final Alfil[] alfil = new Alfil[4];
    private final Torre[] torre = new Torre[4];
    private final Caballo[] caballo = new Caballo[4];
    private final Rey[] rey = new Rey[2];
    private final Reyna[] reyna = new Reyna[2];
    public final HashMap<String, Pieza> estado = new HashMap<>();
    public final HashMap<String, Pieza> piezas_negras = new HashMap<>();
    public final HashMap<String, Pieza> piezas_blancas = new HashMap<>();


    public Tablero()
    {
        // Declaramos los peones
        for(int i=0; i<8; i++){
            peon[i] = new Peon(new Posicion(1,i), Ajedrez.Color.negra);
            peon[i+8] = new Peon(new Posicion(6,i), Ajedrez.Color.blanca);
        }        
        // Declaramos los caballos
        caballo[0] = new Caballo(new Posicion(0,1), Ajedrez.Color.negra);
        caballo[1] = new Caballo(new Posicion(0,6), Ajedrez.Color.negra);
        caballo[2] = new Caballo(new Posicion(7,1), Ajedrez.Color.blanca);
        caballo[3] = new Caballo(new Posicion(7,6), Ajedrez.Color.blanca);
       
        // Declaramos los alfiles
        alfil[0] = new Alfil(new Posicion(0,2), Ajedrez.Color.negra);
        alfil[1] = new Alfil(new Posicion(0,5), Ajedrez.Color.negra);
        alfil[2] = new Alfil(new Posicion(7,2), Ajedrez.Color.blanca);
        alfil[3] = new Alfil(new Posicion(7,5), Ajedrez.Color.blanca);
       
        // Declaramos las torres
        torre[0] = new Torre(new Posicion(0,0), Ajedrez.Color.negra);
        torre[1] = new Torre(new Posicion(0,7), Ajedrez.Color.negra);
        torre[2] = new Torre(new Posicion(7,0), Ajedrez.Color.blanca);
        torre[3] = new Torre(new Posicion(7,7), Ajedrez.Color.blanca);
       
        // Declaramos las reynas
        rey[0] = new Rey(new Posicion(0,4), Ajedrez.Color.negra);
        rey[1] = new Rey(new Posicion(7,4), Ajedrez.Color.blanca);
       
        // Declaramos los reyes
        reyna[0] = new Reyna(new Posicion(0,3), Ajedrez.Color.negra);
        reyna[1] = new Reyna(new Posicion(7,3), Ajedrez.Color.blanca);
    }
   
    
    public Boolean esMovimientoPosible(Movimiento mov, Pieza pieza)
    {
        Boolean esposible=false;
        Iterator<Movimiento> iterador = this.getMovimientosPosibles(pieza).iterator();
        while (iterador.hasNext()){
            Movimiento m = iterador.next();
            if (m.posDestino.fila==mov.posDestino.fila && m.posDestino.columna==mov.posDestino.columna){
                esposible=true;
            }
        }
        return esposible;
    }
   
    public ArraySegment<Movimiento> getMovimientosPosibles(Pieza pieza)
    {
        ArraySegment<Movimiento> resultado=new ArraySegment<>();
        resultado.clear();
       
        if (pieza.tipoPieza().Equals("Peon")){
            resultado = getMovimientosPeon(pieza);
        }
       
        if (pieza.tipoPieza().Equals("Torre"))
            resultado = getMovimientosTorre(pieza);
       
        if (pieza.tipoPieza().Equals("Caballo"))
        {
            resultado = getMovimientosCaballo(pieza);
        }
       
        if (pieza.tipoPieza().Equals("Reyna"))
        {
            resultado = getMovimientosReyna(pieza);
        }
       
        if (pieza.tipoPieza().Equals("Alfil"))
        {
            resultado = getMovimientosAlfil(pieza);
        }
       
        if (pieza.tipoPieza().Equals("Rey"))
        {
            resultado = getMovimientosRey(pieza);  
        }
        return resultado;
    }
    private Boolean hayPieza(Posicion nueva)
    {
        return (estado.get(nueva.ToString()) != null);
    }
   
    public Pieza ejecutarMovimiento(Movimientos mov)
    {
        //pieza.actualizarPosicion();
//        if (esMovimientoPosible(mov))
//                pieza.actualizarPosicion(posicion);
        return pieza;
    }
   
     public void colocarPiezas()
    {
        // Colocamos los peones
        for(int i=0; i<8; i++){
            estado.put(new Posicion(1,i).ToString(), peon[i]);
            piezas_negras.put(new Posicion(1,i).ToString(), peon[i]);
            estado.put(new Posicion(6,i).ToString(), peon[i+8]);
            piezas_blancas.put(new Posicion(6,i).ToString(), peon[i+8]);
        }
        // Colocamos los caballos
        estado.put((new Posicion(0,1)).ToString(), caballo[0]);
        piezas_negras.put((new Posicion(0,1)).ToString(), caballo[0]);
        estado.put((new Posicion(0,6)).ToString(), caballo[1]);
        piezas_negras.put((new Posicion(0,6)).ToString(), caballo[1]);
        estado.put((new Posicion(7,1)).ToString(), caballo[2]);  
        piezas_blancas.put((new Posicion(7,1)).ToString(), caballo[2]);  
        estado.put((new Posicion(7,6)).ToString(), caballo[3]);
        piezas_blancas.put((new Posicion(7,6)).ToString(), caballo[3]);
       
        // Colocamos los alfiles
        estado.put((new Posicion(0,2)).ToString(), alfil[0]);
        piezas_negras.put((new Posicion(0,2)).ToString(), alfil[0]);
        estado.put((new Posicion(0,5)).ToString(), alfil[1]);
        piezas_negras.put((new Posicion(0,5)).ToString(), alfil[1]);
        estado.put((new Posicion(7,2)).ToString(), alfil[2]);
        piezas_blancas.put((new Posicion(7,2)).ToString(), alfil[2]);
        estado.put((new Posicion(7,5)).ToString(), alfil[3]);
        piezas_blancas.put((new Posicion(7,5)).ToString(), alfil[3]);
               
        // Colocamos las torres
        estado.put((new Posicion(0,0)).ToString(), torre[0]);
        piezas_negras.put((new Posicion(0,0)).ToString(), torre[0]);
        estado.put((new Posicion(0,7)).ToString(), torre[1]);
        piezas_negras.put((new Posicion(0,7)).ToString(), torre[1]);
        estado.put((new Posicion(7,0)).ToString(), torre[2]);  
        piezas_blancas.put((new Posicion(7,0)).ToString(), torre[2]);  
        estado.put((new Posicion(7,7)).ToString(), torre[3]);
        piezas_blancas.put((new Posicion(7,7)).ToString(), torre[3]);
       
        // Colocamos lo reyes
        estado.put((new Posicion(0,4)).ToString(), rey[0]);
        piezas_negras.put((new Posicion(0,4)).ToString(), rey[0]);
        estado.put((new Posicion(7,4)).ToString(), rey[1]);
        piezas_blancas.put((new Posicion(7,4)).ToString(), rey[1]);
       
        // Colocamos las reynas
        estado.put((new Posicion(0,3)).ToString(), reyna[0]);
        piezas_negras.put((new Posicion(0,3)).ToString(), reyna[0]);
        estado.put((new Posicion(7,3)).ToString(), reyna[1]);
        piezas_blancas.put((new Posicion(7,3)).ToString(), reyna[1]);
    }
   
    public boolean jugadorHaceJaqueMate(Jugador jug)
    {
        return true;
    }
   public Pieza comprobarPosicion(Posicion posicion)
    {
        return estado.get(posicion.ToString());
    }
    /*
        actualizarEstado:
            actualiza el diccionario estado con la posicion nueva de la pieza
            movida.
    */
    public void actualizarEstado(Posicion anterior, Posicion actual){
       
        if(estado.get(anterior.ToString()).color == Ajedrez.Color.negra)
        {
            piezas_negras.put(actual.ToString(), piezas_negras.get(anterior.ToString()));
            piezas_negras.remove(anterior.ToString());
        }
        else if(estado.get(anterior.ToString()).color == Ajedrez.Color.blanca)
        {
            piezas_blancas.put(actual.ToString(), piezas_blancas.get(anterior.ToString()));
            //piezas_blancas.put(anterior.ToString(), null);
            piezas_blancas.remove(anterior.ToString());
        }
        estado.put(actual.ToString(), estado.get(anterior.ToString()));
        estado.remove(anterior.ToString());
    }
   
    public ArraySegment<Movimiento> getMovimientosPosiblesBlancas()
    {
        ArraySegment<Movimiento> resultado = new ArraySegment<>();
       
        Pieza p;
        for (int i=0; i<7 ;i++)
        {
            for (int j=0; j<7; j++)
            {
                if (hayPieza((new Posicion(i,j))))
                {
                    p = this.estado.get(new Posicion(i,j).ToString());
                    if(p.color == Color.blanca)
                    {
                        resultado.addAll(getMovimientosPosibles(p));
                    }
                }
            }
        }
        return resultado;
    }
   
    public ArraySegment<Movimiento> getMovimientosPosiblesNegras()
    {
        ArraySegment<Movimiento> resultado = new ArraySegment<>();
       
        Pieza p;
        for (int i=0; i<7 ;i++)
        {
            for (int j=0; j<7; j++)
            {
                if (hayPieza((new Posicion(i,j))))
                {
                    p = this.estado.get(new Posicion(i,j).ToString());
                    if(p.color == Color.blanca)
                    {
                        resultado.addAll(getMovimientosPosibles(p));
                    }
                }
            }
        }
        return resultado;
    }
   
    public Boolean comprobarJaque(Pieza pieza)
    {
        Boolean jaque = false;
        ArraySegment<Movimiento> mov=new ArraySegment<>();
       
        // Miro para cada pieza si 
        if (pieza.tipoPieza().Equals("Torre"))
        {
            mov = getMovimientosTorre(pieza);
           
            for (int i=0; i<mov.size(); i++)
            {
                if (hayPieza(mov.get(i).posDestino))
                {
                    if ( (pieza.color != this.estado.get(mov.get(i).posDestino.ToString()).color) && ( this.estado.get(mov.Get(i).posDestino.ToString()).tipoPieza().ToString().Equals("Rey") ) )
                    {
                        jaque = true;
                        // le paso como argumento el rey que esta en jaque
                        System.Windows.MessageBox.Show("EL REY ESTA EN JAQUE!!");
                        comprobarJaqueMate(this.estado.get(mov.get(i).posDestino.ToString()),pieza);
                    }
                }
            }
        }
       
        if (pieza.tipoPieza().Equals("Alfil"))
        {
            mov = getMovimientosAlfil(pieza);
           
            for (int i=0; i<mov.size(); i++)
            {
                if (hayPieza(mov.get(i).posDestino))
                {
                    if ( (pieza.color != this.estado.get(mov.get(i).posDestino.ToString()).color) && ( this.estado.get(mov.get(i).posDestino.ToString()).tipoPieza().ToString().Equals("Rey") ) )
                    {
                        jaque = true;
                        // le paso como argumento el rey que esta en jaque
                        System.Windows.MessageBox.Show("EL REY ESTA EN JAQUE!!");
                        comprobarJaqueMate(this.estado.get(mov.get(i).posDestino.ToString()),pieza);
                    }
                }
            }
        }
        if (pieza.tipoPieza().Equals("Peon"))
        {
            mov = getMovimientosPeon(pieza);
           
            for (int i=0; i<mov.size(); i++)
            {
                if (hayPieza(mov.get(i).posDestino))
                {
                    if ( (pieza.color != this.estado.get(mov.get(i).posDestino.ToString()).color) && ( this.estado.get(mov.get(i).posDestino.ToString()).tipoPieza().ToString().Equals("Rey") ) )
                    {
                        jaque = true;
                        // le paso como argumento el rey que esta en jaque
                        System.Windows.MessageBox.Show("EL REY ESTA EN JAQUE!!");
                        comprobarJaqueMate(this.estado.get(mov.get(i).posDestino.ToString()),pieza);
                    }
                }
            }
        }    
       
        if (pieza.tipoPieza().Equals("Reyna"))
        {
            mov = getMovimientosReyna(pieza);
           
            for (int i=0; i<mov.size(); i++)
            {
                if (hayPieza(mov.get(i).posDestino))
                {
                    if ( (pieza.color != this.estado.get(mov.get(i).posDestino.ToString()).color) && ( this.estado.get(mov.get(i).posDestino.ToString()).tipoPieza().ToString().Equals("Rey") ) )
                    {
                        jaque = true;
                        // le paso como argumento el rey que esta en jaque
                        System.Windows.MessageBox.Show("EL REY ESTA EN JAQUE!!");
                        comprobarJaqueMate(this.estado.get(mov.get(i).posDestino.ToString()),pieza);
                    }
                }
            }
        }
       
        if (pieza.tipoPieza().Equals("Caballo"))
        {
            mov = getMovimientosCaballo(pieza);
           
            for (int i=0; i<mov.size(); i++)
            {
                if (hayPieza(mov.get(i).posDestino))
                {
                    if ( (pieza.color != this.estado.get(mov.get(i).posDestino.ToString()).color) && ( this.estado.get(mov.get(i).posDestino.ToString()).tipoPieza().ToString().Equals("Rey") ) )
                    {
                        jaque = true;
                        // le paso como argumento el rey que esta en jaque
                        System.Windows.MessageBox.Show("EL REY ESTA EN JAQUE!!");
                        comprobarJaqueMate(this.estado.get(mov.get(i).posDestino.ToString()),pieza);
                    }
                }
            }
        }
       
        return jaque;
    }
   
    public Boolean comprobarJaqueMate(Pieza pieza_en_jaque, Pieza pieza_amenaza)
    {
        ArraySegment<Movimiento> resultado = new ArraySegment<>();
        ArraySegment<Movimiento> movRey = new ArraySegment<>();
        ArraySegment<Movimiento> comprobacion = new ArraySegment<>();
        
        if (pieza_en_jaque.color == Color.negra)
        {
            resultado = getMovimientosPosiblesBlancas();
            comprobacion = getMovimientosPosiblesNegras();
        }
        else
        {
            resultado = getMovimientosPosiblesNegras();
            comprobacion = getMovimientosPosiblesBlancas();
        }
        // La posicion del rey amenazado se detecta bien
        int fila_aux = pieza_en_jaque.posicion.getFila();
        int col_aux = pieza_en_jaque.posicion.getColumna();
//        System.out.println("fila " + fila_aux);
//        System.out.println("columna " + col_aux);
//        System.out.println(resultado);
//        System.out.println(resultado.size());
       
       
        movRey = getMovimientosPosibles(pieza_en_jaque);
        
        int i = 0;
        int j = 0;
        Boolean jaqueMate = false;
        Boolean jaqueMateInt;
       
        while(i<movRey.size())
        {
            j = 0;
            jaqueMateInt = false;
            while(j<resultado.size() && !jaqueMateInt)
            {
                jaqueMateInt = false;
                if (movRey.get(i).posDestino.ToString().Equals(resultado.get(j).posDestino.ToString()))
                {
                    jaqueMateInt = true;
                }
                j++;
            }
            if (jaqueMateInt == true)
            {
                jaqueMate = true;
            }
            else
            {
                jaqueMate = false;
                break;
            }
            i++;
        }
        if (jaqueMate)
        {
            // Hay una pieza de las que defienden el rey que se pueden comer la pieza atacante
            i=0;
            while(i<comprobacion.size() && jaqueMate)
            {
                if (pieza_amenaza.posicion.ToString().Equals(comprobacion.get(i).posDestino.ToString()))
                {
                    jaqueMate = false;
                    //estado.get(anterior.ToString()).color == Ajedrez.Color.negra)
                    if (estado.get(comprobacion.get(i).posActual.ToString()).tipoPieza().ToString().Equals("Rey"))
                    {
                        // Habria que hacer movimientos futuros para comprobar si el rey se come la ficha atacante hay una ficha detras que se comeria al rey y por tanto jaque mate
                    }
                }
                i++;
            }
            // Se puede interponer alguna pieza en la trayectoria de la torre
            if (pieza_amenaza.tipoPieza().ToString().Equals("Torre"))
            {
                // estan en la misma columna, hay que ver que pieza se puede interponer
                if (pieza_amenaza.posicion.getColumna() == pieza_en_jaque.posicion.getColumna())
                {
                    if (pieza_amenaza.posicion.getFila() > pieza_en_jaque.posicion.getFila())
                    {
                        int f_aux = pieza_amenaza.posicion.getFila();
                        while (f_aux > pieza_en_jaque.posicion.getFila())
                        {
                            f_aux--;
                            
                        }
                        
                    }
                }
            }
            // Se puede interponer en la trayectoria del alfil que ataca
            if (pieza_amenaza.tipoPieza().ToString().Equals("Alfil"))
            {
                // estan en la misma columna, hay que ver que pieza se puede interponer
                if (pieza_amenaza.posicion.getColumna() == pieza_en_jaque.posicion.getColumna())
                {
                    //for 
                }
            }
            // Se puede interponer en la trayectoria de la reyna otra ficha
            if (pieza_amenaza.tipoPieza().ToString().Equals("Reyna"))
            {
                // estan en la misma columna, hay que ver que pieza se puede interponer
                if (pieza_amenaza.posicion.getColumna() == pieza_en_jaque.posicion.getColumna())
                {
                    //for 
                }
            }
            
        }
        if (jaqueMate)
            System.Windows.MessageBox.Show("JAQUE MATEEEEEEEE ");
        return jaqueMate;
    }
   
    public ArraySegment<Movimiento> getMovimientosPeon(Pieza pieza)
    {
         ArraySegment<Movimiento> resultado=new ArraySegment<>();
         resultado.clear();
         if (pieza.tipoPieza().Equals("Peon")){
            // Hay que comprobar las 1 casilla
            //Color color = this.col;
           
            int f_aux = pieza.posicion.getFila();
            int c_aux = pieza.posicion.getColumna(); //Obtenemos la posición dentro del array
            // Primera posicion posible
            if((f_aux > 0)&& (pieza.color == Color.blanca))
            {
                if (f_aux == 6){
                    if(!hayPieza(new Posicion(f_aux - 2, c_aux))){
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux - 2, c_aux)));
                    }
                }
                f_aux=f_aux-1;
                if(!hayPieza(new Posicion(f_aux, c_aux))){
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    if(c_aux<7 && c_aux>0){
                        if(hayPieza(new Posicion(f_aux, c_aux+1)) && (pieza.color != this.estado.get(new Posicion(f_aux, c_aux+1).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                        if(hayPieza(new Posicion(f_aux, c_aux-1)) && (pieza.color != this.estado.get(new Posicion(f_aux, c_aux-1).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                    }
                    else if(c_aux==7){                        
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                    }
                    else if(c_aux==0){
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                    }
                }
            }
            else if((f_aux < 7) && (pieza.color == Color.negra))
            {
                if (f_aux == 1){
                    if(!hayPieza(new Posicion(f_aux + 2, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux + 2, c_aux)));
                }
                f_aux = f_aux + 1;
                if(!hayPieza(new Posicion(f_aux, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                if(c_aux<7 && c_aux>0){
                    if(hayPieza(new Posicion(f_aux, c_aux+1)) && (pieza.color != this.estado.get(new Posicion(f_aux, c_aux+1).ToString()).color))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                    if(hayPieza(new Posicion(f_aux, c_aux-1)) && (pieza.color != this.estado.get(new Posicion(f_aux, c_aux-1).ToString()).color))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                }
                else if(c_aux==7){                        
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                }
                else if(c_aux==0){
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                }
            }
        }
        return resultado;
    }
      
    public ArraySegment<Movimiento> getMovimientosTorre(Pieza pieza)
    {
        ArraySegment<Movimiento> resultado=new ArraySegment<>();
        resultado.clear();
        if (pieza.tipoPieza().Equals("Torre"))
        {
            // Hay que comprobar las 1 casilla
            //Color color = this.col;
            int f_aux = pieza.posicion.getFila();
            int c_aux = pieza.posicion.getColumna(); //Obtenemos la posición dentro del array
            boolean ficha = false;
            // Primera posicion posible
            while((f_aux > 0) && !ficha){
                //Hacia atras
                f_aux--;
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                       
                    }
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
            }
            ficha=false;
           
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna();
            while((f_aux < 7) && !ficha){
               
                //Hacia delante
                f_aux++;
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    }                    
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
            }
            ficha=false;
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna();
            while((c_aux > 0) && !ficha){
                // Hacia izquiera
                c_aux--;
                if(!hayPieza(new Posicion(f_aux, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                else
                {
                    ficha=true;
                }
            }
            ficha=false;
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna();
            while((c_aux < 7) && !ficha){
                // Hacia derecha
                c_aux++;
                if(!hayPieza(new Posicion(f_aux, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                else
                {
                    ficha=true;
                }
            }  
        }
        return resultado;
    }
   
    public ArraySegment<Movimiento> getMovimientosCaballo(Pieza pieza)
    {
        ArraySegment<Movimiento> resultado=new ArraySegment<>();
        resultado.clear();
       if (pieza.tipoPieza().Equals("Caballo"))
        {
            Boolean ficha = false;
            int f_aux = pieza.posicion.getFila();
            int c_aux = pieza.posicion.getColumna(); //Obtenemos la posición dentro del array
            if ((f_aux - 1 >= 0)&&(c_aux + 2 <= 7))
            {
                f_aux = f_aux - 1;
                c_aux = c_aux + 2;
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    }
            }
 
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna(); //Obtenemos la posición dentro del array
            // Segunda posiciones posibles
            if ((f_aux + 1 <= 7)&&(c_aux + 2 <= 7))
            {        
                f_aux = f_aux + 1;
                c_aux = c_aux + 2;
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    }
            }
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna(); //Obtenemos la posición dentro del array
            // Tercera posiciones posibles
            if ((f_aux - 1 >= 0)&&(c_aux - 2 >= 0))
            {
                f_aux = f_aux - 1;
                c_aux = c_aux - 2;
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    }
            }
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna(); //Obtenemos la posición dentro del array
       
            // Cuarta posicion posible
            if ((f_aux + 1 <= 7)&&(c_aux - 2 >= 0))
            {        
                f_aux = f_aux + 1;
                c_aux = c_aux - 2;
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    }
            }
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna(); //Obtenemos la posición dentro del array
           
            // Quinta posicion posible
            if ((f_aux + 2 <= 7)&&(c_aux + 1 <= 7))
            {        
                f_aux = f_aux + 2;
                c_aux = c_aux + 1;
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    }
            }
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna(); //Obtenemos la posición dentro del array
            // Sexta posiciones posibles
            if ((f_aux + 2 <= 7)&&(c_aux - 1 >= 0))
            {        
                f_aux = f_aux + 2;
                c_aux = c_aux - 1;
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    }
            }
       
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna(); //Obtenemos la posición dentro del array
            // Septima posiciones posibles
            if ((f_aux - 2 >= 0)&&(c_aux + 1 <= 7))
            {        
                f_aux = f_aux - 2;
                c_aux = c_aux + 1;
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    }
            }
       
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna(); //Obtenemos la posición dentro del array
            // Octava posiciones posibles
            if ((f_aux - 2 >= 0)&&(c_aux - 1 >= 0))
            {        
                f_aux = f_aux - 2;
                c_aux = c_aux - 1;
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    }
            }
        }
       return resultado;
    }
   
    public ArraySegment<Movimiento> getMovimientosReyna(Pieza pieza)
    {
        ArraySegment<Movimiento> resultado=new ArraySegment<>();
        resultado.clear();
        if (pieza.tipoPieza().Equals("Reyna"))
        {
            Boolean ficha = false;
            int f_aux = pieza.posicion.getFila();
            int c_aux = pieza.posicion.getColumna();      
                while ((f_aux >= 0) && (c_aux <= 7) && !ficha) {
                    f_aux--;
                    c_aux++;
                    if (( !(f_aux < 0) )  && ( !(c_aux >7) ))
                    {
                        if(!hayPieza(new Posicion(f_aux, c_aux)))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        else if(hayPieza(new Posicion(f_aux, c_aux)))
                        {
                            if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                                resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                            ficha=true;
                        }
                        else
                        {
                            ficha=true;
                        }   
                    }   
                }
            //Esquina inferior derecha
            //Partimos del punto inicial para volver a mirar
            ficha = false;
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna();
            while ((f_aux <= 7) && (c_aux <= 7) && !ficha) {
                f_aux++;
                c_aux++;
                if (( !(f_aux > 7) )  && ( !(c_aux > 7) ))
                {
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
                }
            }
            ficha = false;
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna();
            while((f_aux <= 7) && (c_aux >= 0) && !ficha){
                //Esquina superior izquierda
                f_aux++;
                c_aux--;
                if (( !(f_aux > 7) )  && ( !(c_aux < 0) ))
                {
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
                }
            }
            ficha = false;
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna();
            while((f_aux >= 0) && (c_aux >= 0) && !ficha){
                //Esquina inferior izquierda
                f_aux--;
                c_aux--;
                if (( !(f_aux < 0) )  && ( !(c_aux < 0) ))
                {
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
                }
            }
            ficha = false;
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna();
            while(f_aux >= 0 && !ficha){
                //Hacia atras
                f_aux--;
                if (!(f_aux<0))
                {
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
                }
            }
        ficha = false;
        f_aux = pieza.posicion.getFila();
        c_aux = pieza.posicion.getColumna();
        while(f_aux <= 7 && !ficha){
            //Hacia delante
            f_aux++;
                if (!(f_aux>7))
                {
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
                }
        }
        ficha = false;
        f_aux = pieza.posicion.getFila();
        c_aux = pieza.posicion.getColumna();
        while(c_aux >= 0 && !ficha){
            // Hacia izquiera
            c_aux--;
                if (!(c_aux<0))
                {
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
                }
        }
        ficha = false;
        f_aux = pieza.posicion.getFila();
        c_aux = pieza.posicion.getColumna();
        while(c_aux <= 7 && !ficha){
            // Hacia derecha
            c_aux++;
                if (!(c_aux>7))
                {
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
                }
        }
        }
        return resultado;
    }
  
     public ArraySegment<Movimiento> getMovimientosRey(Pieza pieza)
    {
        ArraySegment<Movimiento> resultado=new ArraySegment<>();
        resultado.clear();
       
        if (pieza.tipoPieza().Equals("Rey"))
        {
            int f_aux = pieza.posicion.getFila();
            int c_aux = pieza.posicion.getColumna();
            if((f_aux > 0) && (f_aux < 7) && (c_aux > 0) && (c_aux < 7)){
            //posicion media
                if(!hayPieza(new Posicion(f_aux, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux+1).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                       
                    }
                if(!hayPieza(new Posicion(f_aux+1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux)));
                       
                    }
                 if(!hayPieza(new Posicion(f_aux-1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux)));
                       
                    }
                if(!hayPieza(new Posicion(f_aux-1, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux-1).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux-1)));
                       
                    }
                if(!hayPieza(new Posicion(f_aux, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux-1).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                       
                    }
                if(!hayPieza(new Posicion(f_aux+1, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux-1).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux-1)));
                       
                    }
                if(!hayPieza(new Posicion(f_aux+1, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux+1).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux+1)));
                       
                    }
               
                if(!hayPieza(new Posicion(f_aux-1, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux+1).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux+1)));
                       
                    }
               
        }
        else if((c_aux -1 < 0) && (f_aux-1 <0)){
         //esquina superior izquierda
            if(!hayPieza(new Posicion(f_aux, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux+1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux+1, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux+1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux+1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux)));
                       
                    }
           
        }
        else if((c_aux - 1 < 0) && (f_aux + 1 > 7)){
         //esquina inferior izquierda
            if(!hayPieza(new Posicion(f_aux, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux+1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux-1, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux+1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux+1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux-1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux)));
                       
                    }
           
        }
        else if((c_aux +1 > 7) && (f_aux +1 > 7))
        {
            //esquina inferior derecha
            if(!hayPieza(new Posicion(f_aux, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux-1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux-1, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux-1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux-1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux-1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux -1, c_aux)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux -1, c_aux)));
                       
                    }
           
        }
        else if((c_aux +1 > 7) && (f_aux -1 < 0)){
            //esquina superior derecha
            if(!hayPieza(new Posicion(f_aux+1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux-1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux+1, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux-1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux-1)));
                       
                    }
           
           
        }
        else if(c_aux - 1 < 0 ){
            //Lateral izquierdo
            if(!hayPieza(new Posicion(f_aux+1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux-1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux+1, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux+1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux+1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux+1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux-1, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux+1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux+1)));
                       
                    }
                      
        }
        else if(c_aux + 1 > 7){
            //Lateral derecho
            if(!hayPieza(new Posicion(f_aux+1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux+1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux-1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux+1, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux-1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux-1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux-1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux-1, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux-1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux-1)));
                       
                    }
           
                }
        else if(f_aux + 1 > 7){
            //Inferior
            if(!hayPieza(new Posicion(f_aux-1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux-1, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux+1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux+1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux+1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux-1, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux-1, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux-1, c_aux-1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux-1, c_aux-1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux-1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                       
                    }
           
        }
        else if(f_aux - 1 < 0){
            //Superior
            if(!hayPieza(new Posicion(f_aux+1, c_aux)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux-1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux-1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux+1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux+1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux+1, c_aux-1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux-1)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux-1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux-1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux-1)));
                       
                    }
            if(!hayPieza(new Posicion(f_aux+1, c_aux+1)))
                    resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux+1)));
                else if(hayPieza(new Posicion(f_aux+1, c_aux+1)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux+1, c_aux+1).ToString()).color))
                           resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux+1, c_aux+1)));
                       
                    }       
        }        
        }
        return resultado;
    }
    public ArraySegment<Movimiento> getMovimientosAlfil(Pieza pieza)
    {
        ArraySegment<Movimiento> resultado=new ArraySegment<>();
        resultado.clear();
            if (pieza.tipoPieza().Equals("Alfil"))
        {
            Boolean ficha = false;
                int f_aux = pieza.posicion.getFila();
                int c_aux = pieza.posicion.getColumna();      
                while ((f_aux >= 0) && (c_aux <= 7) && !ficha) {
                    
                    f_aux--;
                    c_aux++;
                    if (( !(f_aux < 0) )  && ( !(c_aux > 7) )) 
                        if(!hayPieza(new Posicion(f_aux, c_aux)))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        else if(hayPieza(new Posicion(f_aux, c_aux)))
                        {
                            if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                                resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                            ficha=true;
                        }
                        else
                        {
                            ficha=true;
                        }
                    }
            //Esquina inferior derecha
            //Partimos del punto inicial para volver a mirar
            ficha = false;
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna();
            while ((f_aux <= 7) && (c_aux <= 7) && !ficha) {
                f_aux++;
                c_aux++;
                if (( !(f_aux > 7) )  && ( !(c_aux > 7) )) 
                {
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
                }
            }
            ficha = false;
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna();
            while((f_aux <= 7) && (c_aux >= 0) && !ficha){
                //Esquina superior izquierda
                f_aux++;
                c_aux--;
                if (( !(c_aux < 0) )  && ( !(f_aux > 7) )) 
                {
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
                }
            }
            ficha = false;
            f_aux = pieza.posicion.getFila();
            c_aux = pieza.posicion.getColumna();
            while((f_aux >= 0) && (c_aux >= 0) && !ficha){
                //Esquina inferior izquierda
                f_aux--;
                c_aux--;
                if (( !(f_aux < 0) )  && ( !(c_aux < 0) ))
                {
                    if(!hayPieza(new Posicion(f_aux, c_aux)))
                        resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                    else if(hayPieza(new Posicion(f_aux, c_aux)))
                    {
                        if((pieza.color != this.estado.get(new Posicion(f_aux, c_aux).ToString()).color))
                            resultado.add(new Movimiento(pieza.color, pieza.posicion, new Posicion(f_aux, c_aux)));
                        ficha=true;
                    }
                    else
                    {
                        ficha=true;
                    }
                }
            }
        }
            return resultado;
    }

   }
}
