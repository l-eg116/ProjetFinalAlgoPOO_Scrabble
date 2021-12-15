using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main()
        {
            SacJetons sac = new SacJetons(@"C:\Users\legco\Source\Repos\l-eg116\ProjetFinalAlgoPOO_Scrabble\ProjetFinalAlgoPOO_Scrabble\Sauvegarde_SacJetons.csv");

            sac.Sauvegarder(@"C:\Users\legco\Source\Repos\l-eg116\ProjetFinalAlgoPOO_Scrabble\ProjetFinalAlgoPOO_Scrabble");
        }
    }
}
