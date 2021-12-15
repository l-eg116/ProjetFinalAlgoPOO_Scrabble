using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Jeu
    {
        static Plateau plateau;
        static List<Joueur> joueurs = new List<Joueur> { };
        static SacJetons sac_jetons;
        static Dictionnaire dictionnaire;


        public static void Main_()
        {
            plateau = new Plateau();
            plateau.Afficher();
            Plateau.AfficherLegende();
            Console.WriteLine("\nCombien de joueurs vont jouer (2 à 4 joueurs) ?");
            int nombrejoueurs = Convert.ToInt32(Console.ReadLine());
            for(int i = 1; i <= nombrejoueurs; i++)
            {
                if(i == 1)
                {
                    Console.WriteLine("Nom du " + i + "er joueur : ");
                }
                else
                {
                    Console.WriteLine("Nom du " + i + "eme joueur : ");
                }
                string nomjoueur = Console.ReadLine();
                joueurs.Add(new Joueur(nom: nomjoueur, score: 0));

            }
            plateau.Afficher();
            Plateau.AfficherLegende();

        }
    }
}
