using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau plat = new Plateau();
            plat.Afficher();
            Plateau.AfficherLegende();
        }
    }
}
