using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Ajedrez
{
   public interface IPieza
    {
        Movimientos getMovimientosPosibles();
        Boolean esMovimientoPosible(Posicion NuevoDestino);
        void actualizarPosicion(Posicion, nuevaPosicion);
    }
}
