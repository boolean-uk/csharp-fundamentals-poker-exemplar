// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Card> cards = new List<Card>()
{
    new Card("4",4),
    new Card("4",4)
};

Random random = new Random();

Card firstcard = cards[random.Next(2)];

Console.WriteLine(firstcard.Name);
Console.WriteLine(firstcard.Value);

public class Card
{
    private string name_;
    private int _value;

    public Card(string name, int value)
    {
        _value = value;
        name_ = name;
    }

    public string Name {  get { return name_; } }
    public int Value { get { return _value; } }

}