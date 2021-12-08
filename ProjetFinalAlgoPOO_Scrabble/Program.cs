using System;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionnaire fr = new Dictionnaire();
            
            Console.WriteLine(fr.Taille);
            Console.WriteLine(fr.Langue);
        }
    }
}
