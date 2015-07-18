using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Ajedrez
{
    public interface ITablero
    {
        Boolean esMovimientoPosible(Movimiento mov, Pieza pieza);
        Pieza ejecutarMovimiento(Movimientos mov);
        void colocarPiezas();
        Boolean jugadorHaceJaqueMate(Jugador jug);

    }
}
