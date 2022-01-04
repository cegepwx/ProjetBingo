using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class Deck
    {
        private List<Card> cards = new List<Card>(52);
        internal List<Card> Cards { get => cards; set => cards = value; }

        public Deck()
        {
            //initialiser 52 cartes
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 13; i++)
                {
                    switch(j)
                    {
                        case 0:
                            Cards.Add(new Card("Spade", i + 1));
                            break;
                        case 1:
                            Cards.Add(new Card("Heart", i + 1));
                            break;
                        case 2:
                            Cards.Add(new Card("Diamond", i + 1));
                            break;
                        case 3:
                            Cards.Add(new Card("Club", i + 1));
                            break;
                    }
                }
            }
        }

        public Card tirerUneCarte()
        {
            Random random = new Random();
            int index = random.Next(0, cards.Count);
            Card card = cards[index];
            Cards.RemoveAt(index);
            return card;
        }
    }
}
