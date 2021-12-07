using System;

namespace ProjetFinalAlgoPOO_Scrabble
{
    class Jeton
    {
        private char lettre;

        public char Lettre
        {
            get { return this.lettre; }
        }
        public int Points
        {
            get
            {
                switch(this.lettre)
                {
                    case 'A':
                        return 1;
                    case 'B':
                        return 3;
                    case 'C':
                        return 3;
                    case 'D':
                        return 2;
                    case 'E':
                        return 1;
                    case 'F':
                        return 4;
                    case 'G':
                        return 2;
                    case 'H':
                        return 4;
                    case 'I':
                        return 1;
                    case 'J':
                        return 8;
                    case 'K':
                        return 10;
                    case 'L':
                        return 1;
                    case 'M':
                        return 2;
                    case 'N':
                        return 1;
                    case 'O':
                        return 1;
                    case 'P':
                        return 3;
                    case 'Q':
                        return 8;
                    case 'R':
                        return 1;
                    case 'S':
                        return 1;
                    case 'T':
                        return 1;
                    case 'U':
                        return 1;
                    case 'V':
                        return 4;
                    case 'W':
                        return 10;
                    case 'X':
                        return 10;
                    case 'Y':
                        return 10;
                    case 'Z':
                        return 10;
                    default:
                        return 0;
                }
            }
        }

        public Jeton(char lettre)
        {
            this.lettre = Convert.ToChar(lettre.ToString().ToUpper());
        }
        public override string ToString()
        {
            return $"'{this.lettre}' - {this.Points} pt(s)";
        }
    }
}
