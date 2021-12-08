using System;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            SacJetons sac = new SacJetons(@"C:\Users\legco\Downloads\Jetons.txt");
            Console.WriteLine(sac.ToString());

            Jeton jeton;
            while((jeton = sac.Piocher()) != null)
                Console.WriteLine(jeton.ToString());
        }
    }
}
