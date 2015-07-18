using System;
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
        ArrayList<Movimiento> resultado=new ArrayList<>();
        Boolean encontrado = false;
        
        /*1. - Vamos a buscar la primera ficha que encontremos
         * en el tablero y que puede moverse.
         * 2. - Una vez confirmado que esa ficha puede moverse
         * vamos a moverla de manera aleatoria entre los movimientos
         * posibles que tiene
         */

            while (!encontrado)
                {
               // pos.setFila(rd.nextInt(7));
                //pos.setColumna(rd.nextInt(7));
                
//                if((tab.estado.get(pos.toString()) != null) && (tab.estado.get(pos.toString()).color == ajedrez.Color.negra)){
                    /*tenemos una posición del tablero con una pieza
                     * Ahora vemos si esa pieza tiene algún movimiento
                     * posible para realizar
                     */
                    //resultado será un arraylist con los posibles movimientos
                    //de la ficha seleccionada
                    List<Pieza> valuesList = new ArrayList<Pieza>(tab.piezas_negras.values());
                    int randomIndex = new Random().nextInt(valuesList.size());
                    Pieza randomValue = valuesList.get(randomIndex);
                    resultado = tab.getMovimientosPosibles(randomValue);
                    if (randomValue.tipoPieza().equals("Torre"))
                        System.Windows.MessageBox.Show("Movimientos torre: "+resultado);
                    //ahora entre esos movimientos posibles, vamos a seleccionar uno
                    
                    if(resultado !=null)
                    {
                        Iterator<Movimiento> iterador = resultado.iterator();
                        Movimiento m = null;
                        System.Windows.MessageBox.Show("size= " + resultado.size());
                        int aleatorio;
                        if (resultado.size()>0)
                            aleatorio = rd.nextInt(resultado.size())+1;
                        else
                            aleatorio = 0;
                        System.Windows.MessageBox.Show("aleatorio= " + aleatorio);
                        
                        for(int i=0; i <= aleatorio-1; i++){
                            m = iterador.next();
                        }
                        System.Windows.MessageBox.Show("m= " + m);
                            if (tab.esMovimientoPosible(m, tab.piezas_negras.get(randomValue.posicion.toString()))){
                                movimiento =new Movimiento(m.color,m.posActual,m.posDestino);
                                encontrado =true;
//                                break;
                            }

                        }
                    }               
             return movimiento;
            }

      }
}
