using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetJeuPOO.SimiliBlackJack
{
    class BlackJack: IBlackJack
    {
        private Deck deck = new Deck();
        private Joueur joueur = new Joueur();
        private Joueur croupier = new Joueur();
        private int gagneJoueur;
        private int gagneCroupier;

        internal Deck Deck { get => deck; set => deck = value; }
        internal Joueur Joueur { get => joueur; set => joueur = value; }
        internal Joueur Croupier { get => croupier; set => croupier = value; }
        public int GagneJoueur { get => gagneJoueur; set => gagneJoueur = value; }
        public int GagneCroupier { get => gagneCroupier; set => gagneCroupier = value; }

        public BlackJack(int winpointJoueur, int winpointCroupier)
        {
            this.GagneJoueur = winpointJoueur;
            this.GagneCroupier = winpointCroupier;
        }

        public List<int> Jouer()
        {
            avoirUneCarte(Joueur);
            joueurAvoirCartes();
            croupierAvoirCartes();
            whoWin();
            List<int> listGagnePoint = new List<int>{GagneJoueur, GagneCroupier};
            return listGagnePoint;
        }

        public void joueurAvoirCartes()
        {
            string choix="1";
            while (choix == "1")
            {
                Console.WriteLine("Veuillez saisir votre choix:");
                Console.WriteLine("1. Avoir une carte supplémentaire ");
                Console.WriteLine("2. Conserver votre mise ");
                choix = Console.ReadLine();
                Console.WriteLine();

                if (choix == "1")
                {
                    avoirUneCarte(Joueur);
                }
                else if (choix == "2")
                {
                    conserverMise(Joueur);
                    break;
                }
                else break;
            }
        }

        public void croupierAvoirCartes()
        {
            do
            {
                avoirUneCarte(Croupier);
                Croupier.Points = VoirScore(Croupier);
            }
            while (!(Joueur.Points > 21 || Croupier.Points > Joueur.Points || (Croupier.Points==21 && Joueur.Points == 21)));
            Console.WriteLine("Le score du Croupier est: {0}", Croupier.Points);
        }

        public void avoirUneCarte(Joueur user)
        {
            user.Hand.Cards.Add(Deck.tirerUneCarte());
            user.Hand.afficherHand(user);
            Console.WriteLine("Le score est: {0}\n", VoirScore(user));
        }

        public void conserverMise(Joueur user)
        {
            user.Points = VoirScore(user);
            Console.WriteLine("Votre score est: {0}\n", user.Points);
        }

        public bool isGagneRapide(Joueur user)
        {
            if (user.Hand.Cards.Count == 2 && user.Points == 21) 
            { 
                foreach(Card card in user.Hand.Cards)
                {
                    if (card.Number == 1)
                    {
                        user.GagneRapide = true;
                    }
                }
            } 
            return user.GagneRapide;
        }

        public int VoirScore(Joueur user)
        {
            int score=0;
            bool isA = false;
            foreach(Card card in user.Hand.Cards)
            {
                card.Number = DealCard(card);
                score = score + card.Number;
                if (card.Number == 1)
                {
                    isA = true;
                }
            }
            
            if (isA==true && score < 12)
            {
                score += 10;
            }
            return score;
        }

        public int DealCard(Card card)
        {
            int points;
            if (card.Number >= 1 && card.Number <= 9)
            {
                points = card.Number;
            }
            else points = 10;

            return points;
        }

        public void whoWin()
        {
            if (isGagneRapide(Joueur) && isGagneRapide(Croupier))
            {
            }
            else if (isGagneRapide(Joueur) && !isGagneRapide(Croupier))
            {
                GagneJoueur += 2;
                Console.WriteLine("Votre score est: {0}. Vous avez gagné 2 points. Vos points totals est {1}. ", Joueur.Points, GagneJoueur);
            }
            else if (!isGagneRapide(Joueur) && isGagneRapide(Croupier))
            {
                GagneCroupier += 2;
                Console.WriteLine("Le score du Croupier est: {0}. Il a gagné 2 points. Ses points totals est {1}. ", Croupier.Points, GagneCroupier);
            }
            else 
            {
                if (Joueur.Points > 21 && Croupier.Points > 21)
                {
                }
                else if (Joueur.Points <= 21 && Croupier.Points > 21)
                {
                    GagneJoueur++;
                    Console.WriteLine("Votre score est: {0}. Vous avez gagné 1 point. Vos points totals est {1}. ", Joueur.Points, GagneJoueur);
                }
                else if (Joueur.Points > 21 && Croupier.Points <= 21)
                {
                    GagneCroupier++;
                    Console.WriteLine("Le score du Croupier est: {0}. Il a gagné 1 point. Ses points totals est {1}. ", Croupier.Points, GagneCroupier);
                }
                else 
                { 
                    if (Joueur.Points==Croupier.Points)
                    {
                    }
                    else if (Joueur.Points < Croupier.Points)
                    {
                        GagneCroupier++;
                        Console.WriteLine("Le score du Croupier est: {0}. Il a gagné 1 point. Ses points totals est {1}. ", Croupier.Points, GagneCroupier);
                    }
                    else
                    {
                        GagneJoueur++;
                        Console.WriteLine("Votre score est: {0}. Vous avez gagné 1 point. Vos points totals est {1}. ", Joueur.Points, GagneJoueur);
                    }
                }
            }

            if (GagneCroupier == 4)
            {
                Console.WriteLine("\nLe gangant est Croupier.\n");
            }
            else if (GagneJoueur == 4)
            {
                Console.WriteLine("\nVous avez gagné.\n");
            }
        }
    }
}
