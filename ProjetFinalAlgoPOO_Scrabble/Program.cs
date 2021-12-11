using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Joueur michel = new Joueur(nom: "Michel");
            Console.WriteLine(michel.ToString());

            Joueur patrick = new Joueur("Patrick", 15, new List<string> {"BONJOUR"}, new List<Jeton> {new Jeton('y')});
            Console.WriteLine(patrick.ToString());
            
            Joueur benjamin = new Joueur(path: @"C:\Users\legco\Source\Repos\l-eg116\ProjetFinalAlgoPOO_Scrabble\ProjetFinalAlgoPOO_Scrabble\Joueurs.txt");
            Console.WriteLine(benjamin.ToString());

            benjamin.Score += 5;
            benjamin.TrouveMot("mandibule");
            benjamin.DonnerJeton(new Jeton('y'));
            benjamin.DonnerJeton(new Jeton('k'));
            benjamin.EnleverJeton(new Jeton('e'));

            Console.WriteLine(benjamin.ToString());
        }
    }
}
