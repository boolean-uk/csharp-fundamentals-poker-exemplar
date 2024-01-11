using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Core
    {
        private readonly Dictionary<string, int> _cardValues = new Dictionary<string, int>
        {
            {"A", 14},
            {"K", 13},
            {"Q", 12},
            {"J", 11},
            {"10", 10},
            {"9", 9},
            {"8", 8},
            {"7", 7},
            {"6", 6},
            {"5", 5},
            {"4", 4},
            {"3", 3},
            {"2", 2}
        };

        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string, string>(string.Empty, string.Empty);
            int highestScore = 0;
            foreach (var pair in hand)
            {
                if (pair.Item1 != pair.Item2)
                {
                    continue;
                }

                // if we get here, the pair is a pair of cards; check if this is the winning pair (highest value)
                int score = GetValueOfCard(pair.Item1) + GetValueOfCard(pair.Item2);
                if (score > highestScore)
                {
                    highestScore = score;
                    result = pair;
                }
            }

            return result.Item1 != string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            int value = 0;
            _cardValues.TryGetValue(card, out value);
            return value;
        }
    }

}
