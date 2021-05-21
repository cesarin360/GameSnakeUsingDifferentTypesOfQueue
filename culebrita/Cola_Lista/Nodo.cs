using System;
using System.Collections.Generic;
using System.Text;

namespace Colas.Clases.Cola_Lista
{
    class Nodo
    {
        public Object elemento;
        public Nodo siguiente;
        public Nodo(Object dato)
        {
            elemento = dato;
            siguiente = null;
        }
    }
}
