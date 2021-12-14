using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau plat = new Plateau(@"C:\Users\legco\Source\Repos\l-eg116\ProjetFinalAlgoPOO_Scrabble\ProjetFinalAlgoPOO_Scrabble\Test_Plateau2.txt");
            Dictionnaire dict = new Dictionnaire();
            SacJetons sac = new SacJetons();
            Console.WriteLine(sac.ToString());
            Console.ReadKey();

            while(true)
            {
                Console.Clear();
                Console.WriteLine(plat.ToString());

                Console.WriteLine();

                Console.Write("mot: ");
                string mot = Console.ReadLine();
                Console.Write("x: ");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.Write("y: ");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.Write("rot: ");
                char rot = Convert.ToChar(Console.ReadLine().ToUpper());
                List<string> mots = new List<string> { };

                Console.WriteLine();

                Console.WriteLine(plat.PoserMot(mot, x, y, rot, dict, mots));
                Console.ReadKey();
            }
        }
    }
}
