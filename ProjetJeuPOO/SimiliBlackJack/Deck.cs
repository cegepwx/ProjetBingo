using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class Deck
    {
        private int point;
        public Deck()
        {
            this.Point = point;
            Console.WriteLine("La carte de Deck: {0} ", Point);
        }

        public int Point { get => point; set => point = value; }
    }
}
