using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Ajedrez
{
    public class Movimiento
    {
        public Ajedrez.Color color;
        private Posicion posActual;
        private Posicion posDestino;

        public Posicion PosDestino
        {
            get { return posDestino; }
            set { posDestino = value; }
        }

        public Posicion PosActual
        {
            get { return posActual; }
            set { posActual = value; }
        }
        
        public Movimiento()
        {
           
        }

        public  Movimiento(Color color, Posicion posicion, Posicion posicion0)
        {
            this.color = color;
            this.posActual = posicion;
            this.posDestino = posicion0;

        }
        public String toString()
        {
            return "(" + this.color + ", " + this.posActual + ", " + this.posDestino + ")";
        }
    }
}
