// See https://aka.ms/new-console-template for more information

using System.Threading.Tasks.Sources;

Console.Write("Please enter your name: ");
string name = Console.ReadLine() ?? "User";

int score = 0;
bool debug = false;



if (File.Exists($"..\\..\\..\\{name}.txt"))
{

    if (debug)
    {
        Console.WriteLine(Path.GetFullPath($"..\\..\\..\\{name}.txt"));
    }

   score = Convert.ToInt32(File.ReadAllText($"..\\..\\..\\{name}.txt"));
    Console.WriteLine($"Welcome back, {name}! Your previous score was: {score}");
    Console.WriteLine("Let's see you get higher!)");
} else
{
    Console.WriteLine($"Welcome, {name}! Let's see how high you can score!");
    Console.WriteLine("Press any key on your keyboard to increase your score.");
        Console.WriteLine("Press Enter to stop");
}

while (true)
{
    if(Console.ReadKey().Key != ConsoleKey.Enter)
    {

        score++;

    } else
    {
        Console.WriteLine($"\n{name}, your score is: {score}");
        File.WriteAllText($"..\\..\\..\\{name}.txt", score.ToString());
        break;
    }
}


