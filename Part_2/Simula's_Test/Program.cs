// See https://aka.ms/new-console-template for more information

Console.WriteLine("You enter a wooden cabin. In the center is a chest sitting on a table.");

Chest key = Chest.Locked;
State current = State.Closed;
string action;
while (true)
{
    if (key == Chest.Locked)
    {
        Console.Write("The chest is locked. What do you do? ");
        action = Console.ReadLine()!;
        if (action == "unlock")
        {
            key = Chest.Unlocked;
        } else
        {
            Console.WriteLine("You cannot do that action. (Make sure caps lock is off)");
        }
            
    } 
    else if (key == Chest.Unlocked && current == State.Closed) 
    {
        Console.Write("The chest is unlocked. What do you do? ");
        action = Console.ReadLine()!;

        if (action == "open")
        {

            current = State.Open;

        }
        else
        {
            Console.WriteLine("You cannot do that action. (Make sure caps lock is off)");
        }
    } 
    else if (key == Chest.Unlocked && current == State.Open)
    {

        Console.Write("The chest is open. What do you do? ");
        action = Console.ReadLine()!;

        if (action == "close")
        {
            current = State.Closed;
        } 
        else if (action == "take")
        {

            Console.WriteLine("You got the special item!");
            break;

        } else
        {
            Console.WriteLine("You cannot do that action. (Make sure caps lock is off)");
        }

    }



}

enum Chest { Locked, Unlocked}
enum State { Closed, Open}