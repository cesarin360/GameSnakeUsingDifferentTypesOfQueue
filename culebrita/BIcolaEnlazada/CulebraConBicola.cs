using Colas.Clases.BIcolaEnlazada;
using Colas.Clases.Cola_Lista;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;

namespace culebrita.BIcolaEnlazada
{
    class CulebraConBicola
    {
        
        private static bool MoverLaCulebrita1(BiCola culebra, Point posiciónObjetivo,
            int longitudCulebra, Size screenSize)
        {
            Nodo lista;
            lista = culebra.primero;
            Point lastPoint = (Point)culebra.finalBicola();

            int pause;
            pause = 0;
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

            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");

            culebra.ponerFinal(posiciónObjetivo);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            //quitar cola
            if (culebra.numElementosBicola() > longitudCulebra)
            {
                Point removePoint = (Point)culebra.quitarFrente();
                
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }

        private static Point MostrarComida1(Size screenSize, BiCola culebra)
        {
            var lugarComida = Point.Empty;
            Point cabezaCulebra = (Point)culebra.finalBicola();
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
            Console.Title = "Culebrita con BIcola";
            DirectionKey direction = new DirectionKey();
            var punteo = 0;
            var velocidad = 100;
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(60, 20);
            var bicola = new BiCola();
            var longitudCulebra = 20;
            var posiciónActual = new Point(0, 9);

            bicola.ponerFrente(posiciónActual);
            var dirección = DirectionKey.Direction.Derecha;

            direction.DibujaPantalla(tamañoPantalla);
            direction.MuestraPunteo(punteo);

            while (MoverLaCulebrita1(bicola, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                if (velocidad > 0) Thread.Sleep(velocidad);
                dirección = direction.ObtieneDireccion(dirección);
                posiciónActual = direction.ObtieneSiguienteDireccion(dirección, posiciónActual);

                if (posiciónActual.Equals(posiciónComida))
                {
                    posiciónComida = Point.Empty;
                    longitudCulebra++;
                    punteo += 10;
                    direction.MuestraPunteo(punteo);
                    Console.Beep();
                    velocidad -= 3;
                }

                if (posiciónComida == Point.Empty)
                {
                    posiciónComida = MostrarComida1(tamañoPantalla, bicola);
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
