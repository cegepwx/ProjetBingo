using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.Bingo
{
    class BingoBoulier : IBingoBoulier
    {
        private Boulier boulier = new Boulier();
        private List<BingoBall> ballsTire = new List<BingoBall>();

        public BingoBall tirerUneBoule()
        {
            BingoBall ball = getRanbomBall();
            Console.WriteLine("Ball {0}  {1}", ball.Letter, ball.Number);
            add(ball);
            return ball;
        }
       
        public BingoBall getRanbomBall()
        {
            return boulier.tirerBoule();
        }

        public void add(BingoBall element)
        {
            ballsTire.Add(element);
        }

        public void restartBoulier()
        {
            new Boulier();
        }

        public bool isEmpty()
        {
            bool vide = false;
            if(boulier.BallsInBoulier.Count == 0)
            {
                vide = true;
            }
            return vide;
        }

        public int getSize()
        {
            return ballsTire.Count;
        }

    }
}
