using System;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Jeton jet_a1 = new Jeton('a');
            Console.WriteLine(jet_a1.ToString());
            
            Jeton jet_a2 = new Jeton('a', 2);
            Console.WriteLine(jet_a1.ToString());
            
            Console.WriteLine(jet_a1.ToString());
        }
    }
}
