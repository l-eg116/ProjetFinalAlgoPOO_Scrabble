using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Jeu
    {
        private Plateau plateau;
        private List<Joueur> joueurs = new List<Joueur> { };
        private SacJetons sac_jetons;
        private Dictionnaire dictionnaire;

        /// <summary>
        /// Constructeur par défaut de Jeu
        /// </summary>
        /// <param name="plateau">Instance de plateau</param>
        /// <param name="sac_jetons">Instance de SacJetons</param>
        /// <param name="dictionnaire">Instance de Dictionnaire</param>
        /// <param name="joueurs">Liste de Joueur</param>
        public Jeu(Plateau plateau, SacJetons sac_jetons, Dictionnaire dictionnaire = null, List<Joueur> joueurs = null)
        {
            this.plateau = plateau;
            this.sac_jetons = sac_jetons;
            if(dictionnaire == null)
                this.dictionnaire = new Dictionnaire();
            if(joueurs == null)
                this.joueurs = new List<Joueur> { };
        }
       
    }
}
