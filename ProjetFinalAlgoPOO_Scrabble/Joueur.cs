using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Joueur
    {
        private string nom;
        private int score = 0;
        private string[] mot_trouves = null;
        private List<Jeton> main_courante = new List<Jeton> { };
        /// <summary>
        /// Constructeur de la class Joueur, si le nom est null alors la classe n'est pas faisable.
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        /// <param name="score">Score du joueur</param>
        /// <param name="mot_trouves">Mots trouvés par le joueur</param>
        public Joueur(string nom, int score, string[] mot_trouves)
        {
            if(nom != null)
            {
                this.nom = nom;
            }
            this.score = score;
            this.mot_trouves = mot_trouves;
        }

        /// <summary>
        /// Creer un nouveau joueur à partir de Joueurs.txt
        /// </summary>
        /// <param name="path">Chemin du fichier</param>
        public Joueur(string path = "Joueurs.csv")
        {
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ",", ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;
                string[] fields = csvParser.ReadFields();
                if (!csvParser.EndOfData)
                {
                    this.nom = fields[0];
                    this.score = Convert.ToInt32(fields[1]);
                    fields = csvParser.ReadFields();
                    for(int i = 0; i < fields.Length; i++)
                    {
                        Add_Mot(fields[i]);
                    }
                    fields = csvParser.ReadFields();
                    for(int i = 0; i < fields.Length; i++)
                    {
                        this.main_courante.Add(new Jeton(Convert.ToChar(fields[i])));
                    }
                }
            }
        }

        /// <summary>
        /// Permet de rajouter un mot dans les mots trouvés
        /// </summary>
        /// <param name="mot">Mot à rajouter dans les mots trouvés</param>
        public void Add_Mot(string mot)
        {
            string[] tableau_remplacement = new string[mot_trouves.Length + 1];
            for(int i = 0; i < mot_trouves.Length; i++)
            {
                tableau_remplacement[i] = mot_trouves[i];
            }
            mot_trouves = null;
            mot_trouves = new string[tableau_remplacement.Length];
            this.mot_trouves = tableau_remplacement;
        }

        /// <summary>
        /// Permet de modifier le score du joueur
        /// </summary>
        /// <param name="val">Valeur à rajouter au score du joueur</param>
        public void Add_Score(int val)
        {
            score += val;
        }
        public override string ToString()
        {
            string phrase= "Le joueur s'appelle " + nom + ", il a " + score + " points \n";
            if(mot_trouves != null)
            {
                for(int i = 0; i < mot_trouves.Length; i++)
                {
                    phrase += mot_trouves[i] + "\n";
                }
            }
            return phrase;
        }

        /// <summary>
        /// Permet de rajouter un jeton dans la main courante du joueur
        /// </summary>
        /// <param name="monjeton">Jeton à rajouter dans la main courante du joueur</param>
        public void Add_Main_Courante(Jeton monjeton)
        {
            this.main_courante.Add(new Jeton(Convert.ToChar(monjeton)));
        }

        /// <summary>
        /// Permet d'enlever un jeton dans la main courante du joueur
        /// </summary>
        /// <param name="monjeton">Jeton à enlever dans la main courante du joueur</param>
        public void Remove_Main_Courante(Jeton monjeton)
        {
            this.main_courante.Remove(new Jeton(Convert.ToChar(monjeton)));
        }
    }
}
