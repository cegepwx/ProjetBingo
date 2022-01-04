using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class Joueur
    {
        private Hand hand = new Hand();
        private int points = 0;
        private bool gagneRapide;
        public int Points { get => points; set => points = value; }
        internal Hand Hand { get => hand; set => hand = value; }
        public bool GagneRapide { get => gagneRapide; set => gagneRapide = value; }

        public Joueur()
        {

        }
    }
}
