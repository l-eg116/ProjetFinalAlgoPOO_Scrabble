using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Jeu
    {
        Dictionnaire[] mondico;
        Plateau monplateau;
        SacJetons monsac_jetons;
        /// <summary>
        /// Constructeur de la classe Jeu
        /// </summary>
        /// <param name="mondico"></param>
        /// <param name="monplateau"></param>
        /// <param name="monsac_jetons"></param>
        public Jeu(Dictionnaire[] mondico, Plateau monplateau, SacJetons monsac_jetons)
        {
            mondico = new Dictionnaire("Francais.txt")
            this.mondico = mondico;
            this.monplateau = monplateau;
            this.monsac_jetons = monsac_jetons;
        }
       
    }
}
