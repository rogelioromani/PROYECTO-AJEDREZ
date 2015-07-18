using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Ajedrez
{
   public interface IJugador
    {
        void preguntarNombre();
        void preguntarColorPiezas();

        Movimientos pedirMovimiento();
        Boolean puedeMover();
        void anotarPiezaPerdida(Pieza pieza);
    }
}
