using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Classe qui représente le boulier. On y retire les boules au hazard.

namespace ProjetJeuPOO.Bingo
{
    class Boulier
    {
        private List<int> listball = Enumerable.Range(1, 75).ToList();

        public List<int> Listball { get => listball; set => listball = value; }
        public Boulier()
        {
        }

        public BingoBall tirerBoule()
        {
            Random random = new Random();
            int index = random.Next(0, listball.Count);
            char letter;
            int number;

            if (Listball[index] <= 15)
            {
                letter = 'B';
            }
            else if(Listball[index] > 15 && Listball[index] <= 30)
            {
                letter = 'I';
            }
            else if(Listball[index] > 30 && Listball[index] <= 45)
            {
                letter = 'N';
            }
            else if(Listball[index] > 45 && Listball[index] <= 60)
            {
                letter = 'G';
            }
            else
            {
                letter = 'O';
            }
            List<int> temp1 = Listball;
            number = temp1[index];
            temp1.RemoveAt(index);
            Listball = temp1;
            BingoBall bingoBall = new BingoBall(number, letter);
            
            return bingoBall;
        }
        
        public int tirerNumber(int i) // paramètre i = 0, présenter `B`, i = 1 présenter `I`.... 
        {
            int number;
            List<int> temp2 = Listball;
            Random random = new Random();
            int index;

            do
            {
                index = random.Next(15 * i, 15 * i + 14);
            }
            while (temp2[index] == 0); 
           
            number = temp2[index];
            temp2[index] = 0;
            return number;
        }  
    }
}
