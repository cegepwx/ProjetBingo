using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class BlackJackController
    {
        private string nameUser;
        private int partiesBlackJack;
        private int victorsBlackJack;
        private BlackJack blackJack = new BlackJack();

        public string NameUser { get => nameUser; set => nameUser = value; }
        public int PartiesBlackJack { get => partiesBlackJack; set => partiesBlackJack = value; }
        public int VictorsBlackJack { get => victorsBlackJack; set => victorsBlackJack = value; }
        internal BlackJack BlackJack { get => blackJack; set => blackJack = value; }

        public BlackJackController(string nameUserInput, int parties, int victors)
        {
            this.NameUser = nameUserInput;
            this.PartiesBlackJack = parties;
            this.VictorsBlackJack = victors;
        }

        public void menuBlackJack()
        {
            Console.WriteLine("Veuillez choisir:");
            Console.WriteLine("1. Démarrer un nouveau tournoi ");
            Console.WriteLine("2. Choisir un autre jeu ");
            string choix = Console.ReadLine();
            choisirMenuBlackJack(choix);
        }

        public void choisirMenuBlackJack(string choix)
        {
            switch (choix)
            {
                case "1":
                    afficherSession();
                    BlackJack.Jouer();
                    break;
                case "2":
                    break;
                default:
                    menuBlackJack();
                    break;
            }
        }

        public void afficherSession()
        {
            Console.WriteLine("\n Le nom de l'utilisateur: {0}", NameUser);
            Console.WriteLine("\n Le nombre de partie joué Black Jack: {0}\n Le nombre de vitoire: {1}\n",
                    PartiesBlackJack, VictorsBlackJack);
        }

    }
}
