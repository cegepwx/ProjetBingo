using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class BlackJackController
    {
        private string nameUser;
        private int partiesBlackJack=0;
        private int pointCroupier=0;
        private int pointJoueur=0;

        private BlackJack blackJack;

        public string NameUser { get => nameUser; set => nameUser = value; }
        public int PartiesBlackJack { get => partiesBlackJack; set => partiesBlackJack = value; }
        internal BlackJack BlackJack { get => blackJack; set => blackJack = value; }
        public int PointCroupier { get => pointCroupier; set => pointCroupier = value; }
        public int PointJoueur { get => pointJoueur; set => pointJoueur = value; }

        public BlackJackController(string nameUserInput, int parties)
        {
            this.NameUser = nameUserInput;
            this.PartiesBlackJack = parties;
        }

        public void menuBlackJack()
        {
            Console.WriteLine("\nVeuillez choisir:");
            Console.WriteLine("1. Démarrer un nouveau tournoi ");
            Console.WriteLine("2. Choisir un autre jeu ");
            string choix = Console.ReadLine();
            Console.WriteLine();
            choisirMenuBlackJack(choix);
        }

        public void choisirMenuBlackJack(string choix)
        {
            switch (choix)
            {
                case "1":
                    startNewParti();
                    menuBlackJack();
                    break;
                case "2":
                    break;
                default:
                    menuBlackJack();
                    break;
            }
        }

        public void startNewParti()
        {
            PartiesBlackJack++;
            afficherSession();
            BlackJack = new BlackJack(PointJoueur, PointCroupier);
            List<int> pointGagnant = BlackJack.Jouer();
            PointJoueur = pointGagnant[0];
            PointCroupier = pointGagnant[1];
        }

        public void afficherSession()
        {
            Console.WriteLine("\n Le nom de l'utilisateur: {0}", NameUser);
            Console.WriteLine(" Le nombre de partie joué Black Jack: {0} ", PartiesBlackJack);
            Console.WriteLine(" Vous avez gagné {0} point(s). Le croupier a gagné {1} point(s).\n", PointJoueur, PointCroupier);
        }
    }
}
