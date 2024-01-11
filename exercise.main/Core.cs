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
        
        //TODO: complete the following method, keeping the signature the same
        public bool winningPair(IEnumerable<Tuple<string, string>> hand, out Tuple<string, string> result)
        {
            result = new Tuple<string, string>(string.Empty, string.Empty);


            foreach (var matchingPair in hand.Where(p => p.Item1 == p.Item2))
            {
                if (result.Item1 == string.Empty)
                {
                    result = new Tuple<string, string>(matchingPair.Item1, matchingPair.Item2);
                }

                if (this.GetValueOfCard(matchingPair.Item1) >= this.GetValueOfCard(result.Item1))
                {
                    result = new Tuple<string, string>(matchingPair.Item1, matchingPair.Item2);
                }

            }



            return result.Item1 != string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            return CardHelper.Deck.ContainsKey(card) ? CardHelper.Deck[card] : 0;
        }
    }
}
