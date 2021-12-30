using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjetJeuPOO.SimiliBlackJack
{

    class Card
    {
        private List<int> valeur = new List<int>(52);
        public List<int> Valeur { get => valeur; set => valeur = value; }

        public Card()
        {
            //initialiser 52 cards
            for(int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 13; i++)
                {
                    Valeur[j * 13 + i] = i + 1;
                    Console.Write("{0}  ", Valeur[j * 13 + i]);
                }
                Console.WriteLine();
            }
            
        }
       
        public int tirerUneCard()
        {
            Random random = new Random();
            int index = random.Next(0, Valeur.Count);
            int number = Valeur[index];
            Valeur.RemoveAt(index);

            return number;
        }
    }
}
