using culebrita.BIcolaEnlazada;
using culebrita.Cola_Lista;
using culebrita.ColaArreglo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita
{
    class Game
    {
        public static void salir()
        {
            Console.WriteLine("\n Presione una tecla para salir...");
            Console.ReadKey(true);

            Environment.Exit(0);
        }

        public void Start()
        {
            var tamañoPantalla = new Size(45, 10);
            Console.WindowHeight = tamañoPantalla.Height + 2;
            Console.WindowWidth = tamañoPantalla.Width + 2;
            String prompt = "JUEGO DE LA CULEBRA COMELONA.\n ¿CON CUAL TIPO DE COLA QUIERES JUGAR?";
            String[] options = { "BIcola", "Cola Lista", "Cola Circular", "Cola Lineal", "Salir" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    new CulebraConBicola().culebritaTest();
                    break;
                case 1:
                    new CulebraColaConLista().culebritaTest();
                    break;
                case 2:
                    new CulebraConColaCircular().culebritaTest();
                    break;
                case 3:
                    new CulebraConColaLineal().culebritaTest();
                    break;
                case 4:
                    salir();
                    break;
            }
        }
    }
}
