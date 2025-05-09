// See https://aka.ms/new-console-template for more information

int province = AskForNumber("How many provinces do you own? ");
int duchies = AskForNumber("How many duchies do you own? ");
int estates = AskForNumber("How many estates do you own? ");
int score = 0;



score = province * 6 + duchies * 3 + estates;


Console.WriteLine("The total value of your kingdom is: " + score);


/// <summary>
/// Displays the given text on the console and returns the entered number
/// </summary>
int AskForNumber(string text)
{

    Console.WriteLine(text);
    int num = Convert.ToInt32(Console.ReadLine());
    return num;

}