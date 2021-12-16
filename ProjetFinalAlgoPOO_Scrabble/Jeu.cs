using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Jeu
    {
        static Plateau plateau;
        static List<Joueur> joueurs = new List<Joueur> { };
        static SacJetons sac_jetons;
        static Dictionnaire dictionnaire;

        static void Main()
        {
            ChargerPartie();
            Sauvegarder();
            ChargerPartie();
        }
        /*
        public static void Main_()
        {

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
        }
        */

        static void CommencerPartie()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($" === Initialisation des joueurs === ");
            Console.ResetColor();
            Console.WriteLine("\n");

            Console.WriteLine("A combien voulez vous jouer ? (Recommandé 2 à 4)");
            int nombre_joueurs = 0;
            do
            {
                Console.Write(">>> ");
                try { nombre_joueurs = Convert.ToInt32(Console.ReadLine()); }
                catch(System.FormatException) { continue; }
            } while(nombre_joueurs <= 0);

            for(int i = 0; i < nombre_joueurs; i++)
            {
                Console.Write($"Nom du joueur n°{i + 1} >>> ");
                joueurs.Add(new Joueur(nom: Console.ReadLine()));
            }

            Console.WriteLine("\n => Initialisation des joueurs terminée, appuyez sur une touche pour continuer <=");
            Console.ReadKey();

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"=== Initialisation des constantes ===");
            Console.ResetColor();

            Console.WriteLine();

            Console.Write("Voulez vous utiliser un dictionnaire particulier ? (y/N)\n>>> ");
            switch(Console.ReadLine().ToLower())
            {
                case "y":
                case "yes":
                case "o":
                case "oui":
                    Console.Write("Chemin du dictionnaire >>> ");
                    dictionnaire = new Dictionnaire(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("=> Utilisation du dictionnaire intégré");
                    dictionnaire = new Dictionnaire();
                    break;
            }
            Console.Write("Voulez vous utiliser des poids de plateau particuliers ? (y/N)\n>>> ");
            switch(Console.ReadLine().ToLower())
            {
                case "y":
                case "yes":
                case "o":
                case "oui":
                    Console.Write("Chemin des poids >>> ");
                    plateau = new Plateau("Default_PlateauVide.csv", Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("=> Utilisation des poids intégrés");
                    plateau = new Plateau();
                    break;
            }
            Console.Write("Voulez vous utiliser un sac de jetons particulier ? (y/N)\n>>> ");
            switch(Console.ReadLine().ToLower())
            {
                case "y":
                case "yes":
                case "o":
                case "oui":
                    Console.Write("Chemin du sac de jetons >>> ");
                    sac_jetons = new SacJetons(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("=> Utilisation du sac intégré");
                    sac_jetons = new SacJetons();
                    break;
            }

            Console.WriteLine("\n => Initialisation terminée, appuyez sur une touche pour lancer la partie <=");
            Console.ReadKey();
        }
        static void ChargerPartie()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($" === Chargement d'une partie préexistante === ");
            Console.ResetColor();
            Console.WriteLine("\n");

            plateau = new Plateau();
            sac_jetons = new SacJetons();
            dictionnaire = new Dictionnaire();

            Console.Write("Chemin du fichier SAUVEGARDE_XXXXXX.csv >>> ");
            string path = Console.ReadLine();
            Console.WriteLine("");

            using(TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ",", ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                string dossier = "";
                while(!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    if(fields.Length >= 2)
                        switch(fields[0])
                        {
                            case "DOSSIER":
                                dossier = fields[1];
                                break;
                            case "Plateau":
                                plateau = new Plateau(System.IO.Path.Combine(dossier, fields[1]));
                                Console.WriteLine("> Plateau chargé !");
                                break;
                            case "SacJetons":
                                sac_jetons = new SacJetons(System.IO.Path.Combine(dossier, fields[1]));
                                Console.WriteLine("> SacJetons chargé !");
                                break;
                            case "Joueur":
                                joueurs.Add(new Joueur(path: System.IO.Path.Combine(dossier, fields[1])));
                                Console.WriteLine("> Joueur chargé !");
                                break;
                        }
                }
            }

            Console.WriteLine(" => Chargement terminé ! Appuyez sur une touche pour continuer <= ");
            Console.ReadKey();
        }
        static void Sauvegarder()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($" === Sauvegarde de la partie === ");
            Console.ResetColor();
            Console.WriteLine("\n");


            Console.Write("Chemin du dossier qui contiendra la sauvegarde >>> ");
            string folder_path = Console.ReadLine();
            Console.WriteLine("");
            int id = new Random().Next(999999);

            string path = System.IO.Path.Combine(folder_path, $"SAUVEGARDE_{id}.csv");
            using(StreamWriter file = new StreamWriter(path))
            {
                file.WriteLine($"DOSSIER;{folder_path}");

                file.WriteLine($"Plateau;Sauvegarde_{id}_Plateau.csv");
                plateau.SauvegarderJetons(folder_path, $"Sauvegarde_{id}_Plateau.csv");
                Console.WriteLine("> Plateau sauvegardé !");

                file.WriteLine($"SacJetons;Sauvegarde_{id}_SacJetons.csv");
                sac_jetons.Sauvegarder(folder_path, $"Sauvegarde_{id}_SacJetons.csv");
                Console.WriteLine("> SacJetons sauvegardé !");

                for(int i = 0; i < joueurs.Count; i++)
                {
                    file.WriteLine($"Joueur;Sauvegarde_{id}_Joueur{i}.csv");
                    joueurs[i].Sauvegarder(folder_path, $"Sauvegarde_{id}_Joueur{i}.csv");
                    Console.WriteLine($"> Joueur_{i} sauvegardé !");
                }
            }

            Console.WriteLine($" Sauvegarde générée sous : {path}");
            Console.WriteLine(" =>  Appuyez sur une touche pour quitter <= ");
            Console.ReadKey();
            System.Environment.Exit(0);
        }
    }
}
