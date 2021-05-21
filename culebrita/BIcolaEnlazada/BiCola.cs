using Colas.Clases.Cola_Lista;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colas.Clases.BIcolaEnlazada
{
    class BiCola : ColaConLista
    {
        //insetar por el final la bicola
        public void ponerFinal(Object elemento)
        {
            Insertar(elemento);
        }

        //Insertar al frente
        public void ponerFrente(Object elemento)
        {
            Nodo a;
            a = new Nodo(elemento);
            if (ColaVacia())
            {
                ultimo = a;
            }
            a.siguiente = primero;
            primero = a;
        }

        //quitar elemento
        public Object quitarFrente()
        {
            return quitar();
        }
        //retirar el elemento al final
        //metodo propio de bicola
        //Es necesario hacer una iteracion de la bicola para
        //llegar del nodo anterior al final, para despues enlazar y ajustar
        //la cola
        public Object quitarFinal()
        {
            Object aux;
            if (!ColaVacia())
            {
                if(primero == ultimo)//solo tiene un nodo
                {
                    aux = quitar();

                }
                else
                {
                    //Cono no tiene elementos vamos a iterar 
                    Nodo a = primero;
                    while(a.siguiente != ultimo)
                    {
                        a = a.siguiente;
                    }
                    //Siguiente del nodo anterior lo vmaos a poner null
                    a.siguiente = null;
                    aux = ultimo.elemento;
                    ultimo = a;
                }
            }
            else
            {
                throw new Exception("la cola esta vacia");
            }
            return aux;
        }
        //retorna el valor que se encuentra en el primer elemento o frente de la cola

        public Object frenteBicola()
        {
            return frenteCola();
        }


        //Devolver el final de la cola 
        public Object finalBicola()
        {
            if (ColaVacia())
            {
                throw new Exception("Cola vacia");
            }
            return (ultimo.elemento);
        }

        //retorna si esta vacia la cola 
        public bool biColaVacia()
        {
            return ColaVacia();
        }

        public void borrarBicola()
        {
            borrarCola();
        }

        //conteo de elementos 
        public int numElementosBicola()
        {
            int n;
            Nodo a = primero;
            if (biColaVacia())
            {
                n = 0;
            }
            else
            {
                n = 1;
                while (a != ultimo)
                {
                    n++;
                    a = a.siguiente;
                }
            }
            return n;
        }

    }//end class
}
