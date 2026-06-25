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
        foreach (Card card in deck) // Prints out the cards in the deck
        {
            Console.WriteLine($"The {card.Suit} {card.Rank}");
        }

        Door door = new Door(2317); // Creates a door object with a passcode of 2317

        do // Loops until the door is open
        {
            door.changeState(); // Calls the changeState method to change the state of the door
            Console.WriteLine($"The new state is: {door.state}");
        } while (door.state != State.open);


        // Testing the changePasscode method
        Console.Write("Attempting to change passcode, enter the current pass code: ");
        int code = Convert.ToInt32(Console.ReadLine());
        Console.Write("Attempting to change passcode, enter the new code: ");
        int newCode = Convert.ToInt32(Console.ReadLine());
        door.changePasscode(code, newCode); // Calls the changePasscode method to change the passcode of the door

    }
    // Enums for the Card class
    public enum CardColor { red, green, blue, yellow }
    public enum CardRank { one, two, three, four, five, six, seven, eight, nine, ten, jack, king, queen, joker }

    // Enum for the Door class
    public enum State { locked, unlocked, open, closed }

    // Class for the Point object
    public class Point
    {
        // Properties for the X and Y coordinates
        public int x { get; private set; }
        public int y { get; private set; }

        /** Initializes a new instance of the Point class with the specified X and Y coordinates.
         * @param x The X coordinate.
         * @param y The Y coordinate.
         */
        public Point(int x, int y) //Lets the User set a point
        { 
            this.x = x;
            this.y = y;
        }

        /** 
         * Initializes a new instance of the Point class at the origin (0, 0). 
         */
        public Point() //puts a point at the origin
        {
            this.x = 0;
            this.y = 0;
        }


    }

    // Class for the Color object
    public class Color
    {
        // Properties for the Red, Green, and Blue color components
        public int r {  get; private set; }
        public int g { get; private set; }
        public int b { get; private set; }

        /** Returns a Color object representing white (RGB: 255, 255, 255). */
        public static Color White()
        {
            Color color = new Color(255, 255, 255);
            return color;
        }
        /** Returns a Color object representing black (RGB: 0, 0, 0). */
        public static Color Black()
        {
            return new Color();
        }
        /** Returns a Color object representing red (RGB: 255, 0, 0). */
        public static Color Red()
        {
            return new Color(255, 0, 0);
        }
        /** Returns a Color object representing green (RGB: 0, 255, 0). */
        public static Color Orange()
        {
            return new Color(255, 165, 0);
        }
        /** Returns a Color object representing yellow (RGB: 255, 255, 0). */
        public static Color Yellow()
        {
            return new Color(255, 255, 0);
        }
        /** Returns a Color object representing green (RGB: 0, 128, 0). */
        public static Color Green()
        {
            return new Color(0, 128, 0);
        }
        /** Returns a Color object representing blue (RGB: 0, 0, 255). */
        public static Color Blue()
        {
            return new Color(0, 0, 255);
        }
        /** Returns a Color object representing purple (RGB: 128, 0, 128). */
        public static Color Purple()
        {
            return new Color(128, 0, 128);
        }

        /** Initializes a new instance of the Color class with the specified RGB values.
         * @param r The red component (0-255).
         * @param g The green component (0-255).
         * @param b The blue component (0-255).
         */
        public Color(int r, int g, int b) 
        {
            if(r >= 0 && r <= 255) // Checks if the red value is within the valid range (0-255)
            {
                this.r = r;
            } else
            {
                this.r = 0;
            }

            if (g >= 0 && g <= 255) // Checks if the green value is within the valid range (0-255)
            {
                this.g = g;
            } else
            {
                this.g = 0;
            }

            if (b >= 0 && b <= 255) // Checks if the blue value is within the valid range (0-255)
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

    // Class for the Door object
    public class Door
    {
        // Property to hold the passcode for the door
        public int passcode { get; private set; } = 0;

        // Property to hold the current state of the door (locked, unlocked, open, closed)
        public State state { get; private set; }

        /** Initializes a new instance of the Door class with the specified initial passcode.
         * @param initial The initial passcode for the door.
         */
        public Door(int intial)
        {
            passcode = intial;
            state = State.locked;
        }
        /** Changes the state of the door based on user input and the current state.
         * If the door is locked, prompts for the passcode to unlock it.
         * If the door is unlocked or closed, prompts to open or lock it.
         * If the door is open, changes its state to closed.
         */
        public void changeState()
        {

            if (state == State.locked) // If the door is locked, prompt for the passcode to unlock it
            {
                Console.Write("Please Enter the Passcode: ");
                int guess = Convert.ToInt32(Console.ReadLine() ?? "-1");
                if (guess == passcode) // If the entered passcode is correct, change the state to unlocked
                {
                    state = State.unlocked;
                }
                else
                {
                    Console.WriteLine("Incorrect passcode. The door remains locked.");
                }
            }
            else if (state == State.unlocked || state == State.closed) // If the door is unlocked or closed, prompt to open or lock it
            {
                int choice;
                Console.Write("Open (1) or Lock (2)?: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1) // If the user chooses to open the door, change the state to open
                {
                    state = State.open;
                }
                else if (choice == 2) { state = State.locked; } // If the user chooses to lock the door, change the state to locked
                else { Console.WriteLine("Unable to reach that state"); } // If the user enters an invalid choice, display an error message

            }
            else if (state == State.open)  // If the door is open, change its state to closed
            {
                state = State.closed;
            }
            

        }

        /** Changes the passcode of the door if the current passcode is provided correctly.
         * @param currentCode The current passcode to verify before changing.
         * @param newCode The new passcode to set if the current passcode is correct.
         */
        public void changePasscode(int currentCode, int newCode) 
        {

            if(passcode == currentCode)
            {
                passcode = newCode;
            }

        }
    }
}