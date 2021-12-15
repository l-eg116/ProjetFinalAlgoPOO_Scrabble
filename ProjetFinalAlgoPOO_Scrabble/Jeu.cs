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

            Plateau plateau = new Plateau(@"C:\Users\33782\Source\Repos\ProjetFinalAlgoPOO_Scrabble\ProjetFinalAlgoPOO_Scrabble\Test_Plateau.txt");
            plateau.Afficher();
            Plateau.AfficherLegende();
            Console.WriteLine("\nCombien de joueurs vont jouer (2 à 4 joueurs) ?");
            int nombrejoueurs = Convert.ToInt32(Console.ReadLine());
            string nomjoueur = " ";
            for (int i = 1; i <= nombrejoueurs; i++)
            {
                if (i == 1)
                {
                    Console.WriteLine("Nom du " + i + "er joueur : ");
                }
                else
                {
                    Console.WriteLine("Nom du " + i + "eme joueur : ");
                }
                nomjoueur = Console.ReadLine();
                joueurs.Add(new Joueur(nom: nomjoueur, score: 0));
                //Remplir les mains des joueurs ici
            }
            int compteur = 1;
            while (sac_jetons.Count(new SacJetons()) < 0) //petit probleme pour le décompte des jetons restants
            {
                Console.Clear();
                plateau.Afficher();
                Plateau.AfficherLegende();
                if (compteur > nombrejoueurs)
                {
                    compteur -= nombrejoueurs;
                }
                Console.WriteLine("\nC'est le tour du joueur numéro " + compteur + " : " + nomjoueur.joueurs(compteur));//pour marquer le nom du joueur :/
                Console.WriteLine(sac_jetons.Count);
                Joueur.Afficher();
                Console.WriteLine("Que voulez-vous faire ? \n-Tapez 1 pour remplacer un de vos jetons\n-Tapez 2 pour placer horizontalement un mot\n-Tapez 3 pour placer un mot verticalement\n-Tapez 4 pour passer votre tour");
                int choix = Convert.ToInt32(Console.ReadLine());
                switch(choix)
                {
                    case 1:
                        //Remplacer un jeton
                        break;

                    case 2:
                        //Placer un mot horizontalement
                        break;

                    case 3:
                        //Placer un mot verticalement
                        break;

                    case 4:
                        break;
                }
            }


        }



    }
}
