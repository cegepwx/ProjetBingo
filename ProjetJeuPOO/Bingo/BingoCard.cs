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

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    temp[row, col] = boulier.tirerNumber(col);
                }
            }
            temp[2, 2] = 0;
            Valeur = temp;
            return Valeur;
        }

        //Changer le numéro de la carte de joueur à 0 s'il est même que la boule.
        public void changerNumberTo0(char ballLetter, int ballNumber)
        {
            int col = Utilities.changerElement(ballLetter);
            for (int row = 0; row < 5; row++)
            {
                if (Valeur[row, col] == ballNumber)
                {
                    Valeur[row, col] = 0;
                }
            }
        }

        public void visualiserUneCarteJoueur()
        {
            Console.WriteLine("");
            Console.WriteLine("B\tI\tN\tG\tO");

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Console.Write("{0}\t", Valeur[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public int Gagne(int[,] element)
        {
            int winners = 0;
            int valeurRow = 0;
            int valeurCol = 0;
            int valeur40To04 = 0;
            int valeur00To44 = 0;

            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    valeurRow = valeurRow + Valeur[row, col];
                }
                if (valeurRow == 0)
                {
                    winners++;
                }
                valeurRow = 0;
            }
            for (int col = 0; col < 5; col++)
            {
                for (int row = 0; row < 5; row++)
                {
                    valeurCol = valeurCol + Valeur[row, col];
                }
                if (valeurCol == 0)
                {
                    winners++;
                }
                valeurCol = 0;
            }
            for(int i = 0; i < 5; i++)
            {
                valeur00To44 = valeur00To44 + Valeur[i, i];
                valeur40To04 = valeur40To04 + Valeur[4 - i, i];
            }

            if (valeur00To44 == 0)
            {
                winners++;
            }
            if (valeur40To04 == 0)
            {
                winners++;
            }

            return winners;
        }
    }
}
