﻿namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main_()
        {
            /*
            Plateau plateau = new Plateau();
            plateau.Afficher();
            Plateau.AfficherLegende();
            Console.WriteLine("\nCombien de joueurs vont jouer (2 à 4 joueurs) ?");
            int nombrejoueurs = Convert.ToInt32(Console.ReadLine());
            string nomjoueur = " ";
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
                nomjoueur = Console.ReadLine();
                joueurs.Add(new Joueur(nom: nomjoueur, score: 0));
                //Remplir les mains des joueurs ici
            }
            int compteur = 1;
            System.TimeSpan duration = new System.TimeSpan(0, 0, 6, 0);
            while(sac_jetons.Count(new SacJetons()) < 0) //petit probleme pour le décompte des jetons restants
            {
                DateTime heure_début = DateTime.Now;
                Console.Clear();
                plateau.Afficher();
                Plateau.AfficherLegende();
                if(compteur > nombrejoueurs)
                {
                    compteur -= nombrejoueurs;
                }
                Console.WriteLine("\nC'est le tour du joueur numéro " + compteur + " : " + nomjoueur.joueurs(compteur));//pour marquer le nom du joueur :/
                Console.WriteLine(sac_jetons.Count);
                Joueur.Afficher();
                Console.WriteLine("Que voulez-vous faire ? \n-Tapez 1 pour remplacer un de vos jetons\n-Tapez 2 pour placer horizontalement un mot\n-Tapez 3 pour placer un mot verticalement\n-Tapez 4 pour passer votre tour");
                int choix = Convert.ToInt32(Console.ReadLine());
                switch(choix)// PAS OUBLIER DE RAJOUTER UN TIMER (je vais me renseigner)
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
                DateTime heure_fin = DateTime.Now;
                if(heure_fin - heure_début > duration)
                {
                    Console.WriteLine("Temps écoulé, vous pourrez rejouer au prochain tour");
                    continue;
                }
            }
            for(int i = 1; i <= nombrejoueurs; i++)
            {
                DateTime heure_début = DateTime.Now;
                Console.Clear();
                plateau.Afficher();
                Plateau.AfficherLegende();
                if(compteur > nombrejoueurs)
                {
                    compteur -= nombrejoueurs;
                }
                Console.WriteLine("\nATTENTION DERNIER TOUR\nC'est le tour du joueur numéro " + compteur + " : " + nomjoueur.joueurs(compteur));//pour marquer le nom du joueur :/
                Console.WriteLine(sac_jetons.Count);
                Joueur.Afficher();
                Console.WriteLine("Que voulez-vous faire ?\n-Tapez 1 pour passer votre tour \n-Tapez 2 pour placer horizontalement un mot\n-Tapez 3 pour placer un mot verticalement");
                int choix = Convert.ToInt32(Console.ReadLine());
                switch(choix)
                {
                    case 1:
                        break;
                    case 2:
                        //Placer un mot horizontalement
                        break;
                    case 3:
                        //Placer un mot verticalement
                        break;
                }
                DateTime heure_fin = DateTime.Now;
                if(heure_fin - heure_début > duration)
                {
                    Console.WriteLine("Temps écoulé, vous avez passé votre chance, vous pourrez rejouer lors d'une autre partie");
                    continue;
                }
            }
            Console.Clear();
            Console.WriteLine("SCORES FINAUX\n");
            for(int i = 0; i < nombrejoueurs; i++)
            {
                Console.WriteLine(nomjoueur.joueurs(i) + " : " + score.joueurs + " points");
            }
            */
        }
    }
}
