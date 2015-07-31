using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ajedrez.Ajedrez
{
    public class Movimientos
    {
        public  HashMap<Pieza, Movimiento> movimientos= new HashMap<>();
        public ArrayList listado_movimientos = new  ArrayList();
    

    public Movimientos()
    {
        
    }
    
    public String getUltimoMovimiento()
    {
        return listado_movimientos.Get(listado_movimientos.size()-1);
    }
    
    public void anadirMovimiento(Pieza pieza, Movimiento movimiento)
    {
        listado_movimientos.Add(pieza.tipoPieza()+" "+movimiento);
       
    }
  }

}
