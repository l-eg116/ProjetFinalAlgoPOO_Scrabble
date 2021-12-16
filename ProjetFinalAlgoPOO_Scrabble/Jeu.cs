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
        static int tour;

        static void Main()
        {
            bool ok = false;
            do
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" =={ }== Scrabble =={ }== ");
                Console.ResetColor();
                Console.WriteLine("\n");

                Console.WriteLine("Bienvenue au Scrabble !\n");

                Console.WriteLine("[1] Commencer une nouvelle partie");
                Console.WriteLine("[2] Charge une partie précédente");
                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        CommencerPartie();
                        ok = true;
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        ChargerPartie();
                        ok = true;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            } while(!ok);

            string affichage = "";
            while(sac_jetons.Taille > 0)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" =={ }== Scrabble =={ }== ");
                Console.ResetColor();
                Console.WriteLine("\n");
                plateau.Afficher();
                Console.WriteLine("");
                int i_joueur = tour % joueurs.Count;
                joueurs[i_joueur].RemplirMain(sac_jetons);
                Console.WriteLine($"Tour {tour / joueurs.Count + 1}, {sac_jetons.Taille} jetons restant - Joueur n°{i_joueur + 1} : {joueurs[i_joueur].Nom}, {joueurs[i_joueur].Score} pts");
                Console.Write("Main >>> ");
                foreach(Jeton jet in joueurs[i_joueur].MainCourante)
                {
                    Console.Write("[ ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{jet.Lettre}");
                    Console.ResetColor();
                    Console.Write(" | ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{jet.Valeur} ");
                    Console.ResetColor();
                    Console.Write("] ");
                }
                Console.WriteLine("\n");
                if(affichage != "") Console.WriteLine(affichage + "\n");

                Console.Write("Entrez un mot pour le poser ou tapez '/' pour voir les commandes\n>>> ");
                string input = Console.ReadLine().ToLower();
                if(input.Length > 0 && input[0] != '/')
                {
                    int x = -1, y = -1;
                    char rot = ' ';
                    Console.WriteLine("Choisissez la postion du début du mot");
                    do
                    {
                        Console.Write("Ligne >>> ");
                        try { x = Convert.ToInt32(Console.ReadLine()) - 1; }
                        catch(System.FormatException) { continue; }
                    }
                    while(x < 0 || x >= 15);
                    do
                    {
                        Console.Write("Colonne >>> ");
                        try { y = Convert.ToInt32(Console.ReadLine()) - 1; }
                        catch(System.FormatException) { continue; }
                    }
                    while(y < 0 || y >= 15);
                    Console.WriteLine("Choisissez le sens du mot (H/V)");
                    do
                        switch(Console.ReadKey().Key)
                        {
                            case ConsoleKey.V:
                                rot = Plateau.VERTICAL;
                                break;
                            case ConsoleKey.H:
                                rot = Plateau.HORIZONTAL;
                                break;
                        }
                    while(rot != Plateau.HORIZONTAL && rot != Plateau.VERTICAL);

                    List<Jeton> jetons_utilises = new List<Jeton> { };
                    if(plateau.TesterMot(input, x, y, rot, dictionnaire, jetons_utilises))
                    {
                        Joueur copie_joueur = joueurs[i_joueur];
                        bool possible = true;
                        for(int i = 0; i < jetons_utilises.Count && possible; i++)
                            possible &= copie_joueur.EnleverJeton(jetons_utilises[i]) || copie_joueur.EnleverJeton(new Jeton('*'));
                        if(!possible)
                        {
                            Console.WriteLine("Vous n'avez pas les jetons pour poser ce mot");
                            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                            Console.ReadKey();
                            continue;
                        }
                        else
                        {
                            jetons_utilises.Clear();
                            List<string> mots_crees = new List<string> { };
                            int score = plateau.PoserMot(input, x, y, rot, dictionnaire, jetons_utilises, mots_crees);

                            for(int i = 0; i < jetons_utilises.Count && possible; i++)
                                possible &= joueurs[i_joueur].EnleverJeton(jetons_utilises[i]) || joueurs[i_joueur].EnleverJeton(new Jeton('*'));
                            foreach(string mot in mots_crees)
                                joueurs[i_joueur].TrouveMot(mot);
                            joueurs[i_joueur].Score += score;

                            Console.WriteLine($"Vous marquez {score} points !");
                            Console.Write("Jetons utilisés : ");
                            foreach(Jeton jet in jetons_utilises)
                                Console.Write(jet.Lettre + " ");
                            Console.Write("\nMots trouvés : ");
                            foreach(string mot in mots_crees)
                                Console.Write(mot.ToLower() + " ");
                            tour++;
                            Console.WriteLine("\n\nAppuyez sur une touche pour continuer...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vous ne pouvez pas poser ce mot ici !");
                        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                        Console.ReadKey();
                        continue;
                    }
                }
                else switch(input)
                    {
                        case "/":
                            affichage = "Liste des commandes :"
                                + "\n'/'             - Voir la liste des commandes"
                                + "\n'/legende'      - Voir la légende des cases du plateau"
                                + "\n'/passer'       - Passer son tour"
                                + "\n'/leaderboard'  - Voir la liste des joueurs et scores"
                                + "\n'/dico'         - Chercher un mot dans le dictionnaire"
                                + "\n'/mots'         - Montre les mots que vous avez formés"
                                + "\n'/sauvegarder'  - Sauvergarder la partie"
                                + "\n'/quitter'      - Quitter la partie";
                            break;
                        case "/legende":
                            Console.WriteLine();
                            Plateau.AfficherLegende();
                            Console.WriteLine("Appuyez sur une touche pour continuer...");
                            Console.ReadKey();
                            break;
                        case "/passer":
                            affichage = "";
                            Console.WriteLine("\nVous passez votre tour !\nAppuyez sur une touche pour continuer...");
                            tour++;
                            Console.ReadKey();
                            break;
                        case "/leaderboard":
                            affichage = " --- Leaderboard --- ";
                            foreach(Joueur joueur in joueurs)
                                affichage += $"\n{joueur.Nom} - {joueur.Score} pts, {joueur.MotTrouves.Count} mots trouvés";
                            break;
                        case "/dico":
                            affichage = "";
                            Console.Write("Mot à chercher >>> ");
                            if (dictionnaire.Contient(Console.ReadLine()))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n-> Ce mot est dans le dictionnaire");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\n-> Ce mot n'est pas dans le dictionnaire");
                                Console.ResetColor();
                            }
                                
                            Console.WriteLine("Appuyez sur une touche pour continuer...");
                            Console.ReadKey();
                            break;
                        case "/mots":
                            affichage = "Mots trouvés : ";
                            foreach(string mot in joueurs[i_joueur].MotTrouves)
                                affichage += mot.ToLower() + " ";
                            break;
                        case "/sauvegarder":
                            affichage = "";
                            Sauvegarder();
                            break;
                        case "/quitter":
                            affichage = "";
                            Sauvegarder();
                            System.Environment.Exit(0);
                            break;
                        case "///":
                            Console.Write("[ ? ] >>> ");
                            affichage = " >.> ";
                            foreach(string mot in dictionnaire.MotsPossibles(Console.ReadLine()))
                                affichage += mot.ToLower() + " ";
                            break;
                        default:
                            affichage = "";
                            break;
                    }
            }

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(" =={ }== Scrabble =={ }== ");
            Console.ResetColor();
            Console.WriteLine("\n");
            plateau.Afficher();
            Console.WriteLine("");
            Console.WriteLine("Partie terminée ! Merci d'avoir joué !");
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" --- Leaderboard --- ");
            Console.ResetColor();
            foreach(Joueur joueur in joueurs)
                Console.WriteLine($"\n{joueur.Nom} - {joueur.Score} pts, {joueur.MotTrouves.Count} mots trouvés");

            Console.WriteLine("\n\n\nAppuyez sur une touche pour quitter");
            Console.ReadKey();
        }

        /// <summary>
        /// Initialisation des joueurs et des paramètres de la partie
        /// </summary>
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

            tour = 0;

            Console.WriteLine("\n => Initialisation terminée, appuyez sur une touche pour lancer la partie <=");
            Console.ReadKey();
        }
        /// <summary>
        /// Relancer une partie sauvegardée
        /// </summary>
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
                            case "tour":
                                tour = Convert.ToInt32(fields[1]);
                                Console.WriteLine("> Tour chargé !");
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
        /// <summary>
        /// Place les informations de la partie dans un dossier
        /// </summary>
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

                file.WriteLine($"tour;{tour}");

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
            Console.WriteLine(" =>  Appuyez sur une touche pour continuer <= ");
            Console.ReadKey();
        }
    }
}
