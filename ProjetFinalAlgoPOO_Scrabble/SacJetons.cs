using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class SacJetons
    {
        private List<Jeton> sac = new List<Jeton> { };

        /// <summary>
        /// Nombre de jetons dans le sac
        /// </summary>
        public int Taille
        {
            get { return sac.Count; }
        }
        /// <summary>
        /// Liste des jetons dans le sac
        /// </summary>
        public List<Jeton> Contenu
        {
            get { return this.sac; }
        }

        /// <summary>
        /// Créer un nouveau sac de jetons à partir d'un fichier au format .csv avec :
        /// lettre(char);valeur(int);quantite(int)
        /// </summary>
        /// <param name="path">Chemin du fichier csv</param>
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
                    try
                    {
                        char lettre = Convert.ToChar(fields[0]);
                        int valeur = Convert.ToInt32(fields[1]);
                        int quantite = Convert.ToInt32(fields[2]);

                        for(int i = 0; i < quantite; i++)
                            this.sac.Add(new Jeton(lettre, valeur));
                    }
                    catch(System.FormatException) { }
                    catch(System.IndexOutOfRangeException) { }
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

        /// <summary>
        /// Enlève un jeton au hasard du sac
        /// </summary>
        /// <returns>Un jeton enlevé du sac</returns>
        public Jeton Piocher()
        {
            if(this.Taille == 0)
                return null;

            Random random = new Random();

            int i = random.Next(this.Taille);
            Jeton jeton = this.sac[i];
            this.sac.RemoveAt(i);

            random = null;

            return jeton;
        }
    }
}
