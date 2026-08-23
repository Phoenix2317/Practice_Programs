// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using BoardGame;

double loc;

Console.WriteLine("Making Tic-Tac-Toe board...");


Board Tic = new Board();

while (!Tic.IsOver())
{
    Tic.Turn();

    
    
    Console.WriteLine("Turn: " + Tic.TurnCount);
    Console.WriteLine("Player: " + Tic.Player);

    Tic.PrintBoard();
    Console.Write("Enter your Placement with numpad: ");
    string? input = Console.ReadLine();
    while (input == null || !char.IsDigit(input, 0))
    {
        Console.WriteLine("Needs to be a number between 1-9, try again");
        Console.Write("Enter your Placement with numpad: ");
        input = Console.ReadLine();
    }
   

    loc = Convert.ToDouble(input);
    while (!Tic.Place(loc))
    {
        Console.WriteLine("Invalid input, try again.");

        Console.Write("Enter your Placement with numpad: ");
        loc = Convert.ToDouble(Console.ReadLine());
    }


}

Tic.PrintBoard();
Console.WriteLine("Player " + Tic.Player + " wins!");
