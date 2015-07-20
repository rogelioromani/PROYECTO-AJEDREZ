using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.StringBuilder;
using System.Threading.Tasks;

namespace Ajedrez.Ajedrez
{
    public class Posicion
    {
        public int fila;
        public int columna;


        public Posicion(int f, int c)
        {
            fila = f;
            columna = c;
        }

        //Getters
        public int getFila()
        {
            return fila;
        }

        public int getColumna()
        {
            return columna;
        }

        //Setters
        public void setFila(int fila)
        {
            this.fila = fila;
        }

        public void setColumna(int columna)
        {
            this.columna = columna;
        }

        public String toString()
        {
            char[] c = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            char[] f = { '8', '7', '6', '5', '4', '3', '2', '1' };
            String s = new StringBuilder().Append(c[columna]).Append(f[fila]).ToString();
            return s;
        }

    }
}

