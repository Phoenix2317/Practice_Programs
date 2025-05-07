// See https://aka.ms/new-console-template for more information

int goal = -1;

do {
    Console.Write("User 1, enter a number between 0 and 100: ");
    goal = Convert.ToInt32(Console.ReadLine());
    
}while (goal < 0 || goal > 100);

Console.Clear();

Console.WriteLine("User 2, guess the number.");

int guess = -1;
do
{

    Console.Write("Your Guess: ");
    guess = Convert.ToInt32(Console.ReadLine());

    if(guess != goal)
    {

        if (guess > goal)
        {
            Console.WriteLine($"{guess} is too high.");
        }
        else
        {
            Console.WriteLine($"{guess} is too low.");
        }
    }
    
} while (guess != goal);

    Console.WriteLine("Congrats!");
