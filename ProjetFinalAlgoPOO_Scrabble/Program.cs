using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionnaire fr = new Dictionnaire();

            List<string> mots_possible = fr.MotsPossibles("MISSILEs");

            foreach(string mot in mots_possible)
                Console.Write(mot + " ");
        }
    }
}
