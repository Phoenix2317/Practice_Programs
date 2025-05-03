// See https://aka.ms/new-console-template for more information
Console.WriteLine("How many provinces do you own? ");
int province = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("How many duchies do you own? ");
int duchies = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("How many estates do you own? ");
int estates = Convert.ToInt32(Console.ReadLine());
int score = 0;

for(int i = 0; i < province; i++)
{
    score += 6;
}

for(int i = 0; i < duchies; i++)
{
    score += 3;
}

for(int i = 0; i < estates; i++)
{
    score++;
}

Console.WriteLine("The total value of your kingdom is: " + score);