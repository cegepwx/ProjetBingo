using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjetJeuPOO.SimiliBlackJack
{

    class Card
    {
        private string couleur;
        private int number;

        public string Couleur { get => couleur; set => couleur = value; }
        public int Number { get => number; set => number = value; }

        public Card(string color, int no)
        {
            this.Couleur = color;
            this.Number = no;
        }

    }
}
