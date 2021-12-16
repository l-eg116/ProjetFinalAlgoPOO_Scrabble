using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Plateau
    {
        private char[,] poids = new char[15,15];
        private Jeton[,] jetons = new Jeton[15,15];

        private const char CENTRE = 'C';
        private const char LETTRE_DOUBLE = 'd';
        private const char LETTRE_TRIPLE = 't';
        private const char MOT_DOUBLE = 'D';
        private const char MOT_TRIPLE = 'T';
        private const char RIEN = '.';

        public const char HORIZONTAL = 'H';
        public const char VERTICAL = 'V';

        /// <summary>
        /// Matrice des poids du plateau
        /// </summary>
        public char[,] Poids
        {
            get { return this.poids; }
        }
        /// <summary>
        /// Matrice des jetons du plateau
        /// </summary>
        public Jeton[,] Jetons
        {
            get { return this.jetons; }
        }

        /// <summary>
        /// Initialise un nouveau plateau sans jetons et avec les poids par défault
        /// </summary>
        public Plateau()
        {
            using(TextFieldParser csvParser = new TextFieldParser("Default_PoidsPlateau.csv"))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ",", ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                try
                {
                    for(int i = 0; i < 15; i++)
                    {
                        string[] fields = csvParser.ReadFields();
                        for(int j = 0; j < 15; j++)
                            switch(Convert.ToChar(fields[j]))
                            {
                                case LETTRE_DOUBLE:
                                    this.poids[i, j] = LETTRE_DOUBLE;
                                    break;
                                case LETTRE_TRIPLE:
                                    this.poids[i, j] = LETTRE_TRIPLE;
                                    break;
                                case MOT_DOUBLE:
                                    this.poids[i, j] = MOT_DOUBLE;
                                    break;
                                case MOT_TRIPLE:
                                    this.poids[i, j] = MOT_TRIPLE;
                                    break;
                                case CENTRE:
                                    this.poids[i, j] = CENTRE;
                                    break;
                                default:
                                    this.poids[i, j] = RIEN;
                                    break;
                            }
                    }
                }
                catch(System.FormatException)
                {
                    for(int i = 0; i < 15; i++)
                        for(int j = 0; j < 15; j++)
                            this.poids[i, j] = RIEN;
                }
                catch(System.IndexOutOfRangeException)
                {
                    for(int i = 0; i < 15; i++)
                        for(int j = 0; j < 15; j++)
                            this.poids[i, j] = RIEN;
                }
            }

            this.jetons = new Jeton[15, 15];
        }
        /// <summary>
        /// Initialise un plateau à partir d'un fichier jetons et d'un fichier poids
        /// </summary>
        /// <param name="path_jetons">Chemin du fichier jetons</param>
        /// <param name="path_poids">Chemin du fichier poids</param>
        public Plateau(string path_jetons, string path_poids = "Default_PoidsPlateau.csv")
        {
            using(TextFieldParser csvParser = new TextFieldParser(path_jetons))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ",", ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                try
                {
                    for(int i = 0; i < 15; i++)
                    {
                        string[] fields = csvParser.ReadFields();
                        for(int j = 0; j < 15; j++)
                            if(char.IsLetter(Convert.ToChar(fields[j])))
                                this.jetons[i, j] = new Jeton(Convert.ToChar(fields[j]));
                    }
                }
                catch(System.IndexOutOfRangeException) { this.jetons = new Jeton[15, 15]; }
            }

            using(TextFieldParser csvParser = new TextFieldParser(path_poids))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ",", ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                try
                {
                    for(int i = 0; i < 15; i++)
                    {
                        string[] fields = csvParser.ReadFields();
                        for(int j = 0; j < 15; j++)
                            switch(Convert.ToChar(fields[j]))
                            {
                                case LETTRE_DOUBLE:
                                    this.poids[i, j] = LETTRE_DOUBLE;
                                    break;
                                case LETTRE_TRIPLE:
                                    this.poids[i, j] = LETTRE_TRIPLE;
                                    break;
                                case MOT_DOUBLE:
                                    this.poids[i, j] = MOT_DOUBLE;
                                    break;
                                case MOT_TRIPLE:
                                    this.poids[i, j] = MOT_TRIPLE;
                                    break;
                                case CENTRE:
                                    this.poids[i, j] = CENTRE;
                                    break;
                                default:
                                    this.poids[i, j] = RIEN;
                                    break;
                            }
                    }
                }
                catch(System.FormatException) { this.poids = new char[15, 15]; }
                catch(System.IndexOutOfRangeException) { this.poids = new char[15, 15]; }
            }
        }
        /// <summary>
        /// Mets un plateau sous forme de string pour debugage
        /// </summary>
        /// <returns>Un string represantant le plateau</returns>
        public override string ToString()
        {
            string return_str = "";

            return_str += $"this.jetons = \n";
            for(int i = 0; i < 15; i++)
            {
                for(int j = 0; j < 15; j++)
                    if(this.jetons[i, j] != null)
                        return_str += this.jetons[i, j].Lettre + " ";
                    else
                        return_str += RIEN + " ";
                return_str += "\n";
            }
            return_str += $"this.poids = \n";
            for(int i = 0; i < 15; i++)
            {
                for(int j = 0; j < 15; j++)
                    return_str += this.poids[i, j] + " ";
                return_str += "\n";
            }

            return return_str;
        }

        /// <summary>
        /// Afficher le plateau du scrabble en couleur
        /// </summary>
        public void Afficher()
        {
            Console.Write("   ");
            for(int i = 1; i < 10; i++)
                Console.Write($" {i} ");
            for(int i = 10; i < 16; i++)
                Console.Write($" {i}");
            Console.WriteLine();
            for(int i = 0; i < 15; i++)
            {
                if(i + 1 < 10)
                    Console.Write($" {i + 1} ");
                else
                    Console.Write($"{i + 1} ");
                for(int j = 0; j < 15; j++)
                {
                    switch(poids[i, j])
                    {
                        case MOT_TRIPLE:
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            break;
                        case RIEN:
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            break;
                        case LETTRE_DOUBLE:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            break;
                        case MOT_DOUBLE:
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            break;
                        case LETTRE_TRIPLE:
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case CENTRE:
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            break;
                    }
                    if(jetons[i, j] != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" " + jetons[i, j].Lettre + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(" + ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        /// <summary>
        /// Afficher la légende des couleurs du plateau
        /// </summary>
        public static void AfficherLegende()
        {
            //Console.WriteLine("\nAvec : \n");
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

        /// <summary>
        /// Vérifie si un mot à le droit d'être poser sur le plateau à une certaine position
        /// </summary>
        /// <param name="mot">Mot à essayer de poser</param>
        /// <param name="x">Coordonnée x du début du mot</param>
        /// <param name="y">Coordonnée y du début du mot</param>
        /// <param name="rot">Sens du mot ('H'/'V')</param>
        /// <param name="dico">Dictionnaire dans lequel les mots crées doivent exister</param>
        /// <param name="out_mots_crees">Liste à laquelle sera rajoutée les mots crées</param>
        /// <returns>Si le mot peut être posé</returns>
        public bool TesterMot(string mot, int x, int y, char rot, Dictionnaire dico,
            List<Jeton> out_jetons_utilises = null, List<string> out_mots_crees = null)
        {
            mot = Dictionnaire.RemoveDiacritics(mot.ToUpper());
            List<string> mots_crees = new List<string> { mot };
            List<Jeton> jetons_utilises = new List<Jeton> { };
            bool connecte = false;

            Jeton[,] temp_jetons = new Jeton[15,15];
            switch(rot)
            {
                case VERTICAL:
                    for(int x_ = 0; x_ < 15; x_++)
                        for(int y_ = 0; y_ < 15; y_++)
                            temp_jetons[x_, y_] = this.jetons[y_, x_];
                    int temp = x;
                    x = y;
                    y = temp;
                    break;
                case HORIZONTAL:
                    for(int x_ = 0; x_ < 15; x_++)
                        for(int y_ = 0; y_ < 15; y_++)
                            temp_jetons[x_, y_] = this.jetons[x_, y_];
                    break;
                default:
                    return false;
            }

            if(x < 0 || x >= 15 || y < 0 || y + mot.Length > 15)
                return false;

            connecte |= (y - 1 >= 0 && temp_jetons[x, y - 1] != null)
                || (y + mot.Length < 15 && temp_jetons[x, y + mot.Length] != null);

            for(int i = 0; i < mot.Length; i++)
                if(temp_jetons[x, y + i] == null || temp_jetons[x, y + i].Lettre == mot[i])
                {
                    if(temp_jetons[x, y + i] == null)
                        jetons_utilises.Add(new Jeton(mot[i]));

                    connecte |= (x - 1 >= 0 && temp_jetons[x - 1, y + i] != null)
                        || (x + 1 < 15 && temp_jetons[x + 1, y + i] != null)
                        || this.poids[x, y + i] == CENTRE;

                    string mot_cree = mot[i].ToString();
                    int j = -1;
                    while(x + j >= 0 && temp_jetons[x + j, y + i] != null)
                    {
                        mot_cree = temp_jetons[x + j, y + i].Lettre + mot_cree;
                        j--;
                    }
                    j = 1;
                    while(x + j < 15 && temp_jetons[x + j, y + i] != null)
                    {
                        mot_cree += temp_jetons[x + j, y + i].Lettre;
                        j++;
                    }
                    if(mot_cree.Length > 1 && temp_jetons[x, y + i] == null)
                        mots_crees.Add(mot_cree);
                }
                else return false;

            int k = -1;
            while(y + k >= 0 && temp_jetons[x, y + k] != null)
            {
                mots_crees[0] = temp_jetons[x, y + k].Lettre + mots_crees[0];
                k--;
            }
            k = mot.Length;
            while(y + k < 15 && temp_jetons[x, y + k] != null)
            {
                mots_crees[0] += temp_jetons[x, y + k].Lettre;
                k++;
            }

            if(!connecte)
                return false;
            foreach(string mot_cree in mots_crees)
                if(!dico.Contient(mot_cree))
                    return false;

            if(out_jetons_utilises != null)
                out_jetons_utilises.AddRange(jetons_utilises);
            if(out_mots_crees != null)
                out_mots_crees.AddRange(mots_crees);

            return true;
        }
        /// <summary>
        /// Pose un mot sur le plateau et retourne le nombre de points générés
        /// </summary>
        /// <param name="mot">Mot à poser</param>
        /// <param name="x">Coordonnée x du début du mot</param>
        /// <param name="y">Coordonnée y du début du mot</param>
        /// <param name="rot">Sens du mot ('H'/'V')</param>
        /// <param name="dico">Dictionnaire dans lequel les mots crées doivent exister</param>
        /// <param name="out_mots_crees">Liste à laquelle sera rajoutée les mots crées</param>
        /// <returns>Nombre de points du coup</returns>
        public int PoserMot(string mot, int x, int y, char rot, Dictionnaire dico,
            List<Jeton> out_jetons_utilises = null, List<string> out_mots_crees = null)
        {
            mot = Dictionnaire.RemoveDiacritics(mot.ToUpper());
            List<Jeton> jetons_utilises = new List<Jeton> { };
            List<string> mots_crees = new List<string> { };
            int score = 0;

            if(!this.TesterMot(mot, x, y, rot, dico, jetons_utilises, mots_crees))
                return -1;

            switch(rot)
            {
                case VERTICAL:
                    Jeton[,] temp_jetons = new Jeton[15,15];
                    for(int x_ = 0; x_ < 15; x_++)
                        for(int y_ = 0; y_ < 15; y_++)
                            temp_jetons[x_, y_] = this.jetons[y_, x_];
                    this.jetons = temp_jetons;

                    char[,] temp_poids = new char[15,15];
                    for(int x_ = 0; x_ < 15; x_++)
                        for(int y_ = 0; y_ < 15; y_++)
                            temp_poids[x_, y_] = this.poids[y_, x_];
                    this.poids = temp_poids;

                    int temp = x;
                    x = y;
                    y = temp;
                    break;
                case HORIZONTAL:
                    break;
                default:
                    return -1;
            }

            int score_mot;
            int mult_mot;
            int k;
            bool[] nouveaux = new bool[mot.Length];

            for(int i = 0; i < mot.Length; i++)
            {
                int y_ = y + i;
                nouveaux[i] = this.jetons[x, y_] == null;
                if(this.jetons[x, y_] != null)
                    continue;

                this.jetons[x, y_] = new Jeton(mot[i]);
                if(!((x - 1 >= 0 && this.jetons[x - 1, y_] != null)
                    || (x + 1 < 15 && this.jetons[x + 1, y_] != null)))
                    continue;

                score_mot = 0;
                mult_mot = 1;
                int n = -1;
                while(x + n >= 0 && this.jetons[x + n, y_] != null)
                {
                    switch(this.poids[x + n, y_])
                    {
                        case LETTRE_DOUBLE:
                            score_mot += this.jetons[x + n, y_].Valeur * 2;
                            break;
                        case LETTRE_TRIPLE:
                            score_mot += this.jetons[x + n, y_].Valeur * 3;
                            break;
                        case CENTRE:
                        case MOT_DOUBLE:
                            mult_mot = Math.Max(mult_mot, 2);
                            score_mot += this.jetons[x + n, y_].Valeur;
                            break;
                        case MOT_TRIPLE:
                            mult_mot = Math.Max(mult_mot, 3);
                            score_mot += this.jetons[x + n, y_].Valeur;
                            break;
                        default:
                            score_mot += this.jetons[x + n, y_].Valeur;
                            break;
                    }
                    n--;
                }
                n = 0;
                while(x + n <= 15 && this.jetons[x + n, y_] != null)
                {
                    switch(this.poids[x + n, y_])
                    {
                        case LETTRE_DOUBLE:
                            score_mot += this.jetons[x + n, y_].Valeur * 2;
                            break;
                        case LETTRE_TRIPLE:
                            score_mot += this.jetons[x + n, y_].Valeur * 3;
                            break;
                        case CENTRE:
                        case MOT_DOUBLE:
                            mult_mot = Math.Max(mult_mot, 2);
                            score_mot += this.jetons[x + n, y_].Valeur;
                            break;
                        case MOT_TRIPLE:
                            mult_mot = Math.Max(mult_mot, 3);
                            score_mot += this.jetons[x + n, y_].Valeur;
                            break;
                        default:
                            score_mot += this.jetons[x + n, y_].Valeur;
                            break;
                    }
                    n++;
                }
                score += score_mot * mult_mot;
            }

            score_mot = 0;
            mult_mot = 1;
            k = -1;
            while(y + k >= 0 && this.jetons[x, y + k] != null)
            {
                score_mot += this.jetons[x, y + k].Valeur;
                k--;
            }
            k = 0;
            while(y + k < 15 && this.jetons[x, y + k] != null)
            {
                if((k < nouveaux.Length && !nouveaux[k]) || k > mot.Length)
                    score_mot += this.jetons[x, y + k].Valeur;
                else
                    switch(this.poids[x, y + k])
                    {
                        case LETTRE_DOUBLE:
                            score_mot += this.jetons[x, y + k].Valeur * 2;
                            break;
                        case LETTRE_TRIPLE:
                            score_mot += this.jetons[x, y + k].Valeur * 3;
                            break;
                        case CENTRE:
                        case MOT_DOUBLE:
                            mult_mot = Math.Max(mult_mot, 2);
                            score_mot += this.jetons[x, y + k].Valeur;
                            break;
                        case MOT_TRIPLE:
                            mult_mot = Math.Max(mult_mot, 3);
                            score_mot += this.jetons[x, y + k].Valeur;
                            break;
                        default:
                            score_mot += this.jetons[x, y + k].Valeur;
                            break;
                    }
                k++;
            }
            score += score_mot * mult_mot;


            switch(rot)
            {
                case VERTICAL:
                    Jeton[,] temp_jetons = new Jeton[15,15];
                    for(int x_ = 0; x_ < 15; x_++)
                        for(int y_ = 0; y_ < 15; y_++)
                            temp_jetons[x_, y_] = this.jetons[y_, x_];
                    this.jetons = temp_jetons;

                    char[,] temp_poids = new char[15,15];
                    for(int x_ = 0; x_ < 15; x_++)
                        for(int y_ = 0; y_ < 15; y_++)
                            temp_poids[x_, y_] = this.poids[y_, x_];
                    this.poids = temp_poids;

                    int temp = x;
                    x = y;
                    y = temp;
                    break;
                case HORIZONTAL:
                    break;
                default:
                    return -1;
            }

            if(jetons_utilises.Count == 0)
                return -1;

            if(out_jetons_utilises != null)
                out_jetons_utilises.AddRange(jetons_utilises);
            if(out_mots_crees != null)
                out_mots_crees.AddRange(mots_crees);

            return score;
        }

        public List<string> TrouverPlace(string mot, Dictionnaire dico)
        {
            List<string> positions = new List<string> { };

            for(int x = 0; x < 15 - mot.Length; x++)
                for(int y = 0; y < 15 - mot.Length; y++)
                {
                    if(TesterMot(mot, x, y, HORIZONTAL, dico))
                        positions.Add($"x: {x + 1}, y: {y + 1}, rot: H");
                    if(TesterMot(mot, x, y, VERTICAL, dico))
                        positions.Add($"x: {x + 1}, y: {y + 1}, rot: V");
                }

            return positions;
        }

        /// <summary>
        /// Sauvegarde l'instance du plateau dans un fichier
        /// </summary>
        /// <param name="folder">Dossier dans lequel le fichier sera créé</param>
        /// <param name="file_name">Nom du fichier</param>
        public void SauvegarderJetons(string folder, string file_name = "Sauvegarde_Jetons.csv")
        {
            string path = System.IO.Path.Combine(folder, file_name);

            using(StreamWriter file = new StreamWriter(path))
            {
                int i = 1;
                foreach(Jeton jeton in this.jetons)
                    if(i++ % 15 == 0)
                        if(jeton != null)
                            file.Write(jeton.Lettre + "\n");
                        else
                            file.Write("_\n");
                    else
                        if(jeton != null)
                        file.Write(jeton.Lettre + ";");
                    else
                        file.Write("_;");
            }
        }
    }
}
