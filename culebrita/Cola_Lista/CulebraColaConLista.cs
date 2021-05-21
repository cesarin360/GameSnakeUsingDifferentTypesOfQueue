using Colas.Clases.Cola_Lista;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace culebrita.Cola_Lista
{
    class CulebraColaConLista
    {
        private static bool MoverLaCulebrita1(ColaConLista culebra, Point posiciónObjetivo,
           int longitudCulebra, Size screenSize)
        {
            Nodo lista;
            lista = culebra.primero;
            Point lastPoint = (Point)culebra.frenteCola();

            if (lastPoint.Equals(posiciónObjetivo)) return true;

            for (int i = 0; i <= longitudCulebra && lista != null; i++)
            {
                if (lista.elemento.Equals(posiciónObjetivo)) return false;
                lista = lista.siguiente;
            }
            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");

            culebra.Insertar(posiciónObjetivo);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            //quitar cola
            if (culebra.numElementosLista() > longitudCulebra)
            {
                Point removePoint = (Point)culebra.quitar();

                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }

        private static Point MostrarComida1(Size screenSize, ColaConLista culebra)
        {
            var lugarComida = Point.Empty;
            Point cabezaCulebra = (Point)culebra.frenteCola();
            Nodo lista;
            lista = culebra.primero;
            var rnd = new Random();
            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                Point point = (Point)lista.elemento;
                if (point.X != x || point.Y != y && Math.Abs(x - cabezaCulebra.X) 
                    + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                }
                lista = lista.siguiente;
            } while (lugarComida == Point.Empty);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");

            return lugarComida;
        }

        public void culebritaTest()
        {
            Console.Title = "Culebrita Cola con Lista";
            DirectionKey direction = new DirectionKey();
            var punteo = 0;
            var velocidad = 80;
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(60, 20);
            ColaConLista n = new ColaConLista();
            var longitudCulebra = 3;
            var posiciónActual = new Point(0, 9);

            n.Insertar(posiciónActual);
            var dirección = DirectionKey.Direction.Derecha;

            direction.DibujaPantalla(tamañoPantalla);
            direction.MuestraPunteo(punteo);

            while (MoverLaCulebrita1(n, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                if (velocidad > 0) Thread.Sleep(velocidad);
                dirección = direction.ObtieneDireccion(dirección);
                posiciónActual = direction.ObtieneSiguienteDireccion(dirección, posiciónActual);

                if (posiciónActual.Equals(posiciónComida))
                {
                    posiciónComida = Point.Empty;
                    longitudCulebra++; ;
                    punteo += 10;
                    direction.MuestraPunteo(punteo);
                    Console.Beep();
                    velocidad -= 3;
                }

                if (posiciónComida == Point.Empty)
                {
                    posiciónComida = MostrarComida1(tamañoPantalla, n);
                }
            }

            Console.ResetColor();
            Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
            Console.Write("Fin del Juego");
            Thread.Sleep(2000);
            new Game().Start();

        }

    }
}
