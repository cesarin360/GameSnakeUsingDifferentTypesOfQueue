using System;
using System.Collections.Generic;
using System.Text;

namespace Colas.Clases.ColaArreglo
{
    class ColaLineal
    {
        public int fin;
        private static int MAXTAMQ = 9999;
        public int frente;
        public int ultimo;

        public Object[] listaCola;

        public ColaLineal()
        {
            frente = 0;
            fin = -1;
            listaCola = new object[MAXTAMQ];
        }
        public bool colaVacia()
        {
            return frente > fin;
        }

        public bool colaLlena()
        {
            return fin == MAXTAMQ - 1;
        }
            
        //Operaciones para trabajar con datos en la cola 
        public void insertar(Object elemento)
        {
            if (!colaLlena())
            {
                listaCola[++fin] = elemento;
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
                ultimo--; ;
                Object tm = listaCola[frente++];
                listaCola[frente-1] = null;
                
                return tm;
            }
            else
            {
                throw new Exception("Cola vacia");
            }
        }

        public void borrarCola()
        {
            frente = 0;
            fin = -1;
        }

        //frente cola
        public Object frenteCola()
        {
            if (!colaVacia())
            {
                return listaCola[fin];
            }
            else
            {
                throw new Exception("Coa Vacia");
            }
        }
    }//end class
}
