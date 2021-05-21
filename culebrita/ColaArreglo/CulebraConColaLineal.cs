using Colas.Clases.ColaArreglo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace culebrita.ColaArreglo
{
    class CulebraConColaLineal
    {
        private static bool MoverLaCulebrita1(ColaLineal culebra, Point posiciónObjetivo,
            int longitudCulebra, Size screenSize)
        {
            var lastPoint = (Point)culebra.frenteCola();


            if (lastPoint.Equals(posiciónObjetivo)) return true;

            int i = culebra.listaCola.Length - 1;
            do
            {
                if (culebra.listaCola[i] != null)
                {
                    if (culebra.listaCola[i].Equals(posiciónObjetivo)) return false;
                }
                i--;
            } while (i > 0);

            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");

            culebra.insertar(posiciónObjetivo);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            // Quitar cola
            if (culebra.ultimo > longitudCulebra)
            {
                var removePoint = (Point)culebra.quitar();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }

        private static Point MostrarComida1(Size screenSize, ColaLineal culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.frenteCola();
            var rnd = new Random();
            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                Point[] s = culebra.listaCola.OfType<Point>().ToArray();
                if (s.All(p => p.X != x || p.Y != y)
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                }

            } while (lugarComida == Point.Empty);

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");

            return lugarComida;
        }
        public void culebritaTest()
        {
            Console.Title = "Culebrita con Cola Lineal";
            DirectionKey direction = new DirectionKey();
            var punteo = 0;
            var velocidad = 80;
            var posiciónComida = Point.Empty;
            var tamañoPantalla = new Size(60, 20);
            ColaLineal n = new ColaLineal();
            var longitudCulebra = 3;
            var posiciónActual = new Point(0, 9);

            n.insertar(posiciónActual);
            var dirección = DirectionKey.Direction.Derecha;

            direction.DibujaPantalla(tamañoPantalla);
            direction.MuestraPunteo(punteo);

            while (MoverLaCulebrita1(n, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                if (velocidad > 0)  Thread.Sleep(velocidad);
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
