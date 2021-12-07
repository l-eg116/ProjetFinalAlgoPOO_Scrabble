using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Jeton
    {
        private volatile char lettre;

        private static List<char> lettres = new List<char> { };
        private static List<int> valeurs = new List<int> { };

        public char Lettre
        {
            get { return this.lettre; }
        }
        public int Valeur
        {
            get { return Jeton.ObtenirValeur(this.lettre); }
        }

        public Jeton(char lettre)
        {
            this.lettre = Convert.ToChar(lettre.ToString().ToUpper());
        }
        public Jeton(char lettre, int valeur)
        {
            this.lettre = Convert.ToChar(lettre.ToString().ToUpper());
            FixerValeur(this.lettre, valeur);
        }
        public override string ToString()
        {
            return $"'{this.lettre}' - {this.Valeur} pt(s)";
        }

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
        private static int ObtenirValeur(char lettre)
        {
            for(int i = 0; i < Jeton.lettres.Count; i++)
                if(Jeton.lettres[i] == lettre)
                    return Jeton.valeurs[i];

            return 0;
        }
    }
}
