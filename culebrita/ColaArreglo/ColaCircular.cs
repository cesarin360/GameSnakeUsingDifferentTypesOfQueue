using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colas.Clases.ColaArreglo
{
    class ColaCircular
    {
        public int fin;
        private static int MAXTAMQ = 9999;
        public int frente;
        public int ultimo;

        public Object[] listaCola;

        private int siguiente(int r)
        {
            return (r + 1) % MAXTAMQ;

        }

        public ColaCircular()
        {
            frente = 0;
            fin = MAXTAMQ - 1;
            ultimo = 0;
            listaCola = new Object[MAXTAMQ];
        }

        public bool colaVacia()
        {
            return frente == siguiente(fin);
        }

        public bool colaLlena()
        {
            return frente == siguiente(siguiente(fin));
        }

        public void insertar(Object elemento)
        {
            if (!colaLlena())
            {
                fin = siguiente(fin);
                listaCola[fin] = elemento;
                ultimo++;
            }
            else
            {
                throw new Exception("Overflow de la cola");
            }

        }

        public Object quitar()
        {
            if (!colaVacia())
            {
                Object tm = listaCola[frente];
                listaCola[frente] = null;
                frente = siguiente(frente);
                ultimo--;
                return tm;
            }
            else
            {
                throw new Exception("Cola vacia");
            }
        }

        public void borrarCola()
        {
            fin = 0;
            fin = MAXTAMQ - 1;
        }

        public Object frenteCola()
        {
            if (!colaVacia())
            {
                return listaCola[fin];
            }
            else
            {
                throw new Exception("Cola vacia");
            }
        }
    }//end class
}
