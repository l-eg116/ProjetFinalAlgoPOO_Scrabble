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

        /// <summary>
        /// Contenu du Dictionnaire
        /// </summary>
        public List<string> Contenu
        {
            get { return this.contenu; }
        }
        /// <summary>
        /// Nombre de mots dans le Dictionnaire
        /// </summary>
        public int Taille
        {
            get { return this.contenu.Count; }
        }
        /// <summary>
        /// Langue du Dictionnaire
        /// </summary>
        public string Langue
        {
            get { return this.langue; }
        }

        /// <summary>
        /// Construit un nouveau dictionnaire à partir d'un fichier
        /// Mettre 'langue "[langue]"' en début de fichier pour définir la langue
        /// Séparer les mots par des espaces, # devant une ligne à ingnorer
        /// </summary>
        /// <param name="path">Chemin du fichier</param>
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
                            this.contenu.Add(RemoveDiacritics(mot).ToUpper());
                }
            }
        }

        public override string ToString()
        {
            return $"Langue : {this.langue}, {this.Taille} mots";
        }

        /// <summary>
        /// Dit si un mot est contenu dans le Dictionnaire
        /// </summary>
        /// <param name="mot">Mot à chercher</param>
        /// <returns>Si le mot est contenu dans le Dictionnaire</returns>
        public bool Contient(string mot)
        {
            mot = RemoveDiacritics(mot);
            mot = mot.ToUpper();
            foreach(string mot_ in this.contenu)
                if(mot_ == mot)
                    return true;

            return false;
        }
        /// <summary>
        /// Alignement sur la nomenclature de la consigne
        /// </summary>
        /// <param name="mot">mot</param>
        /// <returns>this.Contient(mot)</returns>
        public bool RechDichoRecursif(string mot)
        {
            return this.Contient(mot);
        }
        /// <summary>
        /// Trouve tous les mots que l'on peut faire avec une liste de lettres donnée
        /// </summary>
        /// <param name="lettres">string contenant les lettres à disposition</param>
        /// <returns>Liste des mots faisables</returns>
        public List<string> MotsPossibles(string lettres)
        {
            List<string> mots = new List<string> { };

            lettres = lettres.ToUpper();

            foreach(string mot in this.contenu)
            {
                bool possible = true;
                List<char> temp_lettres = lettres.ToList();

                foreach(char lettre in mot)
                    if(!temp_lettres.Remove(lettre))
                    {
                        possible = false;
                        break;
                    }

                if(!possible)
                    continue;
                else
                    mots.Add(mot);
            }

            return mots;
        }

        /// <summary>
        /// Retire les accents d'un string
        /// (Merci internet)
        /// </summary>
        /// <param name="text">Texte d'entrée</param>
        /// <returns>Texte sans les accents</returns>
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
