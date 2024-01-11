using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Game
{
    public class Card
    {
        private string name_;
        private int _value;
        private Enums.Suit _suit;

        public Card(string name, int value, Enums.Suit suit)
        {
            _value = value;
            name_ = name;
            _suit = suit;
        }

        public string Name { get { return name_; } }
        public int Value { get { return _value; } }
        public Enums.Suit Suit { get {  return _suit; } }
    }
}
