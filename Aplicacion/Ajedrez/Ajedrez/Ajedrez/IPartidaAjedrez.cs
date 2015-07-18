using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Ajedrez
{
   public interface IPartidaAjedrez
    {
        static enum Color { Blancas, Negras };

        Jugador empezar();
        void guardarMovimiento(String nombre, Movimientos mov);
    }
}
