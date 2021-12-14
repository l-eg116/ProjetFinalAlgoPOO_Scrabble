using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

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

        public char[,] Poids
        {
            get { return this.poids; }
        }
        public Jeton[,] Jetons
        {
            get { return this.jetons; }
        }

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
            for(int i = 0; i < poids.GetLength(0); i++)
            {
                for(int j = 0; j < poids.GetLength(1); j++)
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
                }
            }
        }

        public bool TesterMot(string mot, int x, int y, char rot, Dictionnaire dico, List<string> out_mots_crees = null)
        {
            mot = Dictionnaire.RemoveDiacritics(mot.ToUpper());
            List<string> mots_crees = new List<string> { mot };

            switch(rot)
            {
                case HORIZONTAL:
                    if(y + mot.Length > 15)
                        return false;

                    for(int i = 0; i < mot.Length; i++)
                        if(this.jetons[x, y + i] == null/* || this.jetons[x, y + i].Lettre == mot[i]*/)
                        {
                            string mot_cree = mot[i].ToString();
                            int j = -1;
                            while(x + j >= 0 && this.jetons[x + j, y + i] != null)
                            {
                                mot_cree = this.jetons[x + j, y + i].Lettre + mot_cree;
                                j--;
                            }
                            j = 1;
                            while(x + j < 15 && this.jetons[x + j, y + i] != null)
                            {
                                mot_cree += this.jetons[x + j, y + i].Lettre;
                                j++;
                            }
                            /*if(mot_cree.Length > 1)*/
                            mots_crees.Add(mot_cree);
                        }
                        else return false;

                    int k = -1;
                    while(y + k >= 0 && this.jetons[x, y + k] != null)
                    {
                        mots_crees[0] = this.jetons[x, y + k].Lettre + mots_crees[0];
                        k--;
                    }
                    k = 1;
                    while(y + k < 15 && this.jetons[x, y + k] != null)
                    {
                        mots_crees[0] += this.jetons[x, y + k].Lettre;
                        k++;
                    }

                    break;
                case VERTICAL:
                    if(x + mot.Length > 15)
                        return false;
                    for(int i = 0; i < mot.Length; i++)
                        if(this.jetons[x + i, y] == null/* || this.jetons[x + i, y].Lettre == mot[i]*/)
                        {
                            string mot_cree = mot[i].ToString();
                            int j = -1;
                            while(y + j >= 0 && this.jetons[x + i, y + j] != null)
                            {
                                mot_cree = this.jetons[x + i, y + j].Lettre + mot_cree;
                                j--;
                            }
                            j = 1;
                            while(y + j < 15 && this.jetons[x + i, y + j] != null)
                            {
                                mot_cree += this.jetons[x + i, y + j].Lettre;
                                j++;
                            }
                            /*if(mot_cree.Length > 1)*/
                            mots_crees.Add(mot_cree);
                        }
                        else return false;

                    int n = -1;
                    while(x + n >= 0 && this.jetons[x + n, y] != null)
                    {
                        mots_crees[0] = this.jetons[x + n, y].Lettre + mots_crees[0];
                        n--;
                    }
                    n = 1;
                    while(x + n < 15 && this.jetons[x + n, y] != null)
                    {
                        mots_crees[0] += this.jetons[x + n, y].Lettre;
                        n++;
                    }

                    break;
                default:
                    return false;
            }

            foreach(string mot_cree in mots_crees)
                if(mot_cree.Length > 1 && !dico.Contient(mot_cree))
                    return false;

            if(out_mots_crees != null)
                out_mots_crees.AddRange(mots_crees);

            return true;
        }
    }
}
