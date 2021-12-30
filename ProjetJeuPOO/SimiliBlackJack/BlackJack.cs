using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class BlackJack
    {
        private Card card = new Card();
        private Deck deck = new Deck();
        private Hand hand = new Hand();

        internal Card Card { get => card; set => card = value; }
        internal Deck Deck { get => deck; set => deck = value; }
        internal Hand Hand { get => hand; set => hand = value; }

        public void Jouer()
        {
            Deck.Point = Card.tirerUneCard();
            string choix;
            do
            {
                Console.WriteLine("Veuillez saisir votre choix:");
                Console.WriteLine("1. Avoir une carte supplémentaire ");
                Console.WriteLine("2. Conserver votre mise ");
                choix = Console.ReadLine();
            } 
            while (choix != "1" || choix != "2");
            switch (choix)
            {
                case "1":
                    break;
                case "2":
                    break;
            }
            
        }
        public void VoirScore()
        {

        }
        public void DealCard()
        {

        }
    }
}
