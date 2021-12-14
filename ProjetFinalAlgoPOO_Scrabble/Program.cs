using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau plat = new Plateau(@"C:\Users\33782\Source\Repos\ProjetFinalAlgoPOO_Scrabble\ProjetFinalAlgoPOO_Scrabble\Test_Plateau2.txt");
            plat.Afficher();
            Dictionnaire dict = new Dictionnaire();
        }
    }
}
