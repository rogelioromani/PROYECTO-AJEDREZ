using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Ajedrez
{
     
     public abstract class Pieza
    {
        private Posicion posicion;

        public Posicion Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }
        private Color color;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

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
