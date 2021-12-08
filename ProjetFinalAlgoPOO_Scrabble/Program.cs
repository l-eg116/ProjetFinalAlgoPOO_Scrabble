using System;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionnaire fr = new Dictionnaire();
            
            Console.WriteLine(fr.Contient("chiasme"));
            Console.WriteLine(fr.Contient("mélancolie"));
            Console.WriteLine(fr.Contient("hiraeth"));
            Console.WriteLine(fr.Contient("table"));
            Console.WriteLine(fr.Contient("conseil"));
            Console.WriteLine(fr.Contient("astral"));
            Console.WriteLine(fr.Contient("manque"));
            Console.WriteLine(fr.Contient("escargot"));
            Console.WriteLine(fr.Contient("époustouflant"));
            Console.WriteLine(fr.Contient("feuilleter"));
        }
    }
}
