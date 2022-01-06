using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Classe qui représente le boulier. On y retire les boules au hazard.

namespace ProjetJeuPOO.Bingo
{
    class Boulier
    {
        private List<int> ballsInBoulier = Enumerable.Range(1, 75).ToList();

        public List<int> BallsInBoulier { get => ballsInBoulier; set => ballsInBoulier = value; }
        public Boulier()
        {
        }

        public BingoBall tirerBoule()
        {
            Random random = new Random();
            int index = random.Next(0, BallsInBoulier.Count);
            char letter;
            int number;

            if (BallsInBoulier[index] <= 15)
            {
                letter = 'B';
            }
            else if(BallsInBoulier[index] > 15 && BallsInBoulier[index] <= 30)
            {
                letter = 'I';
            }
            else if(BallsInBoulier[index] > 30 && BallsInBoulier[index] <= 45)
            {
                letter = 'N';
            }
            else if(BallsInBoulier[index] > 45 && BallsInBoulier[index] <= 60)
            {
                letter = 'G';
            }
            else
            {
                letter = 'O';
            }
            List<int> temp1 = BallsInBoulier;
            number = temp1[index];
            temp1.RemoveAt(index);
            BallsInBoulier = temp1;
            BingoBall bingoBall = new BingoBall(letter, number);
            
            return bingoBall;
        }
        
        public int tirerNumber(int ballLetterInNumber) // paramètre ballLetterInNumber = 0, présenter `B`, ballLetterInNumber = 1 présenter `I`.... 
        {
            int number;
            List<int> temp2 = BallsInBoulier;
            Random random = new Random();
            int index;

            do
            {
                index = random.Next(15 * ballLetterInNumber, 15 * ballLetterInNumber + 14);
            }
            while (temp2[index] == 0); 
           
            number = temp2[index];
            temp2[index] = 0;
            return number;
        }  
    }
}
