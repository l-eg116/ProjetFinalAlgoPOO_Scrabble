using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Jeu
    {
        private Plateau plateau;
        private List<Joueur> joueurs = new List<Joueur> { };
        private SacJetons sac_jetons;
        private Dictionnaire dictionnaire;


        static void Main(string[] args)
        {
            Plateau plat = new Plateau(@"C:\Users\33782\Source\Repos\ProjetFinalAlgoPOO_Scrabble\ProjetFinalAlgoPOO_Scrabble\Test_Plateau.txt");
            plat.Afficher();
            Plateau.AfficherLegende();
            Console.WriteLine("\nCombien de joueurs vont jouer (2 à 4 joueurs) ?");
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
            plat.Afficher();
            Plateau.AfficherLegende();



        }
        static void DeuxJoueurs()
        {
            Console.WriteLine("Nom du premier joueur : ");
            string nomjoueur1 = Console.ReadLine();
            int score = 0;
            Joueur joueur1 = new Joueur(nomjoueur1, score);
            joueur1.Afficher();

            Console.WriteLine("\nNom du second joueur : ");
            string nomjoueur2 = Console.ReadLine();
            int score2 = 0;
            Joueur joueur2 = new Joueur(nomjoueur2, score2);
            Console.WriteLine(joueur2.ToString());
        }
        static void TroisJoueurs()
        {
            Console.WriteLine("Nom du premier joueur : ");
            string nomjoueur1 = Console.ReadLine();
            Joueur joueur1 = new Joueur(nomjoueur1);
            joueur1.ToString();

            Console.WriteLine("Nom du deuxième joueur : ");
            string nomjoueur2 = Console.ReadLine();
            Joueur joueur2 = new Joueur(nomjoueur2);
            joueur2.ToString();

            Console.WriteLine("Nom du troisième joueur : ");
            string nomjoueur3 = Console.ReadLine();
            Joueur joueur3 = new Joueur(nomjoueur3);
            joueur3.ToString();
        }
        static void QuatreJoueurs()
        {
            Console.WriteLine("Nom du premier joueur : ");
            string nomjoueur1 = Console.ReadLine();
            Joueur joueur1 = new Joueur(nomjoueur1);
            joueur1.ToString();

            Console.WriteLine("Nom du deuxième joueur : ");
            string nomjoueur2 = Console.ReadLine();
            Joueur joueur2 = new Joueur(nomjoueur2);
            joueur2.ToString();

            Console.WriteLine("Nom du troisième joueur : ");
            string nomjoueur3 = Console.ReadLine();
            Joueur joueur3 = new Joueur(nomjoueur3);
            joueur3.ToString();

            Console.WriteLine("Nom du quatrième joueur : ");
            string nomjoueur4 = Console.ReadLine();
            Joueur joueur4 = new Joueur(nomjoueur4);
            joueur4.ToString();
        }
    }
}
