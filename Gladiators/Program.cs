using System;
using System.Dynamic;

namespace Gladiators
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorText("Welcome to Gladiators!", ConsoleColor.DarkYellow);
            Fighter playerGladiator;
            Fighter systemGladiator;

            // game reactor loop
            while (true)
            {
                ColorText("Press any key to start the game.", ConsoleColor.Red);
                Console.ReadKey();
                playerGladiator = CreateFighter();
                //systemGladiator = GenerateFigther();

            }
        }

        // output in non default color and reset
        static void ColorText(string text, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        // prompt user for input to build Fighter
        private static Fighter CreateFighter()
        {
            // weapon selection
            ColorText("What weapon would you like to use?", ConsoleColor.Yellow);
            Console.WriteLine("Available Weapons: ");
            Console.WriteLine(Fighter.GetWeaponList());
            Prompt();

            return Fighter();
            //offhand selection
        }

        // auto populate and return Fighter
        /*private static Fighter GenerateFighter()
        {

        }*/

        static void Prompt()
        {
            ColorText(">", ConsoleColor.Green);
        }
    }
}
