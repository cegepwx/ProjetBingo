using System;
using System.Collections.Generic;
using System.Text;


namespace ProjetJeuPOO.Bingo
{
    class AnnonceCard
    {
        private int[,] valeur = new int[15, 5];

        internal int[,] Valeur { get => valeur; set => valeur = value; }

        public void visualiserCarteAnnonceur()
        {
            Console.WriteLine("B\tI\tN\tG\tO");
            for (int row = 0; row < 15; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    Console.Write("{0}\t", Valeur[row, col]);
                }
                Console.WriteLine();
            }
        }

        //Ajouter un numéro de la boule tirée à la carte annonceur. 
        public void ajouterNumber(char ballLetter, int ballNumber)
        {
            int col = Utilities.changerElement(ballLetter);
            int row=0;
            while (Valeur[row, col] != 0)
            {
                row++;
            }
            Valeur[row, col] = ballNumber;

            for (int i = 0; i < row; i++)
            {
                for(int j = 0; j < row-i; j++)
                {
                    if(Valeur[j,col]> Valeur[j+1, col])
                    {
                        int temp = Valeur[j, col];
                        Valeur[j, col] = Valeur[j + 1, col];
                        Valeur[j + 1, col] = temp;
                    }
                }
            }
        }
    }
}
