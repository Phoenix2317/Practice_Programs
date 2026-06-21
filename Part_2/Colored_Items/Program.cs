// See https://aka.ms/new-console-template for more information



ColoredItem<Sword> LavaSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Red);
ColoredItem<Bow> ForestBow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Green);
ColoredItem<Axe> OceanicAxe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Blue);

LavaSword.Display();
ForestBow.Display();
OceanicAxe.Display();

public class Sword { }
public class Bow { }
public class Axe { }

public class  ColoredItem<T>
{
    
    public T item { get; }
    public ConsoleColor color { get; }

    public ColoredItem(T Item, ConsoleColor Color)
    {
        item = Item;
        color = Color;
    }

    public void Display()
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"This is a {color} {item.GetType().Name}");
        Console.ResetColor();
    }
}
