using Microsoft.VisualBasic.FileIO;
using System;

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
                                case CENTRE:
                                    this.poids[i, j] = CENTRE;
                                    break;
                                case MOT_TRIPLE:
                                    this.poids[i, j] = MOT_TRIPLE;
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
        /// Afficher le plateau du scrabble en couleur
        /// </summary>
        public void Afficher()
        {
            for(int i = 0; i < poids.GetLength(0); i++)
            {
                for (int j = 0; j < poids.GetLength(1); j++)
                {
                    switch (poids[i, j])
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
    }
}
