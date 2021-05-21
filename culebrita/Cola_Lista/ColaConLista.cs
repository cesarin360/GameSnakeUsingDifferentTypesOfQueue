using System;
using System.Collections.Generic;
using System.Text;

namespace Colas.Clases.Cola_Lista
{
    class ColaConLista
    {
        public Nodo primero;
        public Nodo ultimo;
        int tam;
        //constructor:: crear cola vacia
        public ColaConLista()
        {
            primero = null;
            ultimo = null;
            tam = 0;
        }
        //verificar si esta vacia la cola
        public bool ColaVacia()
        {
            return (primero == null);
        }
        //insertarmos por el final de la cola
        public void Insertar(Object elemento)
        {
            Nodo nuevo;
            nuevo = new Nodo(elemento);
            if (ColaVacia())
            {
                primero = nuevo;
            }
            else
            {
                ultimo.siguiente = nuevo;
            }
            ultimo = nuevo;
        }
        ///quitar elemento
        ///
        public Object quitar()
        {
            Object aux;
            if (!ColaVacia())
            {
                aux = primero.elemento;
                primero = primero.siguiente;
            }
            else
            {
                throw new Exception("Error porque la cola esta vacía");
            }
            return aux;
        }
        //vaicar la cola o liberar todos los nodos
        public void borrarCola()
        {
            for (; primero != null;)
            {
                primero = primero.siguiente;
            }
        }
        //devolver el valor que esta el frenete de la cola
        public Object frenteCola()
        {
            if (ColaVacia())
            {
                throw new Exception("Error porque la cola esta vacía");
            }
            return (ultimo.elemento);
        }

        public int numElementosLista()
        {
            int n;
            Nodo a = primero;
            if (ColaVacia())
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
    }
}

