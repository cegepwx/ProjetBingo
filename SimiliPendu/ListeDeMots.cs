using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProjetJeuPOO.SimiliPendu
{
    class ListeDeMots
    {
        private List<string> valeur;
        public List<string> Valeur { get => valeur; set => valeur = value; }

        public ListeDeMots()
        {
            Valeur = new List<string>{ "imperméabilisation", "éligibilité", "possibilité", "couleur",
            "céréales", "projet", "friteur", "chanson", "recyclable", "chien", "pandémie" };
        }

        public string motsTire()
        {
            Random rendom = new Random();
            int index = rendom.Next(0, Valeur.Count);
            string word= Valeur[index];
            Valeur.RemoveAt(index);
            return word;
        }
    }
}
