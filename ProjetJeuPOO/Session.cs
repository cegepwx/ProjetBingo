using ProjetJeuPOO.Bingo;
using ProjetJeuPOO.SimiliBlackJack;
using ProjetJeuPOO.SimiliPendu;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO
{

    class Session
    {
        private string nameUser;
        private int partiesBingo=0;
        private int victorsBingo=0;
        private int partiesBlackJack=0;
        private int victorsBlackJack=0;
        private int partiesPendu=0;
        private int victorsPendu=0;
        private BingoController Bingo;
        private BlackJackController BlackJack;
       
        public string NameUser { get => nameUser; set => nameUser = value; }
        public int PartiesBingo { get => partiesBingo; set => partiesBingo = value; }
        public int VictorsBingo { get => victorsBingo; set => victorsBingo = value; }
        public int PartiesBlackJack { get => partiesBlackJack; set => partiesBlackJack = value; }
        public int VictorsBlackJack { get => victorsBlackJack; set => victorsBlackJack = value; }
        public int PartiesPendu { get => partiesPendu; set => partiesPendu = value; }
        public int VictorsPendu { get => victorsPendu; set => victorsPendu = value; }

        public Session()
        {
        }
            
        public void ouvrirSession()
        {
            menuPrincipal();

            Console.WriteLine("Veuillez saisir votre nom:");
            NameUser = Console.ReadLine();
            choisirMenuPrincipal();
        }

        public void menuPrincipal()
        {
            Console.WriteLine("\nJeux  Pour  Toujours\n");
            Console.WriteLine("\nChoisir un des numéro ci-desous pour jouer, saisir les autres pour quitter.");
            Console.WriteLine("1- Bingo");
            Console.WriteLine("2- Simili black jack");
            Console.WriteLine("3- Le pendu\n");
            
        }

        public void choisirMenuPrincipal()
        {
            Console.WriteLine("Veuillez choisir le jeu qeu vous voulez:");
            string choix = Console.ReadLine();
         
            switch (choix)
            {
                case "1":
                    Bingo = new BingoController(NameUser, PartiesBingo, VictorsBingo);
                    Bingo.menuBingo();
                    menuPrincipal();
                    choisirMenuPrincipal();
                    break;
                case "2":
                    BlackJack = new BlackJackController(NameUser, PartiesBlackJack, VictorsBlackJack);
                    BlackJack.menuBlackJack();
                    menuPrincipal();
                    choisirMenuPrincipal();
                    break;
                case "3":
                    break;
                default:
                    Environment.Exit(0);
                    break;

            }
        }

    }
}
