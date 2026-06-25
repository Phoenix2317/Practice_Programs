// See https://aka.ms/new-console-template for more information

Console.WriteLine("You enter a wooden cabin. In the center is a chest sitting on a table.");
// The chest is locked and you need to unlock it to get the special item inside.
Chest key = Chest.Locked;
State current = State.Closed;
string action;

while (true) // Main loop to interact with the chest
{
    if (key == Chest.Locked) // Check if the chest is locked
    {
        Console.Write("The chest is locked. What do you do? ");
        action = Console.ReadLine()!;

        if (action == "unlock") // Check if the user wants to unlock the chest
        {
            key = Chest.Unlocked;
        }
        else // If the user tries to do something else while the chest is locked
        {
            Console.WriteLine("You cannot do that action. (Make sure caps lock is off)");
        }
            
    } 
    else if (key == Chest.Unlocked && current == State.Closed) // Check if the chest is unlocked and closed
    {
        Console.Write("The chest is unlocked. What do you do? ");
        action = Console.ReadLine()!;

        if (action == "open") // Check if the user wants to open the chest
        {

            current = State.Open;

        }
        else // If the user tries to do something else while the chest is unlocked and closed
        {
            Console.WriteLine("You cannot do that action. (Make sure caps lock is off)");
        }
    } 
    else if (key == Chest.Unlocked && current == State.Open) // Check if the chest is unlocked and open
    {

        Console.Write("The chest is open. What do you do? ");
        action = Console.ReadLine()!;

        if (action == "close") // Check if the user wants to close the chest
        {
            current = State.Closed;
        } 
        else if (action == "take") // Check if the user wants to take the special item from the chest
        {

            Console.WriteLine("You got the special item!");
            break;

        }
        else // If the user tries to do something else while the chest is unlocked and open
        {
            Console.WriteLine("You cannot do that action. (Make sure caps lock is off)");
        }

    }



}

// Enum to represent the state of the chest (locked or unlocked)
enum Chest { Locked, Unlocked}
enum State { Closed, Open}