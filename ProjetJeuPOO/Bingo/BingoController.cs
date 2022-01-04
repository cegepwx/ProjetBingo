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
        private List<BingoCard> listCartes = new List<BingoCard>();
        private BingoBoulier bingoBoulier = new BingoBoulier();

        public string NameUser { get => nameUser; set => nameUser = value; }
        public int PartiesBingo { get => partiesBingo; set => partiesBingo = value; }
        public int VictorsBingo { get => victorsBingo; set => victorsBingo = value; }
        internal AnnonceCard CarteAnnonceur { get => carteAnnonceur; set => carteAnnonceur = value; }
        internal BingoBoulier BingoBoulier { get => bingoBoulier; set => bingoBoulier = value; }
        internal List<BingoCard> ListCartes { get => listCartes; set => listCartes = value; }

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
                    BingoCard card = choisirUnecarte();
                    card.visualiserUneCarteJoueur();
                    victorsBingo = card.Gagne(card.Valeur);
                    afficherSession();
                    menuBingo();
                    break;
                case "3":
                    CarteAnnonceur.visualiserCarteAnnonceur();
                    Console.WriteLine("\nVous avez tiré {0} boules.\n", BingoBoulier.getSize()); 
                    afficherSession();
                    menuBingo();
                    break;
                case "4":
                    tirerUneBoule();
                    afficherSession();
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
            ListCartes = new List<BingoCard>();

            //Initialiser Carte Annonceur en 0
            for (int i = 0; i < CarteAnnonceur.Valeur.GetLength(0); i++)
            {
            }

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
                ListCartes.Add(bingoCard);
            }

        }

        public BingoCard choisirUnecarte()
        {
            int i;
            bool isNumber;

            if (ListCartes.Count == 0)
            {
                Console.WriteLine("Vous avez aucune carte. Veuillez choisir <Initialiser une nouvelle partie>.");
                menuBingo();
            }
            do
            {
                Console.WriteLine("Vous avez {0} carte, quelle carte vous voulez visualiser? ", ListCartes.Count);
                string enter = Console.ReadLine();
                isNumber = int.TryParse(enter, out i);
            } 
            while (isNumber != true || i> ListCartes.Count);

            return ListCartes[i-1];
        }

        public  void tirerUneBoule()
        {
            if (BingoBoulier.isEmpty() == true)
            {
                Console.WriteLine("Fin de partie");
                finPartie();
            }
            BingoBall temp = BingoBoulier.getRanbomBall();
            Console.WriteLine("Ball {0}  {1}", temp.Letter, temp.Number);
            BingoBoulier.add(temp);
            ajouterNumber(temp.Letter, temp.Number);
            changerNumber(temp.Letter, temp.Number);
        }

        //Ajouter un numéro de la boule tirée à la carte annonceur. 
        public void ajouterNumber(char abc, int num)
        {
            int col=changerElement(abc);
            int raw = 0;
            while(raw < 15)
            {
                while(CarteAnnonceur.Valeur[raw, col] != 0)
                {
                    raw++; 
                }
                CarteAnnonceur.Valeur[raw, col] = num;
                break;
            }
        }

        //Changer le numéro de la carte de joueur à 0 s'il est même que la boule.
        public void changerNumber(char abc, int num)
        {
            int col = changerElement(abc);

            for(int k = 0; k < ListCartes.Count; k++)
            {
                for(int raw = 0; raw < 5; raw++)
                {
                    if(ListCartes[k].Valeur[raw, col] == num)
                    {
                        ListCartes[k].Valeur[raw, col] = 0;
                    }
                }
            }
        }

        //Changer les lettres B I N G O aux numéro 0 1 2 3 4
        public int changerElement(char carac)
        {
            int i;
            if (carac.Equals('B'))
            {
                i = 0;
            }
            else if (carac.Equals('I'))
            {
                i = 1;
            }
            else if (carac.Equals('N'))
            {
                i = 2;
            }
            else if (carac.Equals('G'))
            {
                i = 3;
            }
            else
            {
                i = 4;
            }
            return i;
        }

        //Fin de partie
        public void finPartie()
        {
            ListCartes = new List<BingoCard>();
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
                afficherSession();
                menuBingo();
            }
        }
    }
}
