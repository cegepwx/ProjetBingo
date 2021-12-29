using System;
using ProjetJeuPOO.Bingo;
using ProjetJeuPOO.SimiliBlackJack;
using ProjetJeuPOO.SimiliPendu;
using System.Collections.Generic;


namespace ProjetJeuPOO
{
    public class Controller
    {
        static void Main(string[] args)
        {
            Session session = new Session();
            session.ouvrirSession();
        }

    }
}
