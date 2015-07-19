using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajedrez.Ajedrez
{
    public class Movimientos
    {
        public final HashMap<Pieza, Movimiento> movimientos= new HashMap<>();
        public ArraySegment<String> listado_movimientos = new ArraySegment<String>();
    

    public Movimientos()
    {
        
    }
    
    public String getUltimoMovimiento()
    {
        return listado_movimientos.get(listado_movimientos.size()-1);
    }
    
    public void anadirMovimiento(Pieza pieza, Movimiento movimiento)
    {
        listado_movimientos.Add(pieza.tipoPieza()+" "+movimiento);
    }
  }

}
