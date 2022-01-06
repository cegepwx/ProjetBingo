using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.Bingo
{
    class BingoBoulier : IBingoBoulier
    {
        private Boulier boulier = new Boulier();
        private List<BingoBall> ballsTire = new List<BingoBall>();

        internal Boulier Boulier { get => boulier; set => boulier = value; }
        internal List<BingoBall> BallsTire { get => ballsTire; set => ballsTire = value; }

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
            BallsTire.Add(element);
        }

        public void restartBoulier()
        {
            new Boulier();
        }

        public bool isEmpty()
        {
            bool vide = false;
            if(Boulier.BallsInBoulier.Count == 0)
            {
                vide = true;
            }
            return vide;
        }

        public int getSize()
        {
            return BallsTire.Count;
        }

    }
}
