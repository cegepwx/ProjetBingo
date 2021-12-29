using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.Bingo
{
    class AnnonceCard
    {
        private int[,] valeur = new int[15, 5];

        internal int[,] Valeur { get => valeur; set => valeur = value; }

        public AnnonceCard()
        {

        }

        public void visualiserCarteAnnonceur()
        {
            Console.WriteLine("B\tI\tN\tG\tO");
            for (int j = 0; j < 15; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("{0}\t", Valeur[j, i]);
                }
                Console.WriteLine();
            }
        }
    }
}
