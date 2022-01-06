using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    interface IBlackJack
    {
        public List<int> Jouer();
        public int VoirScore(Joueur user);
        public int DealCard(Card card);
    }
}
