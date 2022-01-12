using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjetJeuPOO.SimiliPendu
{
    class Pendu : IPendu
    {
        private string username;
        private int partiesPendu;
        private int gagnePoint = 0;
        private int numberEssaie;
        private string motsChoisi;
        private char[] motsPendu;
        private ListeDeMots words = new ListeDeMots();

        public string Username { get => username; set => username = value; }
        public int PartiesPendu { get => partiesPendu; set => partiesPendu = value; }
        public int NumberEssaie { get => numberEssaie; set => numberEssaie = value; }
        public string MotsChoisi { get => motsChoisi; set => motsChoisi = value; }
        public char[] MotsPendu { get => motsPendu; set => motsPendu = value; }
        internal ListeDeMots Words { get => words; set => words = value; }
        public int GagnePoint { get => gagnePoint; set => gagnePoint = value; }

        public Pendu(string user, int partie)
        {
            this.Username = user;
            this.PartiesPendu = partie;
            NumberEssaie = 5;
        }

        public void Jouer()
        {
            GagnePoint = 0;
            PartiesPendu = 0;
            NumberEssaie = 5;
            menuPendu();
        }

        public void menuPendu()
        {
            string choix = "";
            while (!(choix == "1" || choix == "2"))
            {
                Console.WriteLine("\nVeuillez choisir");
                Console.WriteLine("1. Commencer de jouer");
                Console.WriteLine("2. Retourner un autre jeu");
                choix = Console.ReadLine();
            }

            switch (choix)
            {
                case "1":
                    commencer();
                    break;
                case "2":

                    break;
            }
        }

        public void commencer()
        {
            PartiesPendu++;
            afficherSessoin();
            tirerMots();
            choisirIndice();
        } 

        public void afficherSessoin()
        {
            Console.WriteLine("\n Le nom de l'utilisateur: {0}", Username);
            Console.WriteLine(" Le nombre de partie joué Pendu: {0} ", PartiesPendu);
            Console.WriteLine(" Vous avez gagné {0} point(s).\n", GagnePoint);
        }
        public void tirerMots()
        {
            Random random = new Random();
            int index = random.Next(0, Words.Valeur.Count);
            MotsChoisi = Words.Valeur[index];
            MotsPendu = MotsChoisi.ToCharArray();

            for (int i = 0; i < MotsPendu.Length; i++)
            {
                MotsPendu[i]='-';
                Console.Write(MotsPendu[i]);
            }
            Console.WriteLine();
            Words.Valeur.RemoveAt(index);
        }
        
        public void choisirIndice()
        {
            if(MotsChoisi.Length > 10)
            {
                string choix;
                do
                {
                    Console.WriteLine("\n Le mot comporte plus de 10 caractères.");
                    Console.WriteLine("Voulez-vous avoir un indice? (Ceci vous pénalise d’un essai)");
                    Console.WriteLine("Votre choix: O/N");
                    choix = Console.ReadLine();
                    choix.ToLower();
                } 
                while (!(choix == "o" || choix == "n"));
              
                if(choix=="o")
                {
                    avoirIndice();
                }
                userEssaie();
            }
            else
            {
                userEssaie();
            }
            
        }

        public void avoirIndice()
        {
            NumberEssaie--;
            Random random = new Random();
            int index = random.Next(0, MotsChoisi.Length);
            char chRandom = MotsChoisi[index];
            changerCharInMotsPendu(chRandom);
            AfficherGagnant();
        }

        public void changerCharInMotsPendu(char ch)
        {
            for (int i = 0; i < MotsChoisi.Length; i++)
            {
                if (ch.Equals(MotsChoisi[i]))
                {
                    MotsPendu[i] = ch;
                }
            }
        }

        public void userEssaie()
        {
            while (NumberEssaie > 0)
            {
                Console.WriteLine("\nVous avez encore {0} essaie.", NumberEssaie);
                Console.WriteLine("Veueillez saisir :");
                string input = Console.ReadLine();

                if (input.Length > MotsChoisi.Length)
                {
                    input=input.Substring(0, MotsChoisi.Length);
                }
                trouverLetters(input);
                AfficherGagnant();
                if (gagnerPoints(input))
                {
                    break;
                }
                NumberEssaie--;
            }

            if (NumberEssaie == 0)
            {
                Console.WriteLine("Vous avez perdu.");
                Console.WriteLine("Le mots est: {0}", MotsChoisi);
                NumberEssaie = 5;
            }
            menuPendu();
        }

        public void trouverLetters(string saisir)
        {
            for (int i = 0; i < saisir.Length; i++)
            {
                for (int j = 0; j < MotsChoisi.Length; j++)
                {
                    if (saisir[i].Equals(MotsChoisi[j]))
                    {
                        MotsPendu[j] = MotsChoisi[j];
                    }
                }
            }
        }

        public bool gagnerPoints(string saisirMots)
        {
            bool isGagne = false;
            if (saisirMots.Equals(MotsChoisi))
            {
                GagnePoint++;
                isGagne = true;
                Console.WriteLine("\nVous avez gagné 1 partie. Vos points sont: {0}", GagnePoint);
                if (GagnePoint == 3)
                {
                    Console.WriteLine("\nFélicitation! Vous avez gagné!\n");
                    Jouer();
                }
            }
            return isGagne;
        }

        public void AfficherGagnant()
        {
            for(int i = 0; i < MotsPendu.Length; i++)
            {
                Console.Write(MotsPendu[i]);
            }
            Console.WriteLine();
        }
    }
}
