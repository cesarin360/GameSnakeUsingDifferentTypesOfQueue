using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita
{
    class Menu
    {
        private int SelectedIndex;
        private String[] Options;
        private string Prompt;
        public Menu(String prompt, String[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        public void DisplayOptions()
        {
            Console.WriteLine(Prompt);
            for(int i = 0; i < Options.Length; i++)
            {
                String currentOption = Options[i];
                String prefix;
                if(i  == SelectedIndex)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine($"{prefix} << {currentOption} >>");
            }
            Console.ResetColor();
        }

        public int  Run()
        {
            ConsoleKey KeyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                KeyPressed = keyInfo.Key;

                if (KeyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if(SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (KeyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (KeyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}
