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

        public string NameUser { get => nameUser; set => nameUser = value; }
        public int PartiesBlackJack { get => partiesBlackJack; set => partiesBlackJack = value; }
        public int VictorsBlackJack { get => victorsBlackJack; set => victorsBlackJack = value; }

        public BlackJackController(string nameUserInput, int parties, int victors)
        {
            this.NameUser = nameUserInput;
            this.PartiesBlackJack = parties;
            this.VictorsBlackJack = victors;
        }

        public void afficherSession()
        {
            Console.WriteLine("\n Le nom de l'utilisateur: {0}", NameUser);
            Console.WriteLine("\n Le nombre de partie joué Black Jack: {0}\n Le nombre de vitoire: {1}\n",
                    PartiesBlackJack, VictorsBlackJack);
        }

    }
}
