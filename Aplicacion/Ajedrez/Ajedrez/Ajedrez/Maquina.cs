﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Ajedrez
{
   public class Maquina
    {
        Tablero tab;
        public Maquina(Tablero t)
        {
            this.tab = t;
        }

        public Movimiento hacerMovimiento(){
        
        Random rd = new Random();
        Posicion pos = new Posicion(1,1);
        Movimiento movimiento = new Movimiento();
        ArraySegment<Movimiento> resultado=new ArraySegment<>();
        Boolean encontrado = false;
        
        /*1. - Vamos a buscar la primera ficha que encontremos
         * en el tablero y que puede moverse.
         * 2. - Una vez confirmado que esa ficha puede moverse
         * vamos a moverla de manera aleatoria entre los movimientos
         * posibles que tiene
         */

            while (!encontrado)
                {
               // pos.setFila(rd.Next(7));
                //pos.setColumna(rd.Next(7));
                
//                if((tab.estado.get(pos.toString()) != null) && (tab.estado.get(pos.toString()).color == ajedrez.Color.negra)){
                    /*tenemos una posición del tablero con una pieza
                     * Ahora vemos si esa pieza tiene algún movimiento
                     * posible para realizar
                     */
                    //resultado será un arraylist con los posibles movimientos
                    //de la ficha seleccionada
                    List<Pieza> valuesList = new ArraySegment<Pieza>(tab.piezas_negras.values());
                    int randomIndex = new Random().Next(valuesList.size());
                    Pieza randomValue = valuesList.Get(randomIndex);
                    resultado = tab.getMovimientosPosibles(randomValue);
                    if (randomValue.tipoPieza().Equals("Torre"))
                        System.Windows.MessageBox.Show("Movimientos torre: "+resultado);
                    //ahora entre esos movimientos posibles, vamos a seleccionar uno
                    
                    if(resultado !=null)
                    {
                        Iterator<Movimiento> iterador = resultado.iterator();
                        Movimiento m = null;
                        System.Windows.MessageBox.Show("size= " + resultado.Size());
                        int aleatorio;
                        if (resultado.size()>0)
                            

                            aleatorio = rd.Next(resultado.size())+1;
                        else
                            aleatorio = 0;
                        System.Windows.MessageBox.Show("aleatorio= " + aleatorio);
                        
                        for(int i=0; i <= aleatorio-1; i++){
                            m = iterador.next();
                        }
                        System.Windows.MessageBox.Show("m= " + m);
                            if (tab.esMovimientoPosible(m, tab.piezas_negras.get(randomValue.Posicion.toString()))){
                                movimiento = new Movimiento(m.color, m.PosActual, m.PosDestino);
                                encontrado =true;
//                                break;
                            }

                        }
                    }               
             return movimiento;
            }
       
      }
}
