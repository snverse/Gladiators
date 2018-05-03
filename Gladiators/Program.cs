using System;
using System.Dynamic;

namespace Gladiators
{
    class Program
    {
        static int Main(string[] args)
        {
            // game reactor loop
            while (true)
            {
                ColorText("Welcome to Gladiators!", ConsoleColor.Green);
                ColorText("Press L key to start a local game.", ConsoleColor.Yellow);
                ColorText("Press X key to exit the game.", ConsoleColor.Yellow);
                string keyPress = Prompt();

                switch (keyPress)
                {
                    case "x":
                    case "X":
                        ColorText("Thank you for playing!", ConsoleColor.Magenta);
                        System.Threading.Thread.Sleep(2000);
                        return 0;

                    case "l":
                    case "L":
                        LocalGame();
                        break;
                }
            }
        }

        private static void LocalGame()
        {
            ColorText("The available weapons are:", ConsoleColor.Yellow);
            ColorText(Fighter.GetWeaponList(), ConsoleColor.Yellow);
            string weapon = Prompt();

            ColorText("The available offhands are:", ConsoleColor.Yellow);
            ColorText(Fighter.GetOffhandList(), ConsoleColor.Yellow);
            string offhand = Prompt();

            Fighter playerGladiator = new Fighter(weapon, offhand);
            Fighter systemGladiator = new Fighter();

            ColorText(string.Format("You're using:\n{0}.", playerGladiator.GetEquips()), ConsoleColor.Yellow);
            ColorText(string.Format("Enemy is using:\n{0}.", systemGladiator.GetEquips()), ConsoleColor.Yellow);

            while (true)
            {
                // Chat  phase
                string enemyReport = string.Format("ENEMY: {0}", systemGladiator.getHealth());
                string hpReport = string.Format("HP: {0}", playerGladiator.getHealth());

                ColorText("------------------------------", ConsoleColor.Red);
                ColorText(enemyReport, ConsoleColor.Yellow);
                ColorText(hpReport, ConsoleColor.Yellow);

                // Damage phase
                systemGladiator.SetDamage(playerGladiator.GetDamage());
                if (systemGladiator.getHealth() < 1)
                {
                    ColorText("YOU SLAYED THE ENEMY!", ConsoleColor.Green);
                    return;
                }

                playerGladiator.SetDamage(systemGladiator.GetDamage());
                if (playerGladiator.getHealth() < 1)
                {
                    ColorText("YOU GOT SLAYED", ConsoleColor.Red);
                    return;
                }

                Console.ReadKey();
            }
        }

        // output in non default color and reset
        static void ColorText(string text, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static string Prompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("> ");
            Console.ResetColor();
            return Console.ReadLine();
        }
    }
}
