using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class SacJetons
    {
        private List<Jeton> sac = new List<Jeton> { };

        public int Taille
        {
            get { return sac.Count; }
        }
        public List<Jeton> Contenu
        {
            get { return this.sac; }
        }
    }
}
