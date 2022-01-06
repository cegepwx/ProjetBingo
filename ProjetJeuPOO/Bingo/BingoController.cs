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

        public string NameUser { get => nameUser; set => nameUser = value; }
        public int PartiesBingo { get => partiesBingo; set => partiesBingo = value; }
        public int VictorsBingo { get => victorsBingo; set => victorsBingo = value; }
        internal AnnonceCard CarteAnnonceur { get => carteAnnonceur; set => carteAnnonceur = value; }
        internal BingoBoulier BingoBoulier { get => bingoBoulier; set => bingoBoulier = value; }
        internal List<BingoCard> CartesJoueur { get => cartesJoueur; set => cartesJoueur = value; }

        public BingoController(string nameUserInput, int parties)
        {
            this.NameUser = nameUserInput;
            this.PartiesBingo = parties;
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
                    initialiserNewPartie();
                    afficherSession();
                    menuBingo();
                    break;
                case "2":
                    BingoCard card = choisirUnecarteAfficher();
                    card.visualiserUneCarteJoueur();
                    VictorsBingo = card.Gagne(card.Valeur);
                    afficherSession();
                    menuBingo();
                    break;
                case "3":
                    CarteAnnonceur.visualiserCarteAnnonceur();
                    Console.WriteLine("\nVous avez tiré {0} boules.\n", BingoBoulier.getSize()); 
                    menuBingo();
                    break;
                case "4":
                    if (BingoBoulier.isEmpty())
                    {
                        Console.WriteLine("Fin de partie");
                        finPartie();
                    }
                    BingoBall temp = BingoBoulier.tirerUneBoule();
                    CarteAnnonceur.ajouterNumber(temp.Letter, temp.Number);

                    for (int k = 0; k < CartesJoueur.Count; k++)
                    {
                        CartesJoueur[k].changerNumberTo0(temp.Letter, temp.Number);
                    }
                    menuBingo();
                    break;
                case "5":
                    finPartie();
                    break;
                default:
                    menuBingo();
                    break;
            }
        }

        public void afficherSession()
        {
            Console.WriteLine("\n Le nom de l'utilisateur: {0}", NameUser);
            Console.WriteLine("\n Le nombre de partie joué Bingo: {0}\n Le nombre de vitoire: {1}\n",
                    PartiesBingo, VictorsBingo);
        }

        public void initialiserNewPartie()
        {
            PartiesBingo++;
            BingoBoulier.restartBoulier();
            VictorsBingo = 0;
            CartesJoueur = new List<BingoCard>();

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
                CartesJoueur.Add(bingoCard);
            }
        }

        public BingoCard choisirUnecarteAfficher()
        {
            int quelleCarte;
            bool isNumber;

            if (CartesJoueur.Count == 0)
            {
                Console.WriteLine("Vous avez aucune carte. Veuillez choisir <Initialiser une nouvelle partie>.");
                menuBingo();
            }
            do
            {
                Console.WriteLine("Vous avez {0} carte(s), quelle carte vous voulez visualiser? ", CartesJoueur.Count);
                string enter = Console.ReadLine();
                isNumber = int.TryParse(enter, out quelleCarte);
            }
            while (isNumber != true || quelleCarte > CartesJoueur.Count);

            return CartesJoueur[quelleCarte - 1];
        }

        public void finPartie()
        {
            CartesJoueur = new List<BingoCard>();
            VictorsBingo = 0;
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
