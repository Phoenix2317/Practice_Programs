// See https://aka.ms/new-console-template for more information
bool correct = false;
// Tuple for the food being made
(Reciepie Style, Ingredient Main, Seasoning taste) Food = (Reciepie.Gumbo, Ingredient.Potatoes, Seasoning.Salty);

Console.WriteLine("Welcome to Simula's Restraunt!");

while (!correct)
{

    Console.Write("What Dish are you wanting? ");

    string dish = Console.ReadLine()!;

    switch (dish)
    {

        case "soup":
            Food.Style = Reciepie.Soup;
            correct = true;
            break;
        case "stew":
            Food.Style = Reciepie.Stew;
            correct = true;
            break;
        case "gumbo":
            Food.Style = Reciepie.Gumbo;
            correct = true;
            break;
        default:
            Console.WriteLine($"Sorry, We don't serve {dish}");
            break;

    }

}

correct = false;

while (!correct)
{
    Console.Write("And what do you want the main ingredient to be? ");

    string ingredient = Console.ReadLine()!;
    switch (ingredient)
    {

        case "mushrooms":
            Food.Main = Ingredient.Mushrooms;
            correct = true;
            break;
        case "chicken":
            Food.Main = Ingredient.Chicken;
            correct = true;
            break;
        case "carrots":
            Food.Main = Ingredient.Carrots;
            correct = true;
            break;
        case "Potatoes":
            Food.Main = Ingredient.Potatoes;
            correct = true;
            break;
        default:
            Console.WriteLine($"Sorry, We are all out of {ingredient}");
            break;

    }
}

correct = false;

while (!correct)
{

    Console.Write("What flavor do you want added? ");

    string flavor = Console.ReadLine()!;
    switch (flavor)
    {
        case "spicy":
            Food.taste = Seasoning.Spicy;
            correct = true; 
            break;
        case "salty":
            Food.taste = Seasoning.Salty;
            correct = true;
            break;
        case "sweet":
            Food.taste = Seasoning.Sweet;
            correct = true; 
            break;
        default:
            Console.WriteLine($"Sorry, I don't have any seasonings that make a {flavor} flavor");
            break;

    }

}

Console.WriteLine($"Alright, I will have your {Food.taste} {Food.Main} {Food.Style} in a few minuets.");


enum Reciepie { Soup, Stew, Gumbo }
enum Ingredient { Mushrooms, Chicken, Carrots, Potatoes}
enum Seasoning { Spicy, Salty, Sweet}