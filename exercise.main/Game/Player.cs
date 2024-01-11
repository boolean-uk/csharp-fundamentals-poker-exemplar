using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Game
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand = new List<Card>();
    }
}
