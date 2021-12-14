using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Jeton
    {
        private volatile char lettre;

        private static List<char> lettres = new List<char> { };
        private static List<int> valeurs = new List<int> { };

        /// <summary>
        /// Lettre du Jeton
        /// </summary>
        public char Lettre
        {
            get { return this.lettre; }
        }
        /// <summary>
        /// Valeur du Jeton, stockée dans la classe
        /// </summary>
        public int Valeur
        {
            get { return Jeton.ObtenirValeur(this.lettre); }
        }

        /// <summary>
        /// Constructeur pour Jeton
        /// </summary>
        /// <param name="lettre">Fixe this.lettre</param>
        public Jeton(char lettre)
        {
            this.lettre = Convert.ToChar(lettre.ToString().ToUpper());
        }
        /// <summary>
        /// Constructeur pour Jeton qui fixe la valeur d'un type de Jeton
        /// </summary>
        /// <param name="lettre">Fixe this.lettre</param>
        /// <param name="valeur">Défini la valeur de la lettre à l'échelle de la classe</param>
        public Jeton(char lettre, int valeur)
        {
            this.lettre = Convert.ToChar(lettre.ToString().ToUpper());
            FixerValeur(this.lettre, valeur);
        }
        public override string ToString()
        {
            return $"'{this.lettre}' - {this.Valeur} pt(s)";
        }

        /// <summary>
        /// Fixe la valeur d'une certaine lettre pour la classe Jeton
        /// </summary>
        /// <param name="lettre">Lettre sur le Jeton</param>
        /// <param name="valeur">Valeur du Jeton</param>
        private static void FixerValeur(char lettre, int valeur)
        {
            bool unchanged = true;
            for(int i = 0; i < Jeton.lettres.Count; i++)
                if(Jeton.lettres[i] == lettre)
                {
                    Jeton.valeurs[i] = valeur;
                    unchanged = false;
                    break;
                }

            if(unchanged)
            {
                Jeton.lettres.Add(lettre);
                Jeton.valeurs.Add(valeur);
            }
        }
        /// <summary>
        /// Retourne la valeur d'une lettre dans la calsse Jeton
        /// </summary>
        /// <param name="lettre">Lettre dont on veut obtenir la valeur</param>
        /// <returns>Valeur de la lettre</returns>
        private static int ObtenirValeur(char lettre)
        {
            for(int i = 0; i < Jeton.lettres.Count; i++)
                if(Jeton.lettres[i] == lettre)
                    return Jeton.valeurs[i];

            return 0;
        }

        public static bool operator == (Jeton jeton1, Jeton jeton2)
        {
            return (jeton1 is null && jeton2 is null) || (jeton1 is Jeton && jeton2 is Jeton && jeton1.lettre == jeton2.lettre);
        }
        public static bool operator != (Jeton jeton1, Jeton jeton2)
        {
            return !(jeton1 == jeton2);
        }
    }
}
