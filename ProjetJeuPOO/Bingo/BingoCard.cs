using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

// Classe représentant un objet carte pour le joueur.
// Un joueur a au minimum une carte.

namespace ProjetJeuPOO.Bingo
{
    class BingoCard
    {
        private int[,] valeur = new int[5, 5];

        public int[,] Valeur { get => valeur; set => valeur = value; }

        public BingoCard()
        {
            this.Valeur = valeur;
        }

        public int[,] createBingoCard()
        {
            Boulier boulier = new Boulier();
            int[,] temp = Valeur;

            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    temp[j, i] = boulier.tirerNumber(i);
                }
            }
            temp[2, 2] = 0;
            Valeur = temp;
            return Valeur;
        }

        public void visualiserUneCarteJoueur()
        {
            Console.WriteLine("");
            Console.WriteLine("B\tI\tN\tG\tO");

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0}\t", Valeur[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int Gagne(int[,] element)
        {
            int winners = 0;
            int valueRaw = 0;
            int valueCol = 0;
            int valueJI = 0;
            int valueIJ = 0;

            for (int raw = 0; raw < 5; raw++)
            {
                for (int col = 0; col < 5; col++)
                {
                    valueRaw = valueRaw + Valeur[raw, col];
                }
                if (valueRaw == 0)
                {
                    winners++;
                }
                valueRaw = 0;
            }

            for (int col = 0; col < 5; col++)
            {
                for (int raw = 0; raw < 5; raw++)
                {
                    valueCol = valueCol + Valeur[raw, col];
                }
                if (valueCol == 0)
                {
                    winners++;
                }
                valueCol = 0;
            }

            for(int i = 0; i < 5; i++)
            {
                valueIJ = valueIJ + Valeur[i, i];  
                valueJI = valueJI + Valeur[4 - i, i];
            }

            if (valueIJ == 0)
            {
                winners++;
            }

            if (valueJI == 0)
            {
                winners++;
            }

            return winners;
        }
    }
}
