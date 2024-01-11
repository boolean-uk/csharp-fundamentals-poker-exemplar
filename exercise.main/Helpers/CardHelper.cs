using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Helpers
{
    public static class CardHelper
    {
        private static Dictionary<string, int> _deck = new Dictionary<string, int>
        {
            {"Joker",0 },{ "2", 2}, { "3", 3}, {"4", 4}, { "5", 5}, { "6", 6}, {"7",  7}, {"8", 8},{ "9",9},{ "10",10},{"J",11},{ "Q", 12}, { "K", 13}, { "A", 14}
        };

        public static Tuple<string,string> GetRandomPair()
        {
            Random rnd = new Random();

            //string firstCard = 
            string firstCard = _deck.FirstOrDefault(c => c.Value == rnd.Next(14)).Key;
            string secondCard = _deck.FirstOrDefault(c => c.Value == rnd.Next(14)).Key;            

            return new Tuple<string, string>(firstCard, secondCard);
        }

        public static Dictionary<string, int> Deck { get => _deck; }
    }
}
