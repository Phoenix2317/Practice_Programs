using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {
        //Testing point class
        Point Position1 = new Point(2, 3);
        Point Position2 = new Point(-4, 0);
        Console.WriteLine($"The first point is located at:  ({Position1.x}, {Position1.y})");
        Console.WriteLine($"The second point is located at: ({Position2.x}, {Position2.y})");
        Console.Write("\n");

        //testing color class
        Color Pallet = new Color(128, 158, 230);
        Color Basic = Color.Yellow();

        Console.WriteLine($"The values for the starting pallet are: (Red: {Pallet.r}, Green: {Pallet.g}, Blue: {Pallet.b}) ");
        Console.WriteLine($"The values for the basic Yellow are:    (Red: {Basic.r}, Green: {Basic.g}, Blue: {Basic.b})");
        Console.Write("\n");

        //testing Card class
        Card[] deck = new Card[55];

        int suit = 0;
        int rank = 0;
        
        
        for( int i = 0; i < deck.Length; i++ ) // Generates a deck of 55 card objects
        {
            
            if ((i + 1) % 14 == 0)
            {
                suit++;
                rank = 0;
            }

            CardRank currentRank = (CardRank)rank;
            CardColor currentSuit = (CardColor)suit;

            deck[i] = new Card(currentRank, currentSuit);
            rank++;
            
        }

        Console.WriteLine("The cards in the deck are: ");
        foreach (Card card in deck) 
        {
            Console.WriteLine($"The {card.Suit} {card.Rank}");
        }

    }

    public enum CardColor { red, green, blue, yellow}
    public enum CardRank { one, two, three, four, five, six, seven, eight, nine, ten, jack, king, queen, joker }

    public class Point
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public Point(int x, int y) //Lets the User set a point
        { 
            this.x = x;
            this.y = y;
        }

        public Point() //puts a point at the origin
        {
            this.x = 0;
            this.y = 0;
        }


    }

    public class Color
    {
        public int r {  get; private set; }
        public int g { get; private set; }
        public int b { get; private set; }

        public static Color White()
        {
            Color color = new Color(255, 255, 255);
            return color;
        }

        public static Color Black()
        {
            return new Color();
        }

        public static Color Red()
        {
            return new Color(255, 0, 0);
        }

        public static Color Orange()
        {
            return new Color(255, 165, 0);
        }

        public static Color Yellow()
        {
            return new Color(255, 255, 0);
        }

        public static Color Green()
        {
            return new Color(0, 128, 0);
        }

        public static Color Blue()
        {
            return new Color(0, 0, 255);
        }

        public static Color Purple()
        {
            return new Color(128, 0, 128);
        }

        public Color(int r, int g, int b) //Sets the color value to the desired notation, or to 0 if its out of bounds
        {
            if(r >= 0 && r <= 255)
            {
                this.r = r;
            } else
            {
                this.r = 0;
            }

            if (g >= 0 && g <= 255)
            {
                this.g = g;
            } else
            {
                this.g = 0;
            }

            if (b >= 0 && b <= 255)
            {
                this.b = b;
            } else
            {
                this.b = 0;
            }


        }

        public Color() //defaults all colors to 0
        {
            this.r = 0;
            this.g = 0;
            this.b = 0;
        }
    }

    public class Card
    {
        public CardRank Rank {  get;  private set; } //value on the card
        public CardColor Suit { get; private set; } //suit of the card

       

        public Card(CardRank rank, CardColor suit) //Generates a card value
        {
            this.Rank = rank;
            this.Suit = suit;
        }
    }
}