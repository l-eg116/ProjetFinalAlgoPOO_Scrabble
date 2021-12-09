using Microsoft.VisualBasic.FileIO;
using System;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Plateau
    {
        private char[,] poids = new char[15,15];
        private Jeton[,] jetons = new Jeton[15,15];

        private const char LETTRE_DOUBLE = 'd';
        private const char LETTRE_TRIPLE = 't';
        private const char MOT_DOUBLE = 'D';
        private const char MOT_TRIPLE = 'T';
        private const char RIEN = ' ';

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
                catch(System.FormatException) { this.poids = new char[15, 15]; }
                catch(System.IndexOutOfRangeException) { this.poids = new char[15, 15]; }
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
    }
}
