using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            string mat = "T;+;+;d;+;+;+;T;+;+;+;d;+;+;T \n +;D;+;+;+;t;+;+;+;t;+;+;+;D;+";
            Plateau plateau = new Plateau(mat);
            plateau.Afficher();
        }
    }
}
