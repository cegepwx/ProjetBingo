using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.Bingo
{
    public static class Utilities
    {
        //Changer les lettres B I N G O aux numéro 0 1 2 3 4
        public static int changerElement(char ballLetter)
        {
            switch (ballLetter)
            {
                case 'B':
                    return 0;
                case 'I':
                    return 1;
                case 'N':
                    return 2;
                case 'G':
                    return 3;
                case 'O':
                    return 4;
                default:
                    return 0;
            }
        }
    }
}

