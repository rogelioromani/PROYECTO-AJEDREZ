using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Ajedrez
{
     
     public abstract class Pieza:
    {
        public Posicion posicion;
        public Color color;

        public Pieza(Posicion pos, Color col)
        {
            this.posicion = pos;
            this.color = col;
        }

        public void actualizarPosicion(Posicion nuevaPosicion)
        {
            posicion.setColumna(nuevaPosicion.columna);
            posicion.setFila(nuevaPosicion.fila);
        }

        public void MostrarTodas()
       {
        
       }
      public String tipoPieza(){
        return null;
      }
     public String toString(){
        return null;    
       }
    }
}
