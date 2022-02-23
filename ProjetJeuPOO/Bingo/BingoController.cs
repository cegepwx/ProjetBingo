using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.Bingo
{
    class BingoController
    {
        private string nameUser;
        private int partiesBingo;
        private int victorsBingo;
        private AnnonceCard carteAnnonceur=new AnnonceCard();
        private List<BingoCard> cartesJoueur = new List<BingoCard>();
        private BingoBoulier bingoBoulier = new BingoBoulier();

        public BingoController(string nameUserInput, int parties)
        {
            this.nameUser = nameUserInput;
            this.partiesBingo = parties;
        }

        public void menuBingo()
        {
            Console.WriteLine("\nChoisir l'option suivante:");
            Console.WriteLine("1.- Initialiser une nouvelle partie");
            Console.WriteLine("2.- Visualiser une des cartes du joueur");
            Console.WriteLine("3.- Visualiser la carte de l'annonceur");
            Console.WriteLine("4.- Tirer une boule");
            Console.WriteLine("5.- Fin de partie\n");
            string choix = Console.ReadLine();
            Console.WriteLine();
            choisirmenuBingo(choix);
        }

        public void choisirmenuBingo(string choix)
        {
            
            switch (choix)
            {
                case "1":
                    newPart();
                    break;
                case "2":
                    showPlayerCard();
                    break;
                case "3":
                    showAnnounceCard();
                    break;
                case "4":
                    tirerBoule();
                    break;
                case "5":
                    finPartie();
                    break;
                default:
                    menuBingo();
                    break;
            }
        }

        public void newPart()
        {
            initialiserNewPartie();
            afficherSession();
            menuBingo();
        }

        public void showPlayerCard()
        {
            BingoCard card = choisirUnecarteAfficher();
            card.visualiserUneCarteJoueur();
            victorsBingo = card.Gagne(card.Valeur);
            afficherSession();
            menuBingo();
        }

        public void showAnnounceCard()
        {
            carteAnnonceur.visualiserCarteAnnonceur();
            Console.WriteLine("\nVous avez tiré {0} boules.\n", bingoBoulier.getSize());
            menuBingo();
        }

        public void tirerBoule()
        {
            if (bingoBoulier.isEmpty())
            {
                Console.WriteLine("Fin de partie");
                finPartie();
            }
            BingoBall temp = bingoBoulier.tirerUneBoule();
            carteAnnonceur.ajouterNumber(temp.Letter, temp.Number);

            for (int k = 0; k < cartesJoueur.Count; k++)
            {
                cartesJoueur[k].changerNumberTo0(temp.Letter, temp.Number);
            }
            menuBingo();
        }

        public void afficherSession()
        {
            Console.WriteLine("\n Le nom de l'utilisateur: {0}", nameUser);
            Console.WriteLine("\n Le nombre de partie joué Bingo: {0}\n Le nombre de vitoire: {1}\n",
                    partiesBingo, victorsBingo);
        }

        public void initialiserNewPartie()
        {
            partiesBingo++;
            bingoBoulier.restartBoulier();
            victorsBingo = 0;
            cartesJoueur = new List<BingoCard>();

            string userInput = "";

            while (!(userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4"))
            {
                Console.WriteLine("\n\tCombien de cartes désirez-vous : (max de 4)");
                userInput = Console.ReadLine();
            }
            for(int i = 0; i < Convert.ToInt16(userInput); i++)
            {
                BingoCard bingoCard =new BingoCard();
                bingoCard.createBingoCard();
                cartesJoueur.Add(bingoCard);
            }
        }

        public BingoCard choisirUnecarteAfficher()
        {
            int quelleCarte;
            bool isNumber;

            if (cartesJoueur.Count == 0)
            {
                Console.WriteLine("Vous avez aucune carte. Veuillez choisir <Initialiser une nouvelle partie>.");
                menuBingo();
            }
            do
            {
                Console.WriteLine("Vous avez {0} carte(s), quelle carte vous voulez visualiser? ", cartesJoueur.Count);
                string enter = Console.ReadLine();
                isNumber = int.TryParse(enter, out quelleCarte);
            }
            while (isNumber != true || quelleCarte > cartesJoueur.Count);

            return cartesJoueur[quelleCarte - 1];
        }

        public void finPartie()
        {
            cartesJoueur = new List<BingoCard>();
            victorsBingo = 0;
            string choix = "";
            while (!(choix == "1" || choix == "2"))
            {
                Console.WriteLine("Voulez-vous retourner au menu pour un autre jeu ou de démarrer une nuvelle partie?");
                Console.WriteLine("1. Retourner au menu des jeux");
                Console.WriteLine("2. Démarrer une nuvelle partie");
                choix = Console.ReadLine();
                Console.WriteLine();
            }

            if (choix == "1")
            {
                return;
            }
            else if (choix == "2")
            {
                menuBingo();
            }
        }
    }
}
