using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

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

        public bool Contient(string mot)
        {
            mot = RemoveDiacritics(mot);
            mot = mot.ToUpper();
            foreach(string mot_ in this.contenu)
                if(mot_ == mot)
                    return true;

            return false;
        }
        public bool RechDichoRecursif(string mot)
        {
            return this.Contient(mot);
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach(var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if(unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
