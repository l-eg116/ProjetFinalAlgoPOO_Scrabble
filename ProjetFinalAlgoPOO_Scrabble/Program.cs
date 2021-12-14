using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau plat = new Plateau(@"C:\Users\33782\Source\Repos\ProjetFinalAlgoPOO_Scrabble\ProjetFinalAlgoPOO_Scrabble\Test_Plateau2.txt");
            plat.Afficher();
            
            Console.WriteLine("\nAvec : \n");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" et ");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" : MOT COMPTE DOUBLE ");

            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" : MOT COMPTE TRIPLE");

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" : LETTRE COMPTE DOUBLE");

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" : LETTRE COMPTE TRIPLE");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(" : AUCUN BONUS");
        }
    }
}
