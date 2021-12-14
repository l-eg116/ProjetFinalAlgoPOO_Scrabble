using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau plat = new Plateau();
            plat.Afficher();
            Plateau.AfficherLegende();
            Console.WriteLine("Combien de joueurs vont jouer (2 à 4 joueurs) ?");
            int nombrejoueurs = Convert.ToInt32(Console.ReadLine());
            switch (nombrejoueurs)
            {
                case 1:
                    Console.WriteLine("Choix impossible, veuillez choisir un nombre de joueurs entre 2 et 4");
                    break;
                case 2:
                    DeuxJoueurs();
                    break;
                case 3:
                    TroisJoueurs();
                    break;
                case 4:
                    QuatreJoueurs();
                    break;
                
            }
        }
        static void DeuxJoueurs()
        {
            Console.WriteLine("Nom du premier joueur : ");
            string nomjoueur1 = Console.ReadLine();
            Joueur joueur1 = new Joueur(nomjoueur1);

            Console.WriteLine("\nNom du second joueur : ");
            string nomjoueur2 = Console.ReadLine();
            Joueur joueur2 = new Joueur(nomjoueur1);
        }
        static void TroisJoueurs()
        {
            Console.WriteLine("Nom du premier joueur : ");
            string nomjoueur1 = Console.ReadLine();
            Joueur joueur1 = new Joueur(nomjoueur1);

            Console.WriteLine("Nom du deuxième joueur : ");
            string nomjoueur2 = Console.ReadLine();
            Joueur joueur2 = new Joueur(nomjoueur1);

            Console.WriteLine("Nom du troisième joueur : ");
            string nomjoueur3 = Console.ReadLine();
            Joueur joueur3 = new Joueur(nomjoueur1);
        }
        static void QuatreJoueurs()
        {
            Console.WriteLine("Nom du premier joueur : ");
            string nomjoueur1 = Console.ReadLine();
            Joueur joueur1 = new Joueur(nomjoueur1);

            Console.WriteLine("Nom du deuxième joueur : ");
            string nomjoueur2 = Console.ReadLine();
            Joueur joueur2 = new Joueur(nomjoueur1);

            Console.WriteLine("Nom du troisième joueur : ");
            string nomjoueur3 = Console.ReadLine();
            Joueur joueur3 = new Joueur(nomjoueur1);

            Console.WriteLine("Nom du quatrième joueur : ");
            string nomjoueur4 = Console.ReadLine();
            Joueur joueur4 = new Joueur(nomjoueur1);
        }
    }
}
