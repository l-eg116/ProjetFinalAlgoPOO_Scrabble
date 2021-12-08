using System;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class SacJetons
    {
        private List<Jeton> sac = new List<Jeton> { };

        public int Taille
        {
            get { return sac.Count; }
        }
        public List<Jeton> Contenu
        {
            get { return this.sac; }
        }

        public SacJetons(string path = "Default_SacJetons.csv")
        {
            using(TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ",", ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                while(!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    char lettre = Convert.ToChar(fields[0]);
                    int valeur = Convert.ToInt32(fields[1]);
                    int quantite = Convert.ToInt32(fields[2]);

                    for(int i = 0; i < quantite; i++)
                        this.sac.Add(new Jeton(lettre, valeur));
                }
            }
        }

        public override string ToString()
        {
            string return_str = "";

            foreach(Jeton jeton in this.sac)
                return_str += jeton.ToString() + "\t";

            return return_str;
        }
    }
}
