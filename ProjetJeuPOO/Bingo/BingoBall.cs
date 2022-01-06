using System;
using System.Collections.Generic;
using System.Text;

//Classe représentant un objet boule 

namespace ProjetJeuPOO.Bingo
{
    class BingoBall
    {
        private int number;
        private char letter;


        public int Number { get => number; set => number = value; }
        public char Letter { get => letter; set => letter = value; }

        public BingoBall(char ballLetter,int ballNumber)
        {
            this.Number = ballNumber;
            this.Letter = ballLetter;
        }

    }

}
