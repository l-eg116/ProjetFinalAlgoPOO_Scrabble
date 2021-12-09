using System;
using System.Collections.Generic;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau plat = new Plateau(@"C:\Users\legco\Downloads\InstancePlateau.txt");

            Console.WriteLine(plat.ToString());
        }
    }
}
