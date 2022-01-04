using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class Hand
    {
        private List<Card> cards = new List<Card>();
        internal List<Card> Cards { get => cards; set => cards = value; }

        public Hand()
        {
        }

        public void afficherHand(Joueur user)
        {
            foreach (Card card1 in user.Hand.Cards)
            {
                if (card1.Number == 11)
                {
                    Console.WriteLine("La carte est: {0} Jack", card1.Couleur);
                }
                else if (card1.Number == 12)
                {
                    Console.WriteLine("La carte est: {0} Queen", card1.Couleur);
                }
                else if (card1.Number == 13)
                {
                    Console.WriteLine("La carte est: {0} King", card1.Couleur);
                }
                else
                {
                    Console.WriteLine("La carte est: {0} {1} ", card1.Couleur, card1.Number);
                }
            }
        }
    }
}
