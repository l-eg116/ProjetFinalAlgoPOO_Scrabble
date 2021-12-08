using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Linq;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Dictionnaire
    {
        private List<string> contenu = new List<string> { };
        private string langue = "unspecified";

        public List<string> Contenu
        {
            get { return this.contenu; }
        }
        public int Taille
        {
            get { return this.contenu.Count; }
        }
        public string Langue
        {
            get { return this.langue; }
        }

        public Dictionnaire(string path = "Default_Dictionnaire.txt")
        {
            using(TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { " ", ",", ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                while(!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();

                    if(fields.Length == 2 && fields[0].ToLower() == "langue")
                    {
                        this.langue = fields[1];
                        continue;
                    }

                    foreach(string mot in fields)
                        if(mot.All(char.IsLetter))
                            this.contenu.Add(mot.ToUpper());
                }
            }

        }

        public override string ToString()
        {
            string return_str = "";

            foreach(string mot in this.contenu)
                return_str += mot + " ";

            return return_str;
        }
    }
}
