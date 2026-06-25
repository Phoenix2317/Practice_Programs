// See https://aka.ms/new-console-template for more information


// Create instances of ColoredItem with different item types and colors
ColoredItem<Sword> LavaSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Red);
ColoredItem<Bow> ForestBow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Green);
ColoredItem<Axe> OceanicAxe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Blue);

// Display the colored items
LavaSword.Display();
ForestBow.Display();
OceanicAxe.Display();

// Define the item classes
public class Sword { }
public class Bow { }
public class Axe { }

// Generic class ColoredItem<T> that takes a type parameter T
public class  ColoredItem<T>
{
    
    public T item { get; } // Property to hold the item of type T
    public ConsoleColor color { get; } // Property to hold the color of the item

    // Constructor that initializes the item and color properties
    public ColoredItem(T Item, ConsoleColor Color)
    {
        item = Item;
        color = Color;
    }

    // Method to display the item with its color in the console
    public void Display()
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"This is a {color} {item.GetType().Name}");
        Console.ResetColor();
    }
}
