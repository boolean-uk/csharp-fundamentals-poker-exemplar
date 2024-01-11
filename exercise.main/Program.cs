PokerGame game = new PokerGame();
Player player1 = game.AddPlayer("Player 1");
Player player2 = game.AddPlayer("Player 2");
game.DealPlayers();
game.DealTableCards();
game.ShowTableCards();
game.ShowPlayers();

bool pause = true;

enum Suit
{
    Spades,
    Hearts,
    Clubs,
    Diamonds
}

class Card
{
    public Suit Suit { get; set; }
    public string Value { get; set; }

    public Card(Suit suit, string value)
    {
        Suit = suit;
        Value = value;
    }

    public int ValueAsInt()
    {
        switch (Value)
        {
            case "J":
                return 11;
            case "Q":
                return 12;
            case "K":
                return 13;
            case "A":
                return 14;
            default:
                return int.Parse(Value);
        }
    }
}

class Deck
{
    private List<Card>? cards;

    public Deck()
    {
        Reset();
    }

    public void Reset()
    {
        createDeck();
        shuffle();
    }

    public bool CanDeal()
    {
        return cards.Count > 0;
    }

    public Card Deal()
    {
        if (cards.Count == 0)
        {
            throw new Exception("No cards left in the deck");
        }
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }

    private void shuffle()
    {
        // create a reandom generator with a seed based on the current time
        Random rng = new Random((int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            // swap cards
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }

    private void createDeck()
    {
        cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            for (int i = 2; i <= 10; i++)
            {
                cards.Add(new Card(suit, i.ToString()));
            }
            cards.Add(new Card(suit, "J"));
            cards.Add(new Card(suit, "Q"));
            cards.Add(new Card(suit, "K"));
            cards.Add(new Card(suit, "A"));
        }
    }
}

class Player
{
    public string Name { get; }
    public List<Card> Hand { get; }

    public Player(string name)
    {
        Name = name;
        Hand = new List<Card>();
    }

    public bool AddCard(Card card)
    {
        if (Hand.Count >= 2)
        {
            return false;
        }
        Hand.Add(card);
        return true;
    }
}

class PokerGame
{
    private Deck deck;
    private List<Player> players;
    private List<Card> tableCards;

    public PokerGame()
    {
        deck = new Deck();
        players = new List<Player>();
        tableCards = new List<Card>();
    }

    public Player AddPlayer(string name)
    {
        Player player = new Player(name);
        players.Add(player);
        return player;
    }

    public void DealPlayers()
    {
        if (players.Count < 2)
        {
            throw new Exception("Not enough players");
        }
        if (!deck.CanDeal())
        {
            throw new Exception("Not enough cards in the deck");
        }
        foreach (Player player in players)
        {
            player.AddCard(deck.Deal());
        }
        foreach (Player player in players)
        {
            player.AddCard(deck.Deal());
        }
    }

    public void DealTableCards()
    {
        if (players.Count < 2)
        {
            throw new Exception("Not enough players");
        }
        if (!deck.CanDeal())
        {
            throw new Exception("Not enough cards in the deck");
        }
        tableCards.Add(deck.Deal());
        tableCards.Add(deck.Deal());
        tableCards.Add(deck.Deal());
        tableCards.Add(deck.Deal());
        tableCards.Add(deck.Deal());
    }

    public void ShowTableCards()
    {
        Console.WriteLine("Table cards:");
        foreach (Card card in tableCards)
        {
            Console.WriteLine($"{card.Value} of {card.Suit}");
        }
    }

    public void ShowPlayers()
    {
        foreach (Player player in players)
        {
            Console.WriteLine($"{player.Name} has:");
            foreach (Card card in player.Hand)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
        }
    }

}