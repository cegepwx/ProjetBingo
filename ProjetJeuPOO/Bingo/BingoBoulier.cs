using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.Bingo
{
    class BingoBoulier : IBingoBoulier
    {
        private Boulier boulier = new Boulier();
        private List<BingoBall> listbingoballs = new List<BingoBall>();

        internal Boulier Boulier { get => boulier; set => boulier = value; }
        internal List<BingoBall> Listbingoballs { get => listbingoballs; set => listbingoballs = value; }

        public BingoBall getRanbomBall()
        {
            return boulier.tirerBoule();
        }

        public void add(BingoBall element)
        {
            Listbingoballs.Add(element);
        }

        public void restartBoulier()
        {
            new Boulier();
        }

        public bool isEmpty()
        {
            bool vide = false;
            if(Boulier.Listball.Count == 0)
            {
                vide = true;
            }
            return vide;
        }

        public int getSize()
        {
            return Listbingoballs.Count;
        }

    }
}
