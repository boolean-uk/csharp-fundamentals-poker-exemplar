using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Extension
    {
        //TODO: complete the following method, keeping the signature the same
        public bool winningThree(IEnumerable<Tuple<string, string, string>> hand, out Tuple<string, string, string> result)
        {
            result = new Tuple<string, string, string>(string.Empty, string.Empty, string.Empty);
            int maxScore = 0;

            foreach (var triplet in hand)
            {
                if (triplet.Item1 == triplet.Item2 && triplet.Item2 == triplet.Item3)
                {
                    int score = new Core().GetValueOfCard(triplet.Item1);
                    if (score > maxScore)
                    {
                        maxScore = score;
                        result = triplet;
                    }
                }
            }

            return result.Item1 != string.Empty ? true : false;
        }

    }
}
