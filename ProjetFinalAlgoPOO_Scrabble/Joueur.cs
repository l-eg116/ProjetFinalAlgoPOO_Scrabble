using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Joueur
    {
        private string nom;
        private int score = 0;
        private List<string> mot_trouves = new List<string> { };
        private List<Jeton> main_courante = new List<Jeton> { };

        /// <summary>
        /// Nom du joueur
        /// </summary>
        public string Nom
        {
            get { return this.nom; }
        }
        /// <summary>
        /// Score du joueur
        /// </summary>
        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }
        /// <summary>
        /// Mots trouvés par le joueur
        /// </summary>
        public List<string> MotTrouves
        {
            get { return this.mot_trouves; }
        }
        /// <summary>
        /// Jetons du joueurs
        /// </summary>
        public List<Jeton> MainCourante
        {
            get { return this.main_courante; }
        }

        /// <summary>
        /// Constructeur de la class Joueur
        /// </summary>
        /// <param name="nom">Nom du joueur</param>
        /// <param name="score">Score du joueur</param>
        /// <param name="mot_trouves">Mots trouvés par le joueur</param>
        /// <param name="main_courante">Jetons tenus par le joueur</param>
        public Joueur(string nom, int score = 0, List<string> mot_trouves = null, List<Jeton> main_courante = null)
        {
            this.nom = nom;
            this.score = score;
            if(mot_trouves != null)
                this.mot_trouves = mot_trouves;
            if(main_courante != null)
                this.main_courante = main_courante;
        }
        /// <summary>
        /// Creer un nouveau joueur à partir d'un fichier
        /// "Nom";Score
        /// mot1;mot2;mot3;...
        /// jeton1;jeton2;jeton3;...
        /// </summary>
        /// <param name="path">Chemin du fichier</param>
        public Joueur(string path)
        {
            using(TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ",", ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                string[] fields = csvParser.ReadFields();
                this.nom = fields[0];
                try { this.score = Convert.ToInt32(fields[1]); }
                catch(System.FormatException) { this.score = 0; }
                catch(System.IndexOutOfRangeException) { this.score = 0; }

                fields = csvParser.ReadFields();
                if(fields != null)
                    foreach(string mot in fields)
                        this.mot_trouves.Add(Dictionnaire.RemoveDiacritics(mot.ToUpper()));

                fields = csvParser.ReadFields();
                if(fields != null)
                    foreach(string jeton in fields)
                        try
                        { this.main_courante.Add(new Jeton(Convert.ToChar(jeton))); }
                        catch(System.FormatException) { }

            }
        }

        /// <summary>
        /// Permet de rajouter un mot dans les mots trouvés
        /// </summary>
        /// <param name="mot">Mot à rajouter dans les mots trouvés</param>
        public void TrouveMot(string mot)
        {
            this.mot_trouves.Add(Dictionnaire.RemoveDiacritics(mot.ToUpper()));
        }
        /// <summary>
        /// Nom demandé dans la consigne
        /// </summary>
        /// <param name="mot">Mot que le joueur à trouvé</param>
        public void Add_Mot(string mot)
        {
            this.TrouveMot(mot);
        }

        /// <summary>
        /// [DEPRECATED]
        /// Permet de modifier le score du joueur
        /// UTILISER LE 'set' DE L'ATTRIBUT DE CLASSE Joueur.Score
        /// </summary>
        /// <param name="val">Valeur à rajouter au score du joueur</param>
        public void Add_Score(int val)
        {
            score += val;
        }

        public override string ToString()
        {
            string phrase= "Le joueur s'appelle " + nom + ", il a " + score + " point(s) \n";
            if(mot_trouves != null && mot_trouves.Count > 0)
            {
                phrase += "Le joueur a trouvé le(s) mot(s) : ";
                for(int i = 0; i < mot_trouves.Count - 1; i++)
                {
                    phrase += mot_trouves[i] + "; ";
                }
                phrase += mot_trouves[mot_trouves.Count - 1] + "\n";
            }
            if(main_courante != null && main_courante.Count > 0)
            {
                phrase += "Le joueur a le(s) jeton(s) suivant dans sa main : ";
                for(int i = 0; i < main_courante.Count - 1; i++)
                {
                    phrase += main_courante[i] + "; ";
                }
                phrase += main_courante[main_courante.Count - 1] + "\n";
            }
            return phrase;
        }

        /// <summary>
        /// Permet de rajouter un jeton dans la main courante du joueur
        /// </summary>
        /// <param name="monjeton">Jeton à rajouter dans la main courante du joueur</param>
        public void DonnerJeton(Jeton monjeton)
        {
            this.main_courante.Add(monjeton);
        }
        /// <summary>
        /// Nom demandé par la consigne
        /// </summary>
        /// <param name="monjeton"></param>
        public void Add_Main_Courante(Jeton monjeton)
        {
            this.DonnerJeton(monjeton);
        }

        /// <summary>
        /// Permet d'enlever un jeton dans la main courante du joueur
        /// </summary>
        /// <param name="monjeton">Jeton à enlever dans la main courante du joueur</param>
        public bool EnleverJeton(Jeton monjeton)
        {
            for(int i = 0; i < this.main_courante.Count; i++)
                if(this.main_courante[i] == monjeton)
                {
                    this.main_courante.RemoveAt(i);
                    return true;
                }
            return false;
        }
        /// <summary>
        /// Nom demandé par la consigne
        /// </summary>
        /// <param name="monjeton"></param>
        /// <returns></returns>
        public bool Remove_Main_Courante(Jeton monjeton)
        {
            return this.EnleverJeton(monjeton);
        }
    }
}
