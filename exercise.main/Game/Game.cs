using exercise.main.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Game
{
    public class Game
    {
        private int _handSize = 0;
        
        public Game()
        {
            GenerateFreshPackOfCards();
        }

        private void GenerateFreshPackOfCards()
        {
            foreach (KeyValuePair<string, int> item in CardHelper.Deck.Where(c => c.Key != "Joker"))
            {
                Deck.Add(new Card(item.Key, item.Value, Enums.Suit.Hearts));
            }
            foreach (KeyValuePair<string, int> item in CardHelper.Deck.Where(c => c.Key != "Joker"))
            {
                Deck.Add(new Card(item.Key, item.Value, Enums.Suit.Clubs));
            }
            foreach (KeyValuePair<string, int> item in CardHelper.Deck.Where(c => c.Key != "Joker"))
            {
                Deck.Add(new Card(item.Key, item.Value, Enums.Suit.Spades));
            }
            foreach (KeyValuePair<string, int> item in CardHelper.Deck.Where(c => c.Key != "Joker"))
            {
                Deck.Add(new Card(item.Key, item.Value, Enums.Suit.Diamonds));
            }
        }

        public void NewGame()
        {
            ShuffleDeck();
            Deal();
            Write();
        }

        private void Deal()
        {
            

            for(int x = 0; x < _handSize; x++)
            {
               foreach(Player player in Players)
               {
                    int index = 0;

                    Card card = Deck[index];

                    Deck.RemoveAt(index);
                    
                    player.Hand.Add(card);
               }
            }
        }
        
        public void Write()
        {
            foreach(Player player in Players)
            {
                Console.WriteLine($"{player.Name} has: ");
                player.Hand.ForEach(x => Console.WriteLine($"{x.Name} of {x.Suit.ToString()}"));
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public List<Card> Deck { get; set; } = new List<Card>();
        public void ShuffleDeck()
        {
            this.Deck.Shuffle();
        }

        public List<Player> Players = new List<Player>();
        public int HandSize { get { return _handSize; } set { _handSize = value;  } }
        public int NumberOfShuffles { get; set; } = 1;

    }
}
