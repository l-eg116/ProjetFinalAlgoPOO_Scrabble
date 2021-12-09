using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Joueur
    {
        string nom;
        int score = 0;
        string[] mot_trouves = null;

        public Joueur(string nom, int score, string[] mot_trouves)
        {
            if(nom != null)
            {
                this.nom = nom;
            }
            this.score = score;
            this.mot_trouves = mot_trouves;
        }
        public void Add_Mot(string mot)
        {
            string[] tableau_remplacement = new string[mot_trouves.Length + 1];
            for(int i = 0; i < mot_trouves.Length; i++)
            {
                tableau_remplacement[i] = mot_trouves[i];
            }
            mot_trouves = null;
            mot_trouves = new string[tableau_remplacement.Length];
            mot_trouves = tableau_remplacement;
        }
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
    }
}
